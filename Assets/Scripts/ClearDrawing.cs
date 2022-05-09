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
        foreach (Transform child in canvas.transform)
        {
            if (child.tag == "Drawing")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

}
