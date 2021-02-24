using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Enemy.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;

        protected EnemyAnimator EnemyAnimator;

        private void Awake()
        {
            EnemyAnimator = GetComponent<EnemyAnimator>();
        }

        public virtual void Enter()
        {
            enabled = true;
            EnableTransitions();
        }

        public virtual void Exit()
        {
            DisableTransitions();
            enabled = false;
        }

        private void DisableTransitions()
        {
            foreach (Transition transition in _transitions)
                transition.Disable();
        }

        protected void EnableTransitions()
        {
            foreach (Transition transition in _transitions)
                transition.Enable();
        }

        public State GetNext()
        {
            return _transitions.Where(x => x.NeedTransit).Select(x => x.NextState).FirstOrDefault();
        }
    }
}