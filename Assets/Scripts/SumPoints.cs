using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEditor.Progress;
using System;
public class SumPoints : MonoBehaviour
{
    [SerializeField] private List<GameObject> Dice;
    [SerializeField] private MeshCollider tableCollider;
    private int sumWinNumbers = 0;
    private bool isGetSum = false;
    void Update()
    {
        if (isAllStay() && !isGetSum)
        {
            isGetSum = true;
            foreach (var item in Dice)
            {
                var winNumber = item.GetComponent<DetectWinNumber>().winNumber;
                sumWinNumbers += winNumber;
            }
            Debug.Log(Convert.ToString(sumWinNumbers));
        }

        if (!isAllStay())
        {
            isGetSum = false;
            sumWinNumbers = 0;
        }
    }
    private bool isAllStay()
    {
        var flag = true;
        foreach (var item in Dice)
        {
            var colliderDice = item.GetComponent<BoxCollider>();
            if (!colliderDice.bounds.Intersects(tableCollider.bounds))
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
}
