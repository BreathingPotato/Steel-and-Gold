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
    public int result;
    public Image progressBar;
    public TMP_Text numberDisplay;
    public OrderManager orderManager;

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
        progressAmountInt = (int)progressAmount;
        numberDisplay.SetText(progressAmountInt + "%");
        progressBar.fillAmount = progressAmount / 100f;
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
