using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace TheSummitCombat
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<WaveComp> waveComps;
        public float spawnInterval;
    }

    public class EnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] Wave[] waves;
        [SerializeField] Transform[] spawnPoints;

        private Wave currentWave;
        private int currentWaveNumber;
        private float nextSpawnTime;

        private bool canSpawn = true;

        [SerializeField] TMP_Text waveNumber;

        private void Start()
        {
            currentWave = waves[currentWaveNumber];
            InitialiseWave();
        }

        private void Update()
        {
            UpdateUI();

            if (canSpawn && nextSpawnTime < Time.time)
            {
                SpawnWave();
            }

            GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 < waves.Length)
            {
                SpawnNextWave();
            }
        }

        void InitialiseWave()
        {
            foreach (WaveComp waveComp in currentWave.waveComps)
            {
                waveComp.Initialize();
            }
        }

        void SpawnNextWave()
        {
            currentWaveNumber++;
            currentWave = waves[currentWaveNumber];
            InitialiseWave();
            canSpawn = true;
        }

        void SpawnWave()
        {
            foreach (WaveComp waveComp in currentWave.waveComps)
            {
                if (waveComp.leftToSpawn > 0 && nextSpawnTime < Time.time)
                {
                    Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    Instantiate(waveComp.enemyPrefab, randomPoint.position, Quaternion.identity);

                    waveComp.leftToSpawn--;
                    nextSpawnTime = Time.time + currentWave.spawnInterval;

                    if (AllEnemiesSpawned())
                    {
                        canSpawn = false;
                    }

                    break;
                }
            }
        }

        bool AllEnemiesSpawned()
        {
            foreach (WaveComp waveComp in currentWave.waveComps)
            {
                if (waveComp.leftToSpawn > 0)
                {
                    return false;
                }
            }

            return true;
        }

        void UpdateUI()
        {
            waveNumber.text = "Wave: " + (currentWaveNumber + 1).ToString();
        }

    }
}
