using UnityEngine;

namespace Game.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Weapon Static Data/Melee Weapon Static Data", fileName = "MeleeWeaponData")]
    public class MeleeWeaponStaticData : WeaponStaticData
    {
        [SerializeField] private float _radius;
        [SerializeField] private int _targets;
        [SerializeField] private float _damage;

        public float Damage => _damage;
        public float Radius => _radius;
        public int Targets => _targets;
    }
}