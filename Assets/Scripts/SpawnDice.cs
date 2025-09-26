using UnityEngine;

public class SpawnDice : MonoBehaviour
{
    [SerializeField] private GameObject prefabDice;
    [SerializeField] private int countDice;
    [SerializeField] private int radius;
    private Transform spawnPoint;
    private void Awake()
    {
        var stepAngle = 360f / countDice;
        spawnPoint = GetComponent<Transform>();
        for (var i = 0;  i < countDice; i++)
        {
            var angleSpawn = i * stepAngle * Mathf.Deg2Rad;
            var position = new Vector3(Mathf.Cos(angleSpawn) * radius, spawnPoint.position.y, Mathf.Sin(angleSpawn) * radius);
            Instantiate(prefabDice, position, Quaternion.identity);
        }
    }
}
