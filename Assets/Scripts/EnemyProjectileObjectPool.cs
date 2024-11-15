using System.Collections.Generic;
using UnityEngine;

namespace TheSummitCombat
{
    public class EnemyProjectileObjectPool : MonoBehaviour
    {
        public static EnemyProjectileObjectPool SharedInstance;
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        private void Awake()
        {
            SharedInstance = this;
        }

        private void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            return null;
        }
    }
}
