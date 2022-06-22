using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    Coroutine firingCoroutine;

    public GameObject[] laser;
    public float fireSpeed;
    public float fireRate;
    
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {


            firingCoroutine = StartCoroutine("FireContinuously");

        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laserZ = Instantiate(laser[0], transform.position, Quaternion.identity) as GameObject;
            laserZ.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);           
            yield return new WaitForSeconds(fireRate);

        }
    }
}
