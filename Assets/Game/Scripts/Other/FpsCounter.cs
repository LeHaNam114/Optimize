using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFps;
    [SerializeField] private LimitFPS limitFPS;
    private float fps;
    private void Awake()
    {
        Application.targetFrameRate = (int)limitFPS;
    }
    void Start()
    {
        InvokeRepeating("ShowFPS",0.1f,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowFPS()
    {
        fps = (int) (1f / Time.unscaledDeltaTime);
        textFps.text = "FPS: " + fps;
    }
    
}
public enum LimitFPS
{
    Nolimit=9999,
    Limit30 =30,
    Limit60=60,
    Limit120=120,
    Limit144=144,
    Limit165=165,
    Limit180=180,
    Limit240= 240,
}