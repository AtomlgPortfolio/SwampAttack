using System;
using Game.StaticData;
using UnityEngine;

namespace Game.Enemy
{
    [Serializable]
    public class Wave
    {
        public EnemyStaticData EnemyStaticData;
        public Transform SpawnPoint;
        public float Delay;
        public int EnemyCount;
    }
}