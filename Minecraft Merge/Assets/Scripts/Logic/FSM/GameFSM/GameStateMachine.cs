using System.Collections.Generic;
using System;

public class GameStateMachine
{
    private Dictionary<Type, IGameState> states;
    private IGameState currentState;
    private Type _currentTypeOfState;

    public Type currentTypeOfState { get { return _currentTypeOfState; } }

    public GameStateMachine(GameInstance gameInstance, GameInstanceView gameInstanceView, PlayerController playerController, GameUI gameUI, Score score, ScoreData scoreData)
    {
        states = new Dictionary<Type, IGameState>()
        {
            [typeof(LoadGameState)] = new LoadGameState(gameInstance, gameInstanceView, this, playerController, gameUI, score, scoreData),
            [typeof(PlayGameState)] = new PlayGameState(playerController, gameInstanceView),
            [typeof(PauseGameState)] = new PauseGameState(gameUI),
            [typeof(EndGameState)] = new EndGameState(gameUI, gameInstanceView)
        };
    }

    public void Enter<TState>() where TState : IGameState
    {
        if (states.TryGetValue(typeof(TState), out IGameState state))
        {
            currentState?.Exit();
            currentState = state;
            _currentTypeOfState = typeof(TState);
            currentState.Enter();
        }
    }
}