using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCounter : MonoBehaviour
{
    private Text memText;

    void Start()
    {
        memText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float memInUse = System.GC.GetTotalMemory(false) / 1000000;
        memText.text = "Memory Usage: " + memInUse + " MB";
    }
}