using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject settingsMenuUI;
    [SerializeField] GameObject gameOverUI;


    public void ShowMainMenu()
    {
        HideAllMenus();
        mainMenuUI.SetActive(true);
        
       
        Debug.Log("UIManager: ShowMainMenuUI Called");
    }

    public void ShowGamePlayUI()
    {
        HideAllMenus();
        gameplayUI.SetActive(true);
        Debug.Log("UIManager: ShowGameplayUI Called");
    }

    public void ShowPauseMenuUI()
    {
        HideAllMenus();
        pauseMenuUI.SetActive(true);
        gameplayUI.SetActive(true);
        Debug.Log("UIManager: ShowPauseMenuuUI Called");
    }

    public void ShowSettingsMenuUI()
    {
        HideAllMenus();
        settingsMenuUI.SetActive(true);
    }
    public void ShowGameOverUI()
    {
        HideAllMenus();
       
        gameOverUI.SetActive(true);
    }

    public void HideAllMenus()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        
    }
}
