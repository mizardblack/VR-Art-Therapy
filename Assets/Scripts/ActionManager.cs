using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public int phase = 0;
    private Vector3 previousPosition;
    private Vector3 currentPosition;

    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> levels = new List<GameObject>();

    public GameObject[] UI;
    public GameObject[] demos;


    // Start is called before the first frame update
    void Start()
    {
        GameObject tool = GameObject.Find("Tool");
        tool.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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

    public void ToPhase1() // when the target is the "brush"
    {
        float dist = Vector3.Distance(currentPosition, previousPosition);
        if (dist > 0.1f) // check move distance
        {
            phase = 1;
            // show next tutorial level
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }

    public void ToPhase2() // when the target is the "tray"
    {
        float dist = Vector3.Distance(currentPosition, previousPosition);
        if (dist > 0.01f) // check move distance
        {
            phase = 2;
            // show next tutorial level
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }

    public void ToPhase3() // when the target is the "toggle button"
    {
        phase = 3;
        // show next tutorial level
        levels[phase - 1].SetActive(false);
        levels[phase].SetActive(true);
    }

    public void ToPhase4() // when the target is the "slider"
    {
        float distX = Mathf.Abs(currentPosition.x - previousPosition.x);
        float distZ = Mathf.Abs(currentPosition.z - previousPosition.z);

        if (distX > 0.01f || distZ == 0f) // check move distance only on x axis
        {
            phase = 4;
            // show next tutorial level
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }
    public void ToPhase5() // when the target is the "grabber"
    {
        float distX = Mathf.Abs(currentPosition.x - previousPosition.x);
        float distY = Mathf.Abs(currentPosition.y - previousPosition.y);
        if (distX > 0.01f || distY == 0f) // check move distance only on x axis
        {
            phase = 5;
            // show next tutorial level
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }
    public void ToPhase6() // when the target is the "round button"
    {
        Debug.Log("start");

        // set "handles" position and scale
        GameObject handle = GameObject.Find("Handle (1)");
        handle.transform.localPosition = new Vector3(-0.39f, handle.transform.localPosition.y, handle.transform.localPosition.z);
        handle = GameObject.Find("Handle (2)");
        handle.transform.localPosition = new Vector3(0.369f, handle.transform.localPosition.y, handle.transform.localPosition.z);
        handle.transform.localScale = new Vector3(4f, 1.5f, 4f);
        // set "tray" scale
        GameObject tray = GameObject.Find("Tray");
        tray.transform.localScale = new Vector3(0.8f, 0.3f, 0.01f);

        ShowAllUI();

        // set "toggle button" position and scale
        GameObject button = GameObject.Find("ToggleButton");
        Debug.Log(button);
        button.transform.localPosition = new Vector3(-0.209000006f, -0.312000006f, 0.136000007f);
        button.transform.localScale = new Vector3(3f, 3f, 3f);
        // set "slider" position and scale
        GameObject slider = GameObject.Find("PinchSliderColorHue");
        slider.transform.localPosition = new Vector3(-0.0850000009f, -0.282999992f, 0.101000004f);
        slider.transform.localScale = new Vector3(1f, 1f, 1f);
        // set "joystick" position and scale
        GameObject joystick = GameObject.Find("JoystickPrefab (Scale)");
        joystick.transform.localPosition = new Vector3(0.0860000029f, 0.256195843f, 0.0294604301f);
        joystick.transform.localScale = new Vector3(0.030866839f, 0.030866839f, 0.030866839f);
        joystick = GameObject.Find("JoystickContainer");
        joystick.transform.localPosition = new Vector3(0.21570003f, -0.291000009f, 0.0350000001f);
        GameObject joystickBase = GameObject.Find("Base (Scale)");
        joystickBase.transform.localPosition = new Vector3(0f, -2.20000005f, -1.76999998f);
        joystickBase.transform.localScale = new Vector3(3.52501631f, 0.962074459f, 7f);
        // set "round button" position and scale
        button = GameObject.Find("ClearCanvasButton");
        button.transform.localPosition = new Vector3(0.383f, -0.310000002f, 0.128999993f);
        button.transform.localScale = new Vector3(2f, 2f, 2f);

        GameObject[] demos = GameObject.FindGameObjectsWithTag("Demo");
        foreach (GameObject demo in demos)
        {
            demo.SetActive(false);
        }

        HideAllDemo();
    }

    private void ShowAllUI()
    {
        // show all UI other than the control panel
        foreach (GameObject ui in UI)
        {
            ui.SetActive(true);
            Debug.Log(ui.name);
        }
    }
    private void HideAllUI()
    {
        // hide all UI other than the control panel
        foreach (GameObject ui in UI)
        {
            ui.SetActive(false);
            Debug.Log(ui.name);
        }
    }


    private void HideAllDemo()
    {
        // hide all demo UI
        foreach (GameObject demo in demos)
        {
            demo.SetActive(false);
        }
    }
}
