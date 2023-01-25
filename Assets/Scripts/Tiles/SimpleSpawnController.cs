using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using EventWork;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SimpleSpawnController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _tilesList;
        [SerializeField] private List<SimpleTilesSpawner> _spawnPoints;

        private void Awake()
        {
            CheckSpawnPoint();
            GameEventSystem.OnCheckStartSpawn += CheckSpawnPoint;
        }

        private void OnDestroy()
        {
            GameEventSystem.OnCheckStartSpawn -= CheckSpawnPoint;
        }

        public void CheckSpawnPoint()
        {
            
            //bool needSpawn = _spawnPoints.TrueForAll(spawn => spawn.NeedSpawn);
            bool needSpawn = _spawnPoints.All(b => b.NeedSpawn);

            //Debug.Log(needSpawn);
            if (needSpawn)
            {
                foreach (SimpleTilesSpawner spawnPoint in _spawnPoints)
                {
                    SpawnRandomTile(spawnPoint.transform);
                    spawnPoint.NeedSpawn = false;
                }
            }
        }
        
        
        public void SpawnRandomTile(Transform parent)
        {
            GameObject tile = _tilesList[Random.Range(0, _tilesList.Count)];
            Instantiate(tile, parent);
        }
    }
}