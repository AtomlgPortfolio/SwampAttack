using UnityEngine;

namespace Game.Enemy.StateMachine
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _startState;
        
        private State _currentState;

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            if(_currentState == null)
                return;

            State nextState = _currentState.GetNext();
            if (nextState != null)
                Transit(nextState);
        }

        private void Reset()
        {
            _currentState = _startState;
            _currentState?.Enter();
        }

        private void Transit(State nextState)
        {
            _currentState?.Exit();
            _currentState = nextState;
            _currentState?.Enter();
        }
    }
}