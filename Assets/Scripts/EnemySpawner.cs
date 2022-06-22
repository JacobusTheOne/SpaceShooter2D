using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;


    int startingWave = 0;
    public float waitBetweenWaves = 5.5f;
    WaveConfig currentWave;

	// Use this for initialization
	IEnumerator Start () {
        do
        {

            yield return StartCoroutine(SpawnAllWaves());
            //StartCoroutine(WaitBetweenWaves());
        }
        while (looping);
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count;waveIndex++)
        {
            currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetSpawnTime());
            
        }
    }

    private IEnumerator WaitBetweenWaves()
    {
        for (int i = 0; i < waveConfigs.Count; i++)
        {
            yield return new WaitForSeconds(waitBetweenWaves);
            if (startingWave < waveConfigs.Count)
            {
                startingWave++;
                if (startingWave == waveConfigs.Count) 
                {
                    break;
                }
                currentWave = waveConfigs[startingWave];
                StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
        }
    }
	
}
