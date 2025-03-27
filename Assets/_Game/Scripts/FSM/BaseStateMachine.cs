using UnityEngine;

namespace TB_RPG_2D.FSM
{
    public abstract class BaseStateMachine<T> : MonoBehaviour where T : BaseStateMachine<T>
    {
        private BaseState<T> _currentState;
        
        public void ChangeState(BaseState<T> newState)
        {
            if (newState == null)
            {
                Debug.Log("Attempted to change state to null.");
                return;
            }
            
            if (_currentState != null && _currentState.GetType() == newState.GetType())
            {
                Debug.Log("Attempted to change state to the same state: " + newState.GetType().Name);
                return;
            }
            
            _currentState?.Exit();
            
            _currentState = newState;
            Debug.Log($"New State is {_currentState.GetType().Name}");
            
            _currentState.Enter();
            
            OnStateUpdate(newState);
        }
        
        protected virtual void OnStateUpdate(BaseState<T> newState)
        {
        }
    }
}