Shader "Hidden/zombieVision"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Infection ("Infection", range(0,1)) = 0
        _ShockWave ("Shock wave data", Vector) = (0,0,0,0)
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _Infection;
            float4 _ShockWave;

            // makes a shock wave
            float2 ShockWaveEffect(float2 uv, float2 vertex)
            {
                if (_ShockWave.w == 1)
                {
                    // correct the vertex y position
                    vertex.y = _MainTex_TexelSize.w - vertex.y;

                    // effect scales to the screen size
                    int2 screen_size = int2(_MainTex_TexelSize.y, _MainTex_TexelSize.w);

                    // finds the distance from the epicenter of the effect
                    float2 pixels_from_center = vertex - float2(_ShockWave.x, _ShockWave.y);
                    float dist_from_center = length(pixels_from_center);

                    // 
                    int radius = 100;
                    int wave_peak = _ShockWave.z * radius;

                    float distance_from_wave = dist_from_center - (float)wave_peak;
                    float wave_length = 50 + _ShockWave.z * 100;
                    float distance_to_displace = 0;
                    if (distance_from_wave > 0 && distance_from_wave < wave_length)
                    {
                        distance_to_displace += (1 - pow(((distance_from_wave / wave_length) - 0.5) * 2, 2)) * (1 - _ShockWave.z) / 20;
                    }

                    float2 disp_uv = normalize(uv - float2(0.5, 0.5)) * distance_to_displace;

                    return disp_uv;
                }
                return float2(0, 0);
            }

            float CreepingDarkness(float2 uv) 
            {
                float2 toCenter = uv - float2(0.5, 0.5);
                float darkness = lerp( 1, 0.75, (_Infection)) - length(toCenter);

                return darkness;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 dispUV = i.uv;
                dispUV += ShockWaveEffect(dispUV, i.vertex);

                fixed4 col = tex2D(_MainTex, dispUV);
                
                // flashing red
                float flashNum = pow(sin(_Time[3]), 4) * 0.25 * _Infection;
                col.r += flashNum;
                col.g -= flashNum;
                col.b -= flashNum;

                //if (_ShockWave.x - 5 < i.vertex.x && _ShockWave.x + 5 > i.vertex.x && _ShockWave.y - 5 < i.vertex.y && _ShockWave.y + 5 > i.vertex.y)
                //    col.rgb = 0;

                col.rgb *= CreepingDarkness(i.uv);

                return col;
            }
            ENDCG
        }
    }
}
