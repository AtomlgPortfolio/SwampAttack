using Game.Bullets;
using UnityEngine;

namespace Game.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Weapon Static Data/Ranged Weapon Static Data", fileName = "RangedWeaponData")]
    public class RangedWeaponStaticData : WeaponStaticData
    {
        [SerializeField] private Bullet _bullet;
        public Bullet Bullet => _bullet;
    }
}