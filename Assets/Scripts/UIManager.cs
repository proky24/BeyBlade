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
        SceneManager.LoadScene(gameSceneName);
    }
    public void GoToShop()
    {
        SceneManager.LoadScene(shopSceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
