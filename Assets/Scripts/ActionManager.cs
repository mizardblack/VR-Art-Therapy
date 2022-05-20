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

        phase = 5;
        ToPhase6();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RecordPreviousPos()
    {
        if (phase < targets.Count)
        {
            previousPosition = targets[phase].transform.position;
        }
    }
    public void RecordCurrentPos()
    {
        if (phase < targets.Count)
        {
            currentPosition = targets[phase].transform.position;
        }
    }

    public void ToPhase1() // when the target is the "brush"
    {
        float dist = Vector3.Distance(currentPosition, previousPosition);
        if (dist > 0.1f && phase == 0) // check move distance
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
        if (dist > 0.01f && phase == 1) // check move distance
        {
            phase = 2;
            // show next tutorial level
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }
    }

    public void ToPhase3() // when the target is the "toggle button"
    {
        if (phase == 2)
        {
            phase = 3;
            // show next tutorial level
            levels[phase - 1].SetActive(false);
            levels[phase].SetActive(true);
        }

    }

    public void ToPhase4() // when the target is the "slider"
    {
        float distX = Mathf.Abs(currentPosition.x - previousPosition.x);
        float distZ = Mathf.Abs(currentPosition.z - previousPosition.z);

        if (distX > 0.01f || distZ == 0f) // check move distance only on x axis
        {
            if (phase == 3)
            {
                phase = 4;
                // show next tutorial level
                levels[phase - 1].SetActive(false);
                levels[phase].SetActive(true);
            }
        }
    }
    public void ToPhase5() // when the target is the "grabber"
    {
        float distX = Mathf.Abs(currentPosition.x - previousPosition.x);
        float distY = Mathf.Abs(currentPosition.y - previousPosition.y);
        if (distX > 0.01f || distY == 0f) // check move distance only on x axis
        {
            if (phase == 4)
            {

                phase = 5;
                // show next tutorial level
                levels[phase - 1].SetActive(false);
                levels[phase].SetActive(true);
            }
        }
    }
    public void ToPhase6() // when the target is the "round button"
    {
        if (phase == 5)
        {
            phase = 6;

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
            button.transform.localPosition = new Vector3(-0.209000006f, -0.326f, 0.136000007f);
            button.transform.localScale = new Vector3(3f, 3f, 3f);
            // set "slider" position and scale
            GameObject slider = GameObject.Find("PinchSliderColorHue");
            slider.transform.localPosition = new Vector3(-0.0850000009f, -0.283f, 0.1189995f);
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
            // set "clear button" position and scale
            button = GameObject.Find("ClearCanvasButton");
            button.transform.localPosition = new Vector3(0.383f, -0.317f, 0.128999993f);
            button.transform.localScale = new Vector3(2f, 2f, 2f);
            UI[9].SetActive(true); // UI

            // GameObject[] demos = GameObject.FindGameObjectsWithTag("Demo");
            // foreach (GameObject demo in demos)
            // {
            //     demo.SetActive(false);
            // }

            HideAllDemo();
        }
    }
    public void Restart()
    {
        phase = 0;

        // set "joystick base" position and scale
        GameObject joystickBase = GameObject.Find("Base (Scale)");
        joystickBase.transform.localPosition = new Vector3(0f, -2.20000005f, -0.0199999996f);
        joystickBase.transform.localScale = new Vector3(3.52501631f, 0.962074459f, 3.52501607f);

        HideAllDemo();
        HideAllUI();

        demos[0].SetActive(true);

        // set "handles" position and scale
        GameObject handle = GameObject.Find("Handle (1)");
        handle.transform.localPosition = new Vector3(-0.225f, handle.transform.localPosition.y, handle.transform.localPosition.z);
        handle = GameObject.Find("Handle (2)");
        handle.transform.localPosition = new Vector3(0.213f, handle.transform.localPosition.y, handle.transform.localPosition.z);
        handle.transform.localScale = new Vector3(4f, 1.5f, 4f);
        // set "tray" scale
        GameObject tray = GameObject.Find("Tray");
        tray.transform.localScale = new Vector3(0.495049506f, 0.300000012f, 0.00999999885f);

        // set "toggle button" position and scale
        UI[0].transform.localPosition = new Vector3(0.0689999983f, -0.314999998f, 0.0799999982f);
        UI[0].transform.localScale = new Vector3(4f, 4f, 4f);

        // set "slider" position and scale
        UI[1].transform.localPosition = new Vector3(0.0170000009f, -0.36500001f, 0.101000004f);
        UI[1].transform.localScale = new Vector3(2f, 2f, 2f);

        // set "joystick" position and scale
        UI[6].transform.localPosition = new Vector3(-0.301999986f, 0.158999994f, 0.0610000007f);
        UI[6].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        UI[7].SetActive(false); // UI
        GameObject joystick = GameObject.Find("JoystickContainer");
        joystick.transform.localPosition = new Vector3(0.21570003f, -0.254000008f, 0.0350000001f);

        // set "clear button" position and scale
        UI[8].transform.localPosition = new Vector3(0.0719999969f, -0.305000007f, 0.128999993f);
        UI[8].transform.localScale = new Vector3(3f, 3f, 3f);
        UI[9].SetActive(false); // UI

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
