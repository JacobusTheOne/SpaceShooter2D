using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {
    public Rigidbody rigidbody;
  
    public Vector2 startTime;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public float smoothing;
    public float tilt;
    public float speed;
    //int sign = 1;

    public float newManeuver;
    private void Start()
    {
        rigidbody.velocity = new Vector3(0f, 0f, speed) ;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startTime.x,startTime.y));
        while (true)
        {
            newManeuver = Random.Range(1, 4)*-Mathf.Sign(rigidbody.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
            newManeuver = 0f;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x,maneuverTime.y)); 
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(newManeuver, rigidbody.velocity.y, speed);
        rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.x+180, 0f, rigidbody.velocity.x * -tilt);
        /*rigidbody.position = new Vector3
        (
              Mathf.Clamp(rigidbody.position.x, 6, -6),
              0f,
              Mathf.Clamp(rigidbody.position.z, -7, 15)
        ); */
    }
}
