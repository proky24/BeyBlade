using UnityEngine;

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
    private void Start()
    {
        
    }
}
