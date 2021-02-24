using UnityEngine;

namespace Game.Weapons
{
    public class Shotgun: RangedWeapon 
    {

        public override void Attack()
        {
            Instantiate(Bullet, AttackPoint.position, Quaternion.identity);
            
        }
        
    }
}