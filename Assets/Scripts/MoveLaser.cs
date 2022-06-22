using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour {
    Rigidbody2D laser;
    public float fireSpeed = -10f;
    EnemyStats enemyStats;
    Player player;
	// Use this for initialization
	void Start () {
        laser = GetComponent<Rigidbody2D>();
        enemyStats = FindObjectOfType<EnemyStats>();
        player = FindObjectOfType<Player>();
	}

    private void Update()
    {
        laser.velocity = new Vector2(0, fireSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.takeDamage(enemyStats.GetEnemyDamage());
        }
    }

}
