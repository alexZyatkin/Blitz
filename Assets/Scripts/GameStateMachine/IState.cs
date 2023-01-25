namespace GameStateMachine
{
    internal interface IState
    {
        void Enter();
        void Exit();
    }
}