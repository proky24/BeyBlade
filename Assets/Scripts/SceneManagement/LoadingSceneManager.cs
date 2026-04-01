using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private float labelDuration = 0.3f;
    [SerializeField] private Image bar;
    private void Start()
    {
        ChangeScene(LoadSceneStatic.SceneName);
    }
    public void ChangeScene(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(ChangeBar(ao));
        StartCoroutine(ChangeLabel(ao));
    }
    private IEnumerator ChangeBar(AsyncOperation ao)
    {
        while (ao.isDone == false)
        {
            ChangeBar(ao.progress);
            yield return null;
        }
    }
    private IEnumerator ChangeLabel(AsyncOperation ao)
    {
        int dots = 0;
        string labelText = "Loading";

        while (ao.isDone == false)
        {
            switch (dots)
            {
                case 0:
                    labelText = "Loading.";
                    break;
                case 1:
                    labelText = "Loading..";
                    break;
                case 2:
                    labelText = "Loading...";
                    break;
            }

            label.text = labelText;
            yield return new WaitForSeconds(labelDuration);
            dots++;

            if (dots >= 3)
                dots = 0;
        }
    }
    private void ChangeBar(float progress)
    {
        bar.fillAmount = progress;
    }
}
