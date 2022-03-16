using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stock : MonoBehaviour
{
    [SerializeField]
    private GameObject stockObject = null;
    [SerializeField]
    private int stock;
 
    void Update()
    {
        Text textStock = stockObject.GetComponent<Text>();
        textStock.text = "X" + stock;
    }

    public void SubStock()
    {
        stock -= 1;
    }
}
