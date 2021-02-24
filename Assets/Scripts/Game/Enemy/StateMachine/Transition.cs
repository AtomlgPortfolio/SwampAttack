using UnityEngine;

namespace Game.Enemy.StateMachine
{
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] private State _nextState;
        public State NextState => _nextState;
        public bool NeedTransit { get; protected set; }
        
        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            NeedTransit = false;
            enabled = false;
        }
    }
}