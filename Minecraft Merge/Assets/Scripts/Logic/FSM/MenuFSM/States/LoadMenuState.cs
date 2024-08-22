using System.Collections;
using UnityEngine;
using YG;

public class LoadMenuState : IMenuState
{
    private MenuInstance _menuInstance;
    private MenuStateMachine _menuStateMachine;
    private MenuUI _menuUI;
    private Score _score;

    public LoadMenuState(MenuInstance menuInstance, MenuStateMachine menuStateMachine, MenuUI menuUI, Score score)
    {
        _menuInstance = menuInstance;
        _menuStateMachine = menuStateMachine;
        _menuUI = menuUI;
        _score = score;
    }

    public void Enter()
    {
        _menuInstance.StartCoroutine(LoadAsync());
    }

    public void Exit()
    {

    }

    private IEnumerator LoadAsync()
    {
        yield return new WaitUntil(() => YandexGame.SDKEnabled);
        _score.Load();
        _menuUI.Load(_score);
        _menuStateMachine.Enter<ReadyMenuState>();
    }
}
