using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [SerializeField] GameObject shot;
    [SerializeField] GameObject shotSpawn;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.3f;
    [SerializeField] float maxTimeBetweenShots = 1.5f;

    private void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    


    public void ShootGun()
    {
        Instantiate(shot, shotSpawn.transform.position, shot.transform.rotation);
    }


    private void Update()
    {
        CountDownAndShoot();
        if(shotCounter<0)
        {
            ShootGun();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
    }


}
