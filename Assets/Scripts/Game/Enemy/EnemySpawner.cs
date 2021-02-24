using System;
using System.Collections.Generic;
using Game.Enemy.StateMachine.States;
using Game.Enemy.StateMachine.Transitions;
using Game.Player;
using Game.StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private List<Wave> _waves;

        private int _waveNumber;
        private int _currentWaveNumber;
        private float _timeAfterLastSpawn;
        private int _spawnedEnemyCount;
        private int _diedEnemyCount;

        private PlayerHealth _playerHealth;
        private PlayerWallet _playerWallet;
        private Wave _currentWave;

        public event Action AllEnemyOnWaySpawned;
        public event Action AllEnemyDied;
        public event Action<float, float> OnEnemyCountChanged;

        private void OnEnable()
        {
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void Update()
        {
            if (_currentWave == null)
                return;

            _timeAfterLastSpawn += Time.deltaTime;

            if (CanSpawn())
                Spawn();

            if (MaxEnemyPerWaveSpawned())
            {
                if (NextWaveExist())
                    AllEnemyOnWaySpawned?.Invoke();

                _currentWave = null;
            }
        }

        private void OnDisable()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
        }

        private void OnPlayerSpawned(GameObject player)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
            _playerWallet = player.GetComponent<PlayerWallet>();

            SetWave(_currentWaveNumber);
        }

        private void Spawn()
        {
            InstantiateEnemy();
            _spawnedEnemyCount++;
            _timeAfterLastSpawn = 0;
            OnEnemyCountChanged?.Invoke(_spawnedEnemyCount, _currentWave.EnemyCount);
        }

        private void InstantiateEnemy()
        {
            EnemyStaticData enemyStaticData = _currentWave.EnemyStaticData;

            GameObject enemy = Instantiate(enemyStaticData.EnemyPrefab, _currentWave.SpawnPoint.position,
                Quaternion.identity, _currentWave.SpawnPoint);

            float transitionRange = TransitionRange(enemyStaticData);

            enemy.GetComponent<EnemyHealth>().Construct(enemyStaticData);

            enemy.GetComponent<EnemyTargetDiedTransition>().Construct(_playerHealth);
            enemy.GetComponent<EnemyAttackTransition>().Construct(_playerHealth, transitionRange);
            enemy.GetComponent<EnemyMoveTransition>().Construct(_playerHealth, transitionRange);

            enemy.GetComponent<EnemyDeathState>().Construct(enemyStaticData);
            enemy.GetComponent<EnemyMoveState>().Construct(_playerHealth.transform, enemyStaticData);
            enemy.GetComponent<EnemyAttackState>().Construct(_playerHealth, enemyStaticData);
            enemy.GetComponent<EnemyDeathState>().OnDied += OnEnemyDied;
        }

        private float TransitionRange(EnemyStaticData enemyStaticData)
        {
            float transitionRange = enemyStaticData.TransitionRange;
            float rangedSpread = enemyStaticData.RangeSpread;
            transitionRange += Random.Range(-rangedSpread, rangedSpread);
            return transitionRange;
        }

        private void OnEnemyDied(EnemyDeathState enemyDeathState)
        {
            enemyDeathState.OnDied -= OnEnemyDied;
            _playerWallet.AddMoney(_waves[_currentWaveNumber].EnemyStaticData.Reward);
            _diedEnemyCount++;

            if (_diedEnemyCount == _spawnedEnemyCount && !NextWaveExist())
                AllEnemyDied?.Invoke();
        }

        public void NextWave()
        {
            SetWave(++_currentWaveNumber);
            _spawnedEnemyCount = 0;
            _diedEnemyCount = 0;
        }

        private void SetWave(int index)
        {
            _currentWave = _waves[index];
            OnEnemyCountChanged?.Invoke(0, 1);
        }

        private bool CanSpawn()
        {
            return _timeAfterLastSpawn >= _currentWave.Delay && _playerHealth.IsAlive;
        }

        private bool MaxEnemyPerWaveSpawned()
        {
            return _spawnedEnemyCount >= _currentWave.EnemyCount;
        }

        private bool NextWaveExist()
        {
            return _waves.Count > _currentWaveNumber + 1;
        }
    }
}