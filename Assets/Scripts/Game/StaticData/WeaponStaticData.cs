using UnityEngine;

namespace Game.StaticData
{
    
    public class WeaponStaticData : ScriptableObject
    {
        [SerializeField] private WeaponTypeId typeId;
        [SerializeField] private int _price;
        [SerializeField] private float _delayBetweenAttack;
        [SerializeField] private Sprite _icon;

        public WeaponTypeId TypeId => typeId;
        public int Price => _price;
        public float DelayBetweenAttack => _delayBetweenAttack;
        public Sprite Icon => _icon;
    }
}