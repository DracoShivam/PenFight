using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    public MeshRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        Material material = Renderer.material;
        material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
