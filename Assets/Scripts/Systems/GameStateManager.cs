using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public enum GameState
{
    None, 
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Settings,
    GameOver
}








public class GameStateManager : MonoBehaviour
{
    private ServiceHub serviceHub;
    private UiManager uiManger;

    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }


    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;
        uiManger = serviceHub.UiManager;
        


        SetState(GameState.Init);
    }

    public void SetState(GameState state)
    {

        if(currentState == state) return;

        previousState = currentState;
        currentState = state;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();



        OnGameStateChanged(previousState, currentState);

    }
    private void OnGameStateChanged(GameState previousState, GameState currentState)
    {
        switch (currentState)
        {


            case GameState.None:

                Debug.Log("this should never come up");
                break;

            case GameState.Init:

                Debug.Log("this is init");
                Time.timeScale = 1;

                SetState(GameState.MainMenu);

                break;


            case GameState.MainMenu:
                Time.timeScale = 1;
                uiManger.ShowMainMenu();
                Debug.Log("This is main menu");
                break;

            case GameState.Gameplay:
                Time.timeScale = 1;
                uiManger.ShowGamePlayUI();
                Debug.Log("this is gameplay");
                break;

            case GameState.Paused:
                Time.timeScale = 0;
                uiManger.ShowPauseMenuUI();

                break;

            case GameState.Settings:
                Time.timeScale = 0;
                uiManger.ShowSettingsMenuUI();
                break;

            case GameState.GameOver:
                Time.timeScale = 0;
                uiManger.ShowGameOverUI();
                break;
            

            default:
                Time.timeScale = 1;
                break;
        }

           
    }

    private void Update()
    {

    }

    //button Logic

    public void StartGame()
    {
        SetState(GameState.Gameplay);
    }

    public void TogglePause()
    {
        if(currentState == GameState.Paused)
        {
            if (currentState == GameState.Gameplay) return;


            SetState(GameState.Gameplay);
        }

        else if(currentState == GameState.Gameplay)
        {

            if (currentState == GameState.Paused) return;
            SetState(GameState.Paused);
        }
    }

    public void UnPause()
    {
        SetState(GameState.Gameplay);
    }

    public void MainMenu()
    {
        SetState(GameState.MainMenu);
    }

    public void Settings()
    {
        SetState(GameState.Settings);
    }

    public void ToggleGameOver()
    {
        if (currentState == GameState.Gameplay)
        {

            SetState(GameState.GameOver);
        }
        else return;
    }

}
