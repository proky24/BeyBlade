using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RatingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ratingsUI;
    [SerializeField]
    private TMP_Text pointsLabel;
    [SerializeField]
    private Image goldMedal;
    [SerializeField]
    private Image silverMedal;
    [SerializeField]
    private Image bronzeMedal;
    [SerializeField]
    private GameController gameController;
    private float timer = 0;
    public float Timer { get { return timer; } }
    private void Start()
    {
        HideRatings();
    }
    public void StartTimer()
    {
        StartCoroutine(TimerCoroutine());
    }
    public void StopTimer()
    {
        StopCoroutine(TimerCoroutine());
    }
    public void ShowRatings()
    {
        ratingsUI.gameObject.SetActive(true);

        int points = 0;

        if (gameController.PlayerWon == true)
        {
            points = GetPoints(timer);
            PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points", 0) + points);
        }

        ColorTrophiesAccordingly(points);

        pointsLabel.text = $"{points} POINTS";
    }
    private void ColorTrophiesAccordingly(int points)
    {
        if (points >= 3)
        {
            goldMedal.color = Color.gold;
            silverMedal.color = Color.silver;
            bronzeMedal.color = Color.brown;
        }

        if (points == 2)
        {
            goldMedal.color = Color.grey;
            silverMedal.color = Color.silver;
            bronzeMedal.color = Color.brown;
        }

        if (points == 1)
        {
            goldMedal.color = Color.grey;
            silverMedal.color = Color.grey;
            bronzeMedal.color = Color.brown;
        }

        if (points <= 0)
        {
            goldMedal.color = Color.grey;
            silverMedal.color = Color.grey;
            bronzeMedal.color = Color.grey;
        }
    }
    public void HideRatings()
    {
        ratingsUI.gameObject.SetActive(false);
    }
    private int GetPoints(float time)
    {
        if (time < 30)
        {
            return 3;
        }
        else if (time < 60)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
    public void BackToMenu()
    {
        LoadSceneStatic.SceneName = "MainMenu";
        SceneManager.LoadScene("LoadingScreen");
    }
    private IEnumerator TimerCoroutine()
    {
        timer += Time.deltaTime;
        yield return null;
    }
}