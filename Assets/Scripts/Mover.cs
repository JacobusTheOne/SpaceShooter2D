using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody someRigidbody;
    [SerializeField] float speed;

    private void Start()
    {
        someRigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        someRigidbody.velocity = new Vector3(0f, 0f, speed);
    }

    public float getSpeed()
    {
        return speed;
    }
}
