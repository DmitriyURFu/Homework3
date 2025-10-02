using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SpawnDice : MonoBehaviour
{
    [SerializeField] private GameObject prefabDice;
    [SerializeField] private int radius;
    public int countDice { get; set; }
    private Transform spawnPoint;
    public static List<GameObject> spawnedDices;
    public void DoSpawnDice()
    {
        spawnedDices = new List<GameObject>();
        var stepAngle = 360f / countDice;
        spawnPoint = GetComponent<Transform>();
        for (var i = 0;  i < countDice; i++)
        {
            var angleSpawn = i * stepAngle * Mathf.Deg2Rad;
            var position = new Vector3(Mathf.Cos(angleSpawn) * radius, spawnPoint.position.y, Mathf.Sin(angleSpawn) * radius);
            var dice = Instantiate(prefabDice, position, Quaternion.identity);
            dice.transform.SetParent(spawnPoint, false);
            spawnedDices.Add(dice);
        }
    }
}
