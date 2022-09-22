using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public enum GameState { NullState, MainMenu, Game }
public delegate void OnStateChangeHandler();

public class GameManager
{
    protected GameManager() { }
    static GameManager _instance = null;
    public GameState gameState { get; private set; }
    public event OnStateChangeHandler OnStateChange;
    public static GameManager Instance
    {
        get
        {
            if (GameManager._instance == null)
            {
                GameManager._instance = new GameManager();
            }
            return GameManager._instance;
        }
    }
    public void SetGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.NullState:
                break;
            case GameState.Game:
                SceneManager.LoadScene("Map1");
                break;
            case GameState.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
        this.gameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }
}
