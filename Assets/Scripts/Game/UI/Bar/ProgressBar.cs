using Game.Enemy;
using UnityEngine;

namespace Game.UI.Bar
{
    public class ProgressBar : Bar
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        private void OnEnable()
        {
            _enemySpawner.OnEnemyCountChanged += ValueChanged;
        }

        private void OnDisable()
        {
            _enemySpawner.OnEnemyCountChanged -= ValueChanged;
        }
    }
}