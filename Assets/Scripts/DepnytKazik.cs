using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class DepnytKazik : MonoBehaviour, IControllable
{
    [SerializeField] Range rangePowerUp;
    [SerializeField] Range rangeAngleRotate;
    private Rigidbody thisRb;

    [System.Serializable]
    public struct Range
    {
        public int min;
        public int max;
    }
    private void Awake()
    {
        thisRb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        var upPower = Random.Range(rangePowerUp.min, rangePowerUp.max);
        thisRb.AddForce(Vector3.up * upPower, ForceMode.Force);
        var XRotate = Random.Range(rangeAngleRotate.min, rangeAngleRotate.max);
        var YRotate = Random.Range(rangeAngleRotate.min, rangeAngleRotate.max);
        var ZRotate = Random.Range(rangeAngleRotate.min, rangeAngleRotate.max);
        thisRb.AddTorque(new Vector3(XRotate, YRotate, ZRotate));
    }
}
