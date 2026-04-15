using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private Transform playerSpawnpoint;
    [SerializeField]
    private Transform enemySpawnpoint;
    [SerializeField]
    private RatingManager ratingManager;
    [Header("Camera")]
    [SerializeField]
    private ScreenShaker screenShaker;
    [SerializeField]
    private CameraMovement cameraMovement;
    private GameObject player;
    private GameObject enemy;
    private bool playerWon = false;
    public bool PlayerWon { get { return playerWon; } }
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        SpawnBeyblades();
    }
    private void SpawnBeyblades()
    {
        ratingManager.HideRatings();
        playerWon = false;
        player = Instantiate(playerPrefab, playerSpawnpoint.position, Quaternion.identity);
        cameraMovement.Target = player.transform;
        enemy = Instantiate(enemyPrefabs[GetRandomEnemy()], enemySpawnpoint.position, Quaternion.identity);
        List<DamagerModule> damagers = new List<DamagerModule>();
        screenShaker.AddOnHit(player.GetComponentInChildren<DamagerModule>());
        screenShaker.AddOnHit(enemy.GetComponentInChildren<DamagerModule>());
        player.GetComponent<HealthModule>().onDeath += OnPlayerDeath;
        enemy.GetComponent<HealthModule>().onDeath += OnEnemyDeath;
        enemy.GetComponent<EnemyMovement>().SetTarget(player);
        ratingManager.StartTimer();
    }
    private int GetRandomEnemy()
    {
        return Random.Range(0, enemyPrefabs.Length);
    }
    private void OnPlayerDeath()
    {
        player.GetComponent<HealthModule>().onDeath -= OnPlayerDeath;
        screenShaker.RemoveOnHit(player.GetComponent<DamagerModule>());
        StartCoroutine(WhoWon("Enemy"));
    }
    private void OnEnemyDeath()
    {
        enemy.GetComponent<HealthModule>().onDeath -= OnEnemyDeath;
        screenShaker.RemoveOnHit(enemy.GetComponent<DamagerModule>());
        playerWon = true;
        StartCoroutine(WhoWon("Player"));
    }
    private IEnumerator WhoWon(string name)
    {
        Debug.Log($"{name} wins!!!");
        ratingManager.StopTimer();
        yield return new WaitForSeconds(3f);
        ratingManager.ShowRatings();
        KillBeyblades();
    }
    private void KillBeyblades()
    {
        if (player != null)
            Destroy(player);

        if (enemy != null)
            Destroy(enemy);
    }
}