using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    private Scrollbar scrollBar;
    public Image targetHeatImage;

    public float heatLevel;
    public float maxHeat = 100;

    public float decaySpeed = 10;

    public float targetHeatMin, targetHeatMax;

    public bool isWithinTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        scrollBar = GetComponent<Scrollbar>();
        SetTargetHeatImage();
    }

    // Update is called once per frame
    void Update()
    {
        DecayHeat();

        ScaleBar();

        if (heatLevel > targetHeatMin && heatLevel < targetHeatMax)
            isWithinTarget = true;
        else
            isWithinTarget = false;
    }

    public void AddHeat(float value) 
    {
        heatLevel += value * Time.deltaTime;
        heatLevel = Mathf.Clamp(heatLevel, 0, maxHeat);
    }

    private void DecayHeat()
    {
        heatLevel -= decaySpeed * Time.deltaTime;
        heatLevel = Mathf.Clamp(heatLevel, 0, maxHeat);
    }

    private void ScaleBar() 
    {
        float barSize = heatLevel / maxHeat;
        scrollBar.size = barSize;
    }

    private void SetTargetHeatImage() 
    {
        targetHeatImage.rectTransform.localPosition = new Vector2(0,targetHeatMin);
        targetHeatImage.rectTransform.sizeDelta = new Vector2(targetHeatImage.rectTransform.sizeDelta.x, targetHeatMax);
    }
}
