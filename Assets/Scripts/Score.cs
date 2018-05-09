using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public ShipBlockList shipBlockList;
    public Text text;

    private void Start()
    {
        shipBlockList = GetComponent<ShipBlockList>();

        int x;
        x = shipBlockList.listOfShipParts.Count;
        x = x * 10;

        text.text = x.ToString();
    }
}
