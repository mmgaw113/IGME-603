using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ZombieCameraScript : MonoBehaviour
{
    public Material postMat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, postMat);
    }

    // Start is called before the first frame update
    void Start()
    {
        //postMat = new Material(postMat);

    }

}
