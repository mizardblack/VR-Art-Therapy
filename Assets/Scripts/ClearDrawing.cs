using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDrawing : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        //get canvas

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clear()
    {
        // move brush back to the center
        GameObject brush = GameObject.Find("Brush");
        brush.transform.localPosition = new Vector3(0f, -0.156000003f, 0.270000011f);
        // clear all the drawing
        foreach (Transform child in canvas.transform)
        {
            if (child.tag == "Drawing")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

}
