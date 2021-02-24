using System;
using Game.Player.Animation;
using Game.StaticData;
using UnityEngine;

namespace Game.Player
{
   public class PlayerSpawner : MonoBehaviour
   {
      [SerializeField] private PlayerStaticData _playerData;
      [SerializeField] private Transform _point;
      
      public event Action<GameObject> PlayerSpawned;

      private void Start()
      {
         GameObject player = Instantiate(_playerData.Prefab, _point.position, Quaternion.identity);
         player.GetComponent<PlayerWeapons>().Current.Construct();
         player.GetComponent<PlayerAnimator>().Construct();
         PlayerSpawned?.Invoke(player);
      }
   }
}
