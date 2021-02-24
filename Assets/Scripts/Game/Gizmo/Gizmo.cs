using UnityEngine;

namespace Game.Gizmo
{
    public class Gizmo : MonoBehaviour 
    {
        private const float Radius = 0.1f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position,Radius);
        }
    }
}