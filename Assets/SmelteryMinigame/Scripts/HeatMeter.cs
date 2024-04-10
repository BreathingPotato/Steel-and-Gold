using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    private Scrollbar scrollBar;
    private List<HeatLevel> heatLevels = new List<HeatLevel>();
    public List<Image> heatLevelImages = new List<Image>();

    public float heatLevel;
    public float maxHeat = 100;

    public float decaySpeed = 10;

    public float output;

    private bool initialized = false;

    // Start is called before the first frame update
    public void Initialize(List<HeatLevel> heatLevels)
    {
        this.heatLevels = heatLevels;

        scrollBar = GetComponent<Scrollbar>();
        SetTargetHeatImage();

        initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
            return;

        DecayHeat();

        ScaleBar();

        CheckHeatLevel();
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

    private void CheckHeatLevel() 
    {
        for(int i = 0; i < heatLevels.Count; i++) 
        {
            if (heatLevel > heatLevels[i].minHeat && heatLevel < heatLevels[i].maxHeat)
            {
                output = heatLevels[i].qualityModifier;
                break;
            }
        }
    }

    private void ScaleBar() 
    {
        float barSize = heatLevel / maxHeat;
        scrollBar.size = barSize;
    }

    private void SetTargetHeatImage() 
    {
        float barSize = GetComponent<RectTransform>().sizeDelta.y;
        if (barSize < 0)
            barSize *= -1;


        for (int i = 0; i < heatLevels.Count; i++) 
        {
            Image targetHeatImage = null;
            if(i < heatLevelImages.Count)
                targetHeatImage = heatLevelImages[i];

            if (targetHeatImage != null) 
            {
                targetHeatImage.rectTransform.localPosition = new Vector2(0,(heatLevels[i].minHeat/100)*barSize);
                targetHeatImage.rectTransform.sizeDelta = new Vector2(targetHeatImage.rectTransform.sizeDelta.x, ((heatLevels[i].maxHeat - heatLevels[i].minHeat)/100)*barSize);
            }
        }
    }
}
