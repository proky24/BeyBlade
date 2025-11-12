using System.Collections;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [Header("Body/Komponenty")]
    [SerializeField] private GameObject body;
    [SerializeField] private Rigidbody rb;
    [Header("Vlastnosti")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float degreesPerSec = 360f;
    [SerializeField] private float power = 1f;
    [SerializeField] private float timer = 2f;
    [SerializeField] private float maxTimer = 2f;
    [SerializeField] private float timerGainMultiplier = 1f;
    [Header("Cíl")]
    [SerializeField] private GameObject player;
    private SpinMode spinMode = SpinMode.NotSpinning;
    public SpinMode SpinMode { get { return spinMode; } }
    private void Update()
    {
        timer -= Time.deltaTime * timerGainMultiplier;

       if (timer <= 0f)
       {
            Vector3 playerPos = player.transform.position;
            Vector3 direction = (new Vector3(playerPos.x, 0, playerPos.z) - rb.position).normalized;
            StartCoroutine(SpinAndMove(degreesPerSec, power, direction));
            timer = maxTimer;
       }
    }
    public bool IsSpinning()
    {
        return (spinMode == SpinMode.Spinning) ? true : false;
    }
    private IEnumerator SpinAndMove(float rotationSpeed, float currentPower, Vector3 direction)
    {
        spinMode = SpinMode.Spinning;
        var duration = currentPower;
        var elapsed = 0f;

        while (elapsed < duration)
        {
            //rotaci by nejspis mela delat animace
            body.transform.Rotate(Vector3.up, rotationSpeed * (duration - elapsed) * Time.deltaTime, Space.Self);
            elapsed += Time.deltaTime;
            MoveTowards(direction);
            yield return null;
        }

        spinMode = SpinMode.NotSpinning;
        yield return null;
    }
    private void MoveTowards(Vector3 positionToMoveTowards)
    {
        rb.linearVelocity = positionToMoveTowards * movementSpeed;
    }
}