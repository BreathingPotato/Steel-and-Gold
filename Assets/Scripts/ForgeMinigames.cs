using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeMinigames : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public bool forgeStation;
    public bool anvilStation;
    public bool grindstoneStation;
    public bool smelteryStation;

    public GameObject forgeUi;
    public GameObject anvilUi;
    public GameObject grindstoneUi;
    public GameObject smelteryUi;
    public GameObject offButton;

    public GameObject smelteryMinigamePrefab;
    public GameObject smithingMinigamePrefab;


    public void OnTriggerEnter2D(Collider2D other)
    {
            triggerActive = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
            triggerActive = false;
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMovement.instance.performingAction = true;
            if( forgeStation == true)
            {
                OpenForge();
            }
            else if(anvilStation == true)
            {
                OpenAnvil();
            }
            else if(grindstoneStation == true)
            {
                OpenGrindstone();
            }
            else if(smelteryStation == true)
            {
                OpenSmeltery();
            }
        }
    }

    public void OpenForge()
    {
        //offButton.gameObject.SetActive(true);
        //forgeUi.gameObject.SetActive(true);
        Debug.Log("OpenForge");
    }

    public void OpenAnvil()
    {
        //offButton.gameObject.SetActive(true);
        //anvilUi.gameObject.SetActive(true);
        StationManager.instance.LoadMinigame(smithingMinigamePrefab);
        StartCoroutine(StationManager.instance.SmithingMinigameInit());
        Debug.Log("OpenAnvil");
    }

    public void OpenGrindstone()
    {
        //offButton.gameObject.SetActive(true);
        //grindstoneUi.gameObject.SetActive(true);
        Debug.Log("OpenGrindstone");
    }

    public void OpenSmeltery()
    {
        //offButton.gameObject.SetActive(true);
        //smelteryUi.gameObject.SetActive(true);
        StationManager.instance.LoadMinigame(smelteryMinigamePrefab);
        StartCoroutine(StationManager.instance.SmelteryMinigameInit());
        Debug.Log("OpenSmeltery");
    }
}
