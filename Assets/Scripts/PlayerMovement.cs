using System.Collections;
using UnityEngine;
public enum SpinMode
{
    Spinning = 1,
    NotSpinning = 0
}
public class PlayerMovement : MonoBehaviour
{
    [Header("Body/Komponenty")] 
    [SerializeField] private GameObject body;
    [SerializeField] private Rigidbody rb;
    [Header("Vlastnosti")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float degreesPerSec = 360f;
    [SerializeField] private float power = 0f;
    [SerializeField] private float maxPower = 2f;
    [SerializeField] private float powerGainMultiplier = 1f;
    private SpinMode spinMode = SpinMode.NotSpinning;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && spinMode == SpinMode.NotSpinning)
        {
            power += Time.deltaTime * powerGainMultiplier;

            if (power > maxPower)
            {
                power = maxPower;
            }
        }
        else
        {
            if (power > 0f && spinMode == SpinMode.NotSpinning)
            {
                StartCoroutine(SpinAndMove(degreesPerSec, power, spinMode));
                power = 0f;
            }
        }
    }
    private IEnumerator SpinAndMove(float rotationSpeed, float currentPower, SpinMode playerSpinMode)
    {
        playerSpinMode = SpinMode.Spinning;
        var duration = currentPower;
        var elapsed = 0f;
        var screenPos = Input.mousePosition;
        screenPos.z = 20f;

        while (elapsed < duration)
        {
            //rotaci by nejspis mela delat animace
            body.transform.Rotate(Vector3.up, rotationSpeed * (duration - elapsed) * Time.deltaTime, Space.Self);
            elapsed += Time.deltaTime;
            MoveTowards(Camera.main.ScreenToWorldPoint(screenPos));
            yield return null;
        }

        playerSpinMode = SpinMode.NotSpinning;
        yield return null;
    }
    private void MoveTowards(Vector3 positionToMoveTowards)
    {
        rb.AddForce(new Vector3(positionToMoveTowards.x, gameObject.transform.position.y, positionToMoveTowards.z) * movementSpeed * Time.deltaTime);
    }
}