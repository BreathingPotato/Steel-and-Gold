using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    int randomCustomerNumber;
    int randomOrderNumber;
    CustomerType summonedCustomer;
    Order requestedItem;


    public List<CustomerType> customerOrder = new List<CustomerType>();
    public List<Order> itemOrder = new List<Order>();

    private void Start()
    {
        CustomerArrives();
    }
    public void CustomerArrives()
    {
        randomCustomerNumber = Random.Range(0, customerOrder.Count);
        randomOrderNumber = Random.Range(0, itemOrder.Count);
        summonedCustomer = customerOrder[randomCustomerNumber];
        requestedItem = itemOrder[randomOrderNumber];

        Debug.Log(summonedCustomer.CustomerName + " wants " + requestedItem.OrderName);

     //   Random number -> List -> Scriptable Object -> Name 
    }

}
