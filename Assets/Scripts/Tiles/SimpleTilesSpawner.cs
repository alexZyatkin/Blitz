using System;
using System.Collections.Generic;
using EventWork;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleTilesSpawner : MonoBehaviour
    {
        public bool NeedSpawn;

        private void Awake()
        {
            GameEventSystem.OnSpawnPointEmpty += SetNeedSpawn;
        }

        private void OnDestroy()
        {
            GameEventSystem.OnSpawnPointEmpty -= SetNeedSpawn;
        }

        private void SetNeedSpawn()
        {
            if(transform.childCount == 0)
                NeedSpawn = true;
        }
    }
}