using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

public class DetectWinNumber : MonoBehaviour
{
    [SerializeField] private List<GameObject> numbersDice;
    [SerializeField] private GameObject table;
    private float coordinateYTable;
    public int winNumber { get; private set; }
    private bool isCalculated = false;

    void Awake()
    {
        coordinateYTable = table.GetComponent<Transform>().position.y;
    }
    void Update()
    {
        if (DiceIsStay() && !isCalculated)
        {
            isCalculated = true;
            winNumber = CheckWinSide();
        }
       if (!DiceIsStay())
        {
            isCalculated = false;
        }
    }

    private bool DiceIsStay()
    {
        var isStay = false;
        foreach (var number in numbersDice)
        {
            if (number.transform.position.y <= coordinateYTable)
            {
                isStay = true;
                break;
            }
        }
        return isStay;
    }

    private int CheckWinSide()
    {
        var sortedSides = numbersDice.OrderByDescending(side => side.transform.position.y).ToList();
        //var winNumber = sortedSides[0].name;
        var winNumber = Convert.ToInt32(sortedSides[0].name);
        return winNumber;
    }
}
