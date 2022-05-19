using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    // public GameObject target;
    public int phase = 0;
    private Vector3 previousPosition;
    private Vector3 currentPosition;

    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> levels = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RecordPreviousPos()
    {
        previousPosition = targets[phase].transform.position;
    }
    public void RecordCurrentPos()
    {
        currentPosition = targets[phase].transform.position;
    }

    public void ToPhase1() //when the target is the "tray"
    {
        float dist = Vector3.Distance(currentPosition, previousPosition);
        if (dist > 0.01f) // check move distance
        {
            phase = 1;
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }

    public void ToPhase2() //when the target is the "toggle button"
    {
        phase = 2;
        levels[phase - 1].SetActive(false);
        levels[phase].SetActive(true);
    }

    public void ToPhase3() //when the target is the "slider"
    {
        float distX = Mathf.Abs(currentPosition.x - previousPosition.x);
        float distZ = Mathf.Abs(currentPosition.z - previousPosition.z);

        if (distX > 0.01f || distZ == 0f) // check move distance only on x axis
        {
            phase = 3;
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }
    public void ToPhase4() //when the target is the "grabber"
    {
        float distX = Mathf.Abs(currentPosition.x - previousPosition.x);
        float distY = Mathf.Abs(currentPosition.y - previousPosition.y);
        if (distX > 0.01f || distY == 0f) // check move distance only on x axis
        {
            phase = 4;
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }
    public void ToPhase5() //when the target is the "round button"
    {
        // phase = 5;
        Debug.Log("switch scene");
    }
}
