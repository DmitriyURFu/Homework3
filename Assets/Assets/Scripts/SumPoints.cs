using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEditor.Progress;
using System;
public class SumPoints : MonoBehaviour
{

    private List<GameObject> dices;
    private int countDice;
    private MeshCollider tableCollider;
    private List<DetectWinNumber> winNumbersDices;
    private List<Rigidbody> rbDices;
    public int sumWinNumbers { get; private set; }
    private bool isGetSum;
    public void Awake()
    {
        dices = new List<GameObject>(SpawnDice.spawnedDices);
        countDice = dices.Count;
        tableCollider = GameObject.Find("Floor").GetComponent<MeshCollider>();
        winNumbersDices = new List<DetectWinNumber>();
        rbDices = new List<Rigidbody>();
        foreach (var dice in dices)
        {
            winNumbersDices.Add(dice.GetComponent<DetectWinNumber>());
            rbDices.Add(dice.GetComponent <Rigidbody> ());
        }
    }
    private void Update()
    {
        if (dices != null)
        {
            if (IsAllStay() && !isGetSum)
            {
                foreach (var winNumber in winNumbersDices)
                {
                    sumWinNumbers += winNumber.winNumber;
                }
                isGetSum = true;
                //Debug.Log(Convert.ToString(sumWinNumbers));
            }

            if (!IsAllStay())
            {
                isGetSum = false;
                sumWinNumbers = 0;
            }
        }
    }
    public bool IsAllStay()
    {
        var isAllStay = false;
        var countStayDices = 0;
        foreach (var rbDice in rbDices)
        {
            if (rbDice.linearVelocity.magnitude == 0 && rbDice.angularVelocity.magnitude == 0)
            {
                countStayDices++;
            }
        }
        if (countStayDices == countDice)
        {
            isAllStay = true;
        }
        return isAllStay;
    }
}
