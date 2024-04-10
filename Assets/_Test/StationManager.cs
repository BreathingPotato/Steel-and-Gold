using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// TEST
/// 
/// Very much a testing script
/// 
/// TEST

public class StationManager : MonoBehaviour
{
    public static StationManager instance;

    [SerializeField]
    private ForgeItem forgeItem;

    private GameObject minigameInstance;

    void Start() 
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            DataSaverTEST.instance.forgeItem = forgeItem;

            SceneChange.LoadScene("Shop UI");
        }
    }

    public void LoadMinigame(GameObject minigamePrefab) 
    {
        if (minigameInstance != null)
            Destroy(minigameInstance);

        minigameInstance = Instantiate(minigamePrefab);
    }

    public IEnumerator SmelteryMinigameInit() 
    {
        yield return new WaitForSeconds(0.1f);
        SmelterManager.instance.Initialize(forgeItem);

        while (!SmelterManager.instance.isCompleted) 
        {
            yield return null;
        }

        Destroy(minigameInstance);
        PlayerMovement.instance.StopPerforming();
    }

    public IEnumerator SmithingMinigameInit() 
    {
        yield return new WaitForSeconds(0.1f);
        SmithingManager.instance.Initialize(forgeItem);

        while (!SmithingManager.instance.isCompleted)
        {
            yield return null;
        }

        Destroy(minigameInstance);
        PlayerMovement.instance.StopPerforming();
        Debug.Log(forgeItem.Power());
    }
}
