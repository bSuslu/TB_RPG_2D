namespace TB_RPG_2D.FSM
{
    public abstract class BaseState<T>
    {
        protected T _stateMachine;

        protected BaseState(T stateMachine)
        {
            _stateMachine = stateMachine;
        }


        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}