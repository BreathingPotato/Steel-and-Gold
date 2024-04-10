using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaverTEST : MonoBehaviour
{
    public static DataSaverTEST instance;

    public ForgeItem forgeItem;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
