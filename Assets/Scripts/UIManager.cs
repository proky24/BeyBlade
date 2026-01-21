using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
