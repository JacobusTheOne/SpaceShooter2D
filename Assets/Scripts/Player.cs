using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [Header("Player")]
    public float setSpeed;
    public float HitPoints = 100;

    SceneLoader sceneLoader;
   
    public int playerDamage = 40;
    public float score = 0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    [SerializeField] GameObject playerExplosion;
    Coroutine firingCoroutine;
	// Use this for initialization
	void Start () {
        sceneLoader = FindObjectOfType<SceneLoader>();
	}

    

    // Update is called once per frame
    void Update () {
        Move();
        //Fire();
        restrictHorizontal();
        restrictVertical();
        AliveOrNot();
        scoreText.text = score.ToString();
        healthText.text = HitPoints.ToString();
	}

    private void AliveOrNot()
    {
        if(HitPoints<=0)
        {
            GameObject playerExpl = Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(playerExpl, 1f);
            Destroy(gameObject);
            sceneLoader.GameOver();
            
        }
    }

    public void AddScore(float enemyScore)
    {
        score += enemyScore;
    }

    /*
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")||Input.GetMouseButtonDown(0)) 
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
            GameObject laserZ = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            laserZ.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);
            yield return new WaitForSeconds(fireRate);
            
        }
    } */

    private void restrictVertical()
    {
        float restrictVertical = Mathf.Clamp(transform.position.y, -5f, 5f);
        transform.position = new Vector3(transform.position.x, restrictVertical, transform.position.z);
    }

    private void restrictHorizontal()
    {
        float restrictHorizontal = Mathf.Clamp(transform.position.x, -2.8f, 2.8f);
        transform.position = new Vector3(restrictHorizontal, transform.position.y,transform.position.z);
    }



    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * setSpeed * Time.deltaTime; ;
        var deltaY = Input.GetAxis("Vertical") * setSpeed * Time.deltaTime;
        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;
        transform.position = new Vector3(newXPos,newYPos,transform.position.z);           
    }

    public int GetPlayerDamage()
    {
        return playerDamage;
    }

    public void takeDamage(float damage)
    {
        HitPoints -= damage;
    }
}
