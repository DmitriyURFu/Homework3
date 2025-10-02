using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GetInfoRaund : MonoBehaviour
{
    [SerializeField] private TMP_Text sumNumbersDices;
    [SerializeField] private TMP_Text rangeToWin;
    [SerializeField] private TMP_Text rangeToDraw;
    [SerializeField] private TMP_Text rangeToLose;
    [SerializeField] private TMP_Text countDices;
    [SerializeField] private SpawnDice creatorDice;
    [SerializeField] private Button dropDice;
    [SerializeField] private TMP_InputField inputCountDice;
    private SumPoints sumConsole;
    private GameObject GOSumConsole;
    private void Awake()
    {
        dropDice.onClick.AddListener(OnButtonClick);
        inputCountDice.onValueChanged.AddListener(OnInputСhanged);

        sumNumbersDices.text = "Кол-во очков: 0";
        rangeToWin.text = "Победа: 0-0";
        rangeToDraw.text = "Ничья: 0";
        rangeToLose.text = "Поражение: 0-0";
        countDices.text = "Число костей: 0";
    }
    private void Update()
    {
        if (sumConsole != null)
        {
            sumNumbersDices.text = "Кол-во очков: " + sumConsole.sumWinNumbers;
        }
    }
    private void OnInputСhanged(string number)
    {
        var countDice = int.Parse(number);
        creatorDice.countDice = countDice;
    }
    private void OnButtonClick()
    {
        if (SpawnDice.spawnedDices != null)
        {
            DeleteOldDice();
            DeleteOldSumConsole();
        }
        creatorDice.DoSpawnDice();
        DoSpawnSumConsole();
        if (creatorDice.countDice == 0)
        {
            rangeToWin.text = "Победа: 0-0";
            rangeToDraw.text = "Ничья: 0";
            rangeToLose.text = "Поражение: 0-0";
            countDices.text = "Число костей: 0";
        }
        else
        {
            var drawPoint = Random.Range(1, creatorDice.countDice * 6);
            rangeToWin.text = "Победа: " + Convert.ToString(drawPoint + 1) + "-" + Convert.ToString(creatorDice.countDice * 6);
            rangeToDraw.text = "Ничья: " + drawPoint;
            rangeToLose.text = "Поражение: 0-" + Convert.ToString(drawPoint - 1);
            countDices.text = "Число костей: " + creatorDice.countDice;
        }
    }
    private void DeleteOldDice()
    {
        foreach (var dice in SpawnDice.spawnedDices)
        {
                Destroy(dice);
        }
        SpawnDice.spawnedDices.Clear();
    }
    private void DoSpawnSumConsole()
    {
        GOSumConsole = new GameObject("SumConsole", typeof(SumPoints));
        sumConsole = GOSumConsole.GetComponent<SumPoints>();
    }
    private void DeleteOldSumConsole()
    {
        Destroy(GOSumConsole);
    }
}
