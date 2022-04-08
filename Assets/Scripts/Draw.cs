using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    private bool isDrawing = false;
    private bool isMoving = false;

    private Vector3 previsousPos;
    private Vector3 currentPos;
    public GameObject paint;
    public GameObject TargetParent;

    // Start is called before the first frame update
    void Start()
    {
        previsousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        if (isDrawing & isMoving)
        {
            // create clone of loght billboard prefab and move the cloned object under target parent (Drawing) object
            GameObject billboard = Instantiate(paint, currentPos, Quaternion.identity, TargetParent.transform);
            billboard.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public void Draw_Start()
    {
        isDrawing = true;
    }
    public void Draw_End()
    {
        isDrawing = false;
    }

    public void checkMovement()
    {
        currentPos = transform.position;
        if (Vector3.Distance(previsousPos, currentPos) > 0.005)
        {
            isMoving = true;
            previsousPos = currentPos;
        }
        else
        {
            isMoving = false;
        }
    }

}
