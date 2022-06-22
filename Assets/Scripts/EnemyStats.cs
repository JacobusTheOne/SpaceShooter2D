using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    public int enemyHitPoints = 100;
    public int enemyScorePoints = 10;
    public float enemyDamage = 20f;
    public Sprite enemySpriteShot;
    public Sprite enemySprite;
    Player player;
    SpriteRenderer spriteRenderer;
    AudioSource audioDamage;
    public AudioClip audioClip;
    [SerializeField] GameObject explosion;
    
  

    int hitCount;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioDamage = GetComponent<AudioSource>();
        

    }

  

    public float GetEnemyDamage()
    {
        return enemyDamage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((gameObject.tag != "Enemy")||(collision.gameObject.tag != "Enemy"))
        {
            //audioDamage.PlayOneShot(audioClip);
            StartCoroutine(ShotAffordance());
            enemyHitPoints -= player.GetPlayerDamage();
            if (enemyHitPoints <= 0)
            {
                player.AddScore(enemyScorePoints);
                Destroy(gameObject);

                GameObject theExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(theExplosion, 1f);
            }
                Destroy(collision.gameObject);
            
        }
    }

    IEnumerator ShotAffordance()
    {
        spriteRenderer.sprite = enemySpriteShot;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = enemySprite;

    }
    
}
