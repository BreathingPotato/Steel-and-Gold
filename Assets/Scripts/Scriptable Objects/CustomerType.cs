using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Create Customer/Customers", order = 1)]
public class CustomerType : ScriptableObject
{
    [SerializeField]
    private string customerName;
    public string CustomerName
    { get { return customerName; } set { customerName = value; } }

    // Whatever you need for the order mini games go in here.

}
