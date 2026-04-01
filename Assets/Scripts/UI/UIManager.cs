using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    [SerializeField]
    private string shopSceneName;
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
    public void Exit()
    {
        Application.Quit();
    }
}
