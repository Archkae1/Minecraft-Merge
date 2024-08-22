using System.Collections.Generic;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class MenuStateMachine
{
    private Dictionary<Type, IMenuState> states;
    private IMenuState currentState;
    private Type _currentTypeOfState;

    public Type currentTypeOfState { get { return _currentTypeOfState; } }

    public MenuStateMachine(MenuInstance menuInstance, MenuUI menuUI, Score score)
    {
        states = new Dictionary<Type, IMenuState>()
        {
            [typeof(LoadMenuState)] = new LoadMenuState(menuInstance, this, menuUI, score),
            [typeof(ReadyMenuState)] = new ReadyMenuState()
        };
    }

    public void Enter<TState>() where TState : IMenuState
    {
        if (states.TryGetValue(typeof(TState), out IMenuState state))
        {
            currentState?.Exit();
            currentState = state;
            _currentTypeOfState = typeof(TState);
            currentState.Enter();
        }
    }
}