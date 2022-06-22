using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public GameObject[] hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
   
    //public TextMeshProUGUI restartText;
    //public TextMeshProUGUI gameoverText;


    private bool gameOver;
    private bool restart;
    

    private void Start()
    {
        StartCoroutine (SpawnWaves());
        //restartText.text = "";
        //gameoverText.text = "";
        gameOver = false;
    }

    private void Update()
    {
        if(gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
               SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard[Random.Range(0,hazard.Length)], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }

    public void GameOver()
    {
        //gameoverText.text = "Game Over";
        //restartText.text = "Press 'R' to Restart";
        gameOver = true;
    }
}
