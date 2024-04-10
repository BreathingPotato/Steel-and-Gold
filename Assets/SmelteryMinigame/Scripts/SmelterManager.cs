using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmelterManager : MonoBehaviour
{
    public static SmelterManager instance;

    private ForgeItem forgeItem;

    public float quality;

    public Bellow bellow;
    public HeatMeter heatMeter;

    public Scrollbar progressBar;
    private float progress;
    public float targetProgress;
    public float progressSpeed;

    private bool startProgress = false;

    public bool isCompleted;

    public TMP_Text textMesh;

    private bool initialized = false;

    void Start()
    {
        instance = this;
    }

    public void Initialize(ForgeItem forgeItem)
    {
        this.forgeItem = forgeItem;
        quality = forgeItem.quality;

        textMesh.text = $"Material: {forgeItem.material.MaterialName}, Weapon quality is now {quality}";

        heatMeter.Initialize(forgeItem.material.HeatLevels);

        initialized = true;
    }
    void Update()
    {
        if (!initialized)
            return;

        heatMeter.AddHeat(bellow.output);

        if (Input.GetMouseButtonDown(1)) 
        {
            startProgress = true;
        }

        if (startProgress && !isCompleted) 
        {
            progress += progressSpeed * Time.deltaTime;
            quality += heatMeter.output * Time.deltaTime;
            textMesh.text = $"Material: {forgeItem.material.MaterialName}, Weapon quality is now {quality}";

            progressBar.size = progress / targetProgress;

            if (progress >= targetProgress)
            {
                forgeItem.quality += quality;
                textMesh.text = $"Final power is now {forgeItem.Power()}";

                progress = targetProgress;
                isCompleted = true;
            }
        }
    }
}
