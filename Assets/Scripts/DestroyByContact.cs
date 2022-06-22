using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public int hitCount;
    public GameObject ateroidExplosion;
    public GameObject playerExplosion;
    PlayerController playerController;
    GameController gameController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary"||other.tag == "Enemy")
        {
            return;
        }
        if (ateroidExplosion != null)
        {
            Instantiate(ateroidExplosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        hitCount++;
        if (hitCount > 2)
        {
            Instantiate(ateroidExplosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            playerController.AddScore(100);
        }
    }
}
