using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
// video: https://www.youtube.com/watch?v=7T-MTo8Uaio 


public class WaveSystem : MonoBehaviour
{

    [Header("points")]
    public int maxWavePoints;
    private int wavePoints;
    public int waveNumber = 0;
    private int maxEnemyCost = 1;
    public float numberOfEnemys = 0;
    public bool waveActive = false;
    private float currentTime;
    [Header("time")]
    public float timeBetwenSpawn;
    [SerializeField] private List<GameObject> deactivateDuringWave = new List<GameObject>();
    [Header("enemies")]
    [SerializeField] private List<BadGuy> enemys = new List<BadGuy>();
    [SerializeField] private List<GameObject> createdWave = new List<GameObject>();
    public void StartWave()//starts the wave
    {
        if (!waveActive)
        {
            for (int i = 0; i < deactivateDuringWave.Count; i++)
            {
                deactivateDuringWave[i].SetActive(false);

            }
            waveActive = true;
            CreateWave();
            StartCoroutine(spawnWave());
        }
        
    }
    public void UpdateWaveSpeed(float speed)
    {
        Time.timeScale = speed;
    }
    public void RemoveEnemy(GameObject enemie)
    {
        //remove the enemy for the creaedwave list did not seem to work s
        numberOfEnemys--;
        if(numberOfEnemys == 0)
        {
            EndWave();
        }
    }
    void CreateWave()
    {
        wavePoints = maxWavePoints;
        int randomEnemy;
        while (wavePoints > 0)
        {
            if(waveNumber > 0)
            {
                 randomEnemy = Random.Range(0, enemys.Count);
            }
            else
            {
                randomEnemy = 0;
            }
            int randomEnemyCost = enemys[randomEnemy].cost;
            if (wavePoints - randomEnemyCost >= 0)
            {
                createdWave.Add(enemys[randomEnemy].gameObject);
                wavePoints -= randomEnemyCost;
            }
            else if (wavePoints <= 0)
            {
                break;
            }

        }
    }
    IEnumerator spawnWave()
    {
      numberOfEnemys = createdWave.Count;
      for (int i = 0; i < createdWave.Count; i++)
      {
            Instantiate(createdWave[i], transform.position, transform.rotation);
            yield return new WaitForSeconds(1.5f);

      }
      yield return null;
    }
    public void EndWave()
    {
        waveActive = false;
        //add cash to player
        waveNumber++;
        //upaded the maxWavePoints
        maxWavePoints = UpdateWavepoints();
        for (int i = 0; i < deactivateDuringWave.Count; i++)
        {

            deactivateDuringWave[i].SetActive(true);

        }
        switch (waveNumber)
        {
            case 2:
                maxEnemyCost = 2;
                return;
        }
    }
    int UpdateWavepoints()// make the number if wave points bigger
    {
        return Mathf.RoundToInt( maxWavePoints * 1.2f );
    }
}
