using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

public class DetectWinNumber : MonoBehaviour
{
    [SerializeField] private List<GameObject> numbersDice;
    private MeshCollider tableCollider;
    private Rigidbody rbDice;
    private Dictionary<CapsuleCollider, int> colliderToNumberDict;
    public int winNumber { get; private set; }
    private bool isCalculated;

    void Awake()
    {
        tableCollider = GameObject.Find("Floor").GetComponent<MeshCollider>();
        rbDice = GetComponent<Rigidbody>();
        colliderToNumberDict = new Dictionary<CapsuleCollider, int>();
        foreach (var number in numbersDice)
        {
            colliderToNumberDict[number.GetComponent<CapsuleCollider>()] = Convert.ToInt32(number.name);
        }
    }
    void Update()
    {
        if (DiceIsStay(rbDice) && !isCalculated)
        {
            winNumber = CheckWinSide();
            isCalculated = true;
        }
       if (!DiceIsStay(rbDice))
        {
            isCalculated = false;
        }
    }

    private bool DiceIsStay(Rigidbody rbDice)
    {
        var isStay = false;
        if (rbDice.linearVelocity.magnitude == 0 && rbDice.angularVelocity.magnitude == 0)
        {
                isStay = true;
        }
        return isStay;
    }

    private int CheckWinSide()
    {
        var winNumber = 0;
        foreach (var colliderToNumber in colliderToNumberDict)
        {
            if (colliderToNumber.Key.bounds.Intersects(tableCollider.bounds))
            {
                winNumber = 7 - colliderToNumber.Value;
            }
        }
        return winNumber;
    }
}
