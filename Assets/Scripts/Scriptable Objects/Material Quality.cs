using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Material", menuName = "Create Material/Materials", order = 1)]
public class MaterialQuality : ScriptableObject
{
    [SerializeField]
    private string materialName;
    [SerializeField]
    private float materialValue;
    [SerializeField]
    private float materialPower;
    
    public float MaterialPower    
    { get { return materialPower; } set { materialPower = value; } }
    
    public float MaterialValue
    { get { return materialValue; } set { materialValue = value; } }
    
public string MaterialName
    { get { return materialName; } set { materialName = value; } }

    // Whatever you need for the order mini games go in here.

}