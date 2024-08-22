using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInstance : MonoBehaviour
{
    private MenuUI _menuUI;
    private Score _score;

    private MenuStateMachine _menuStateMachine;

    private void Awake()
    {
        DefineComponents();
        _menuStateMachine.Enter<LoadMenuState>();
    }

    public void PlayGame()
    {
        if (_menuStateMachine.currentTypeOfState == typeof(ReadyMenuState)) SceneManager.LoadScene("Game");
    }

    private void DefineComponents()
    {
        _menuUI = FindObjectOfType<MenuUI>();
        _score = GetComponent<Score>();
        _menuStateMachine = new MenuStateMachine(this, _menuUI, _score);
    }
}
