using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TheSummitCombat
{

    [System.Serializable]
    public class WaveComp
    {
        public GameObject enemyPrefab;
        public int amountOfEnemies;
        [HideInInspector] public int leftToSpawn;

        public void Initialize()
        {
            leftToSpawn = amountOfEnemies;
        }
    }
}
