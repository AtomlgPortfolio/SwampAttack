using Game.Enemy;
using UnityEngine;

namespace Game.Weapons
{
    public class Axe : MeleeWeapon
    {
        public override void Attack()
        {
            int hits = Physics2D.OverlapCircleNonAlloc(AttackPoint.position, Radius, Hits, LayerMask);
            for (var i = 0; i < hits; i++) 
                Hits[i].GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
    }
}