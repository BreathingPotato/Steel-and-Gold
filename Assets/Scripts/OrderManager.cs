using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderManager : MonoBehaviour
{
    int randomCustomerNumber;
    int randomOrderNumber;
    int randomOrderNumber1;
    int randomOrderAmount;
    int randomOrderAmount1;
    int itemTypeAmount;
    [SerializeField] GameObject orderCustomerUI;
    [SerializeField] GameObject orderItemUI;
    [SerializeField] GameObject orderItemUI1;
    [SerializeField] GameObject orderTextUI;
    [SerializeField] GameObject orderTextUI1;
    [SerializeField] GameObject textPrefab;

    CustomerType summonedCustomer;
    
    Order requestedItem;
    Order requestedItem1;


    public List<CustomerType> customerOrder = new List<CustomerType>();
    public List<Order> itemOrder = new List<Order>();

    private void Start()
    {
        CustomerArrives();
    }
    public void CustomerArrives()
    {
        foreach (Transform child in orderCustomerUI.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in orderTextUI.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in orderTextUI1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in orderItemUI.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in orderItemUI1.transform)
        {
            Destroy(child.gameObject);
        }
        randomCustomerNumber = Random.Range(0, customerOrder.Count);
        randomOrderNumber = Random.Range(0, itemOrder.Count);
        summonedCustomer = customerOrder[randomCustomerNumber];
        requestedItem = itemOrder[randomOrderNumber];
        requestedItem1 = itemOrder[randomOrderNumber1];
        
        GameObject customerIcon = Instantiate(summonedCustomer.CustomerIcon);
        customerIcon.transform.SetParent(orderCustomerUI.transform, false);
        customerIcon.transform.localPosition = Vector3.zero;

        GameObject orderIcon = Instantiate(requestedItem.ItemIcon);
        orderIcon.transform.SetParent(orderItemUI.transform, false);
        orderIcon.transform.localPosition = Vector3.zero;

        if (summonedCustomer.CustomerName == "Comissioner")
        {
            randomOrderAmount = Random.Range(3, 11);
            itemTypeAmount = Random.Range(1, 3);

            GameObject newText = Instantiate(textPrefab);
            newText.transform.SetParent(orderTextUI.transform, false);
            newText.transform.localPosition = Vector3.zero;
            newText.GetComponent<TMP_Text>().text = randomOrderAmount.ToString();

            if (itemTypeAmount >= 2)
            {
                randomOrderNumber1 = Random.Range(0, itemOrder.Count);
                randomOrderAmount1 = Random.Range(3, 11);

                GameObject orderIcon1 = Instantiate(requestedItem1.ItemIcon);
                orderIcon1.transform.SetParent(orderItemUI1.transform, false);
                orderIcon1.transform.localPosition = Vector3.zero;

                GameObject newText1 = Instantiate(textPrefab);
                newText1.transform.SetParent(orderTextUI1.transform, false);
                newText1.transform.localPosition = Vector3.zero;
                newText1.GetComponent<TMP_Text>().text = randomOrderAmount1.ToString();

                Debug.Log(summonedCustomer.CustomerName + " wants " + randomOrderAmount + " " + requestedItem.OrderName + " and " + randomOrderAmount1 + " " + requestedItem1.OrderName);
            }
            else
            {
                Debug.Log(summonedCustomer.CustomerName + " wants " + randomOrderAmount + " "+ requestedItem.OrderName);
            }
            
        }
            else
            {

        
            }



        //   Random number -> List -> Scriptable Object -> Name 
    }

}
