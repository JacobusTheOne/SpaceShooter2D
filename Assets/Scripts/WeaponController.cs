using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    
    [SerializeField] GameObject shot;
    [SerializeField] GameObject shotSpawn;
    public float fireRate;
    public float delay;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Fire",delay,fireRate);
    }
	
    void Fire()
    {
        Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
    }
}
