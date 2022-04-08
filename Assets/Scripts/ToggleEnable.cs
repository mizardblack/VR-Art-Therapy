using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnable : MonoBehaviour
{
    public GameObject buidlings;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        buidlings.SetActive(flag);
    }

    public void ToggleBuidlings()
    {
        flag = !flag;
    }
}
