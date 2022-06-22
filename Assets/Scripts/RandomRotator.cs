using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    [SerializeField] float tumble;
    

    public Rigidbody asteroidRigidbody;
    void Start()
    {
        asteroidRigidbody.angularVelocity = Random.insideUnitSphere* tumble;
        Debug.Log(asteroidRigidbody.angularVelocity);
    }
}
