using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ZombieCameraScript : MonoBehaviour
{
    public Material postMat;
    public float infection;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        postMat.SetFloat("_Infection", infection);
        Graphics.Blit(source, destination, postMat);
    }

    // Start is called before the first frame update
    void Start()
    {
        postMat = new Material(postMat);

    }

}
