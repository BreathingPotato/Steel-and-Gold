using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Questing : MonoBehaviour
{
    [Range(0, 100)]
    public float progressAmount;
    public int progressAmountInt;
    public float progressMax;
    public int result;
    public Image progressBar;
    public TMP_Text numberDisplay;
    public OrderManager orderManager;

    public List<ForgeItem> forgeItems = new List<ForgeItem>();

    void Start() 
    {
        forgeItems.Add(DataSaverTEST.instance.forgeItem);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            orderManager.CustomerArrives();
            UpdateProgress();
            NewDay();
        }
    }
    public void UpdateProgress()
    {
        float power = 0;
        foreach (ForgeItem forgeItem in forgeItems) 
        {
            power += forgeItem.Power();
        }

        progressAmountInt = (int)power;
        numberDisplay.SetText($"{(power/progressMax)*100}%");
        progressBar.fillAmount = power / progressMax;
    }
    
    public void NewDay()
    {
        result = Random.Range(0, 101);
        if(result <= progressAmountInt)
        {
            Debug.Log("Area Unlocked!!");
        }
        else
        {
            Debug.Log("Quest Failed");
        }
    }
}
