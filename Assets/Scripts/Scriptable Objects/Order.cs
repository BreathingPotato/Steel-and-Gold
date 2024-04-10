using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Order", menuName = "Create Order/Orders", order = 1)]
public class Order : ScriptableObject
{
    [SerializeField]
    public string orderName;
    public string OrderName
    { get { return orderName; } set { orderName = value; } }

    // Whatever you need for the order mini games go in here.

}
