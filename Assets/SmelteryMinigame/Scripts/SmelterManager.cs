using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmelterManager : MonoBehaviour
{
    public Bellow bellow;
    public HeatMeter heatMeter;

    public Scrollbar progressBar;
    private float progress;
    public float targetProgress;
    public float progressSpeed;

    private bool isCompleted;

    // Update is called once per frame
    void Update()
    {
        heatMeter.AddHeat(bellow.output);

        if (heatMeter.isWithinTarget)
            progress += progressSpeed * Time.deltaTime;

        progressBar.size = progress / targetProgress;

        if (progress >= targetProgress) 
        {
            isCompleted = true;
            progress = targetProgress;
        }
    }
}
