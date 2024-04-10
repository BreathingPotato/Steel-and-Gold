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
    [SerializeField]
    private int materialHardness;
    [SerializeField]
    private List<HeatLevel> heatLevels;

    public string MaterialName
    { get { return materialName; } }

    public float MaterialValue
    { get { return materialValue; } }

    public float MaterialPower    
    { get { return materialPower; } }
    
    public int MaterialHardness 
    { get { return materialHardness; } }

    public List<HeatLevel> HeatLevels 
    { get { return heatLevels; } }

    // Whatever you need for the order mini games go in here.
}