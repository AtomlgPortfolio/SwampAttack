using Game.Bullets;
using Game.StaticData;
using UnityEngine;

namespace Game.Weapons
{
    public abstract class RangedWeapon : Weapon
    {
        [SerializeField] protected RangedWeaponStaticData _weaponData;
        
        protected Bullet Bullet;
        
        public override void Construct()
        {
            TypeId = _weaponData.TypeId;
            Price = _weaponData.Price;
            Icon = _weaponData.Icon;
            Bullet = _weaponData.Bullet;
            DelayBetweenAttack = _weaponData.DelayBetweenAttack;
        }
    }
}