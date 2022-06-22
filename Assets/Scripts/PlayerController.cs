using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {
    Rigidbody planeRigidbody;
    Transform planeTransform;
    float moveHorizontal;
    float moveVertical;
    Shoot shoot;
    [SerializeField] float speed;
    [SerializeField] float tilt;
    [SerializeField] float nextFire = 0.1f;
    [SerializeField] float fireRate = 0f;
    float yPlane;
    //public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        
        planeRigidbody = GetComponent<Rigidbody>();
        planeTransform = GetComponent<Transform>();
        yPlane = planeTransform.position.y;
        shoot = FindObjectOfType<Shoot>();
        score = 0;
        //UpdateScore();
        
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot.ShootGun();
        }
    }



    void FixedUpdate ()
    {
        float restrictHorizontal = Mathf.Clamp(planeRigidbody.position.x, -6.5f,6.5f);
        float restrictVertical = Mathf.Clamp(planeRigidbody.position.z, -5, 15);
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        //Debug.Log(planeTransform.position.x);
        //Debug.Log(moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        planeRigidbody.position = new Vector3(restrictHorizontal,yPlane,restrictVertical);
        planeRigidbody.velocity = movement * speed;
        planeRigidbody.rotation = Quaternion.Euler(0f, 0f, planeRigidbody.velocity.x*-tilt);

    }
    /*
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }*/

    public void AddScore(int newValue)
    {
        score += newValue;
        //UpdateScore();
    }

    


}
