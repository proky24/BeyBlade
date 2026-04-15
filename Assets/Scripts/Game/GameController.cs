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
    [Header("Camera")]
    [SerializeField]
    private ScreenShaker screenShaker;
    [SerializeField]
    private CameraMovement cameraMovement;
    private GameObject player;
    private GameObject enemy;
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
        player = Instantiate(playerPrefab, playerSpawnpoint.position, Quaternion.identity);
        cameraMovement.Target = player.transform;
        enemy = Instantiate(enemyPrefabs[GetRandomEnemy()], enemySpawnpoint.position, Quaternion.identity);
        List<DamagerModule> damagers = new List<DamagerModule>();
        screenShaker.AddOnHit(player.GetComponentInChildren<DamagerModule>());
        screenShaker.AddOnHit(enemy.GetComponentInChildren<DamagerModule>());
        player.GetComponent<HealthModule>().onDeath += OnPlayerDeath;
        enemy.GetComponent<HealthModule>().onDeath += OnEnemyDeath;
        enemy.GetComponent<EnemyMovement>().SetTarget(player);
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
        StartCoroutine(WhoWon("Player"));
    }
    private IEnumerator WhoWon(string name)
    {
        Debug.Log($"{name} wins!!!");
        yield return new WaitForSeconds(5f);
        KillBeyblades();
        LoadSceneStatic.SceneName = "MainMenu";
        SceneManager.LoadScene("LoadingScreen");
    }
    private void KillBeyblades()
    {
        if (player != null)
            Destroy(player);

        if (enemy != null)
            Destroy(enemy);
    }
}