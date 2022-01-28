using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stock : MonoBehaviour
{
    public GameObject stockObject = null;
    private int stock = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
