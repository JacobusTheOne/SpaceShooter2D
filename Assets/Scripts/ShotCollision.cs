using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
    }
   
}
