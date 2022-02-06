using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ZombieCameraScript : MonoBehaviour
{
    public Material postMat;
    public float infection;

    private Vector3 pickup;
    private Vector4 toShader;
    private float blast;

    // Start is called before the first frame update
    void Start()
    {
        postMat = new Material(postMat);
        pickup = new Vector3();
        blast = 1;
        toShader = new Vector4();
    }

    private void Update()
    {
        if (blast < 1)
        {
            blast += Time.deltaTime;
            Vector2 screen = Camera.main.WorldToScreenPoint(pickup);
            toShader.x = screen.x;
            toShader.y = screen.y;
            toShader.z = blast;
            toShader.w = 1;
        }
        else
            toShader.w = 0;
    }

    public void setPickup(Vector3 point)
    {
        blast = 0;
        pickup = point;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        postMat.SetFloat("_Infection", infection);
        postMat.SetVector("_ShockWave", toShader);

        Graphics.Blit(source, destination, postMat);
    }

}
