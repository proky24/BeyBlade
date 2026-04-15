using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "Game";
    [SerializeField]
    private string shopSceneName = "Shop";
    [SerializeField]
    private string mainMenuSceneName = "MainMenu";
    public void PlayGame()
    {
        LoadSceneStatic.SceneName = gameSceneName;
        SceneManager.LoadScene("LoadingScreen");
    }
    public void GoToShop()
    {
        LoadSceneStatic.SceneName = shopSceneName;
        SceneManager.LoadScene("LoadingScreen");
    }
    public void GoToMainMenu()
    {
        LoadSceneStatic.SceneName = mainMenuSceneName;
        SceneManager.LoadScene("LoadingScreen");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
