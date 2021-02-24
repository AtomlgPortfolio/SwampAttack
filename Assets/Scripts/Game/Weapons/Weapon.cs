using Game.StaticData;
using UnityEngine;

namespace Game.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform AttackPoint;

        public WeaponTypeId TypeId { get; protected set; }
        public float DelayBetweenAttack { get; protected set; }
        public int Price { get; protected set; }
        public Sprite Icon { get; protected set; }

        public abstract void Attack();

        public abstract void Construct();
    }
}