using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushChangeColor : MonoBehaviour
{
    //The material property block we pass to the GPU
    private MaterialPropertyBlock propertyBlock;
    public Renderer ReferenceRenderer;
    public Renderer TargetRenderer;

    void Start()
    {
        //create propertyblock only if none exists
        if (propertyBlock == null)
        {
            propertyBlock = new MaterialPropertyBlock();
        }

        // Get the current value of the material properties in the renderer.
        TargetRenderer.GetPropertyBlock(propertyBlock);
        //set the color property
        propertyBlock.SetColor("_Color", ReferenceRenderer.material.color);
        //apply propertyBlock to renderer
        TargetRenderer.SetPropertyBlock(propertyBlock);
    }
}
