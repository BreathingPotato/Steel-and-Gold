using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ForgeItem
{
    public MaterialQuality material;
    public string weaponType;
    public string name => $"{material.name} {weaponType}";
    public float quality;

    public int Power() 
    {
        float power = (100 +quality) * material.MaterialPower;
        return (int)power;
    }

    public int Value() 
    {
        float value = (100 + Power()) * material.MaterialValue;
        return (int)value;
    }
}
