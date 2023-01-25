using System;
using System.Collections.Generic;

namespace GameStateMachine
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _states;

        public StateMachine()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(StartPointState)] = new StartPointState(),
                [typeof(LoadResourcesState)] = new LoadResourcesState(),
            };
        }
    }
}