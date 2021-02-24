using Game.StaticData;
using UnityEngine;

namespace Game.Weapons
{
    public abstract class MeleeWeapon : Weapon
    {
        private const string EnemyLayerName = "Enemy";
        
        [SerializeField] protected MeleeWeaponStaticData _weaponData;
        
        protected float Radius;
        protected float Damage;
        
        protected static int LayerMask;
        protected Collider2D[] Hits;
        
        public override void Construct()
        {
            TypeId = _weaponData.TypeId;
            Price = _weaponData.Price;
            Icon = _weaponData.Icon;
            DelayBetweenAttack = _weaponData.DelayBetweenAttack;
            Hits = new Collider2D[_weaponData.Targets - 1];
            Radius = _weaponData.Radius;
            Damage = _weaponData.Damage;

            LayerMask = 1 << UnityEngine.LayerMask.NameToLayer(EnemyLayerName);
        }
    }
}