using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Body")] 
    [SerializeField] private GameObject body;
    [Header("Vlastnosti")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 360f; // Degrees per second
    [SerializeField] private float power = 0f;
    [SerializeField] private float powerGainMultiplier = 1f;
    [SerializeField] private float maxPower = 2f;
    
    private bool isSpinning = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isSpinning)
        {
            power += Time.deltaTime * powerGainMultiplier;
            if (power > maxPower)
            {
                power = maxPower;
            }
        }
        else
        {
            if (power > 0f && !isSpinning)
            {
                StartCoroutine(SpinAndMove());
            }
        }
    }
    private IEnumerator SpinAndMove()
    {
        isSpinning = true;

        float duration = power;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            body.transform.Rotate(Vector3.up, rotationSpeed * (duration - elapsed) * Time.deltaTime, Space.Self);
            elapsed += Time.deltaTime;
            //Move();
            yield return null;
        }

        power = 0f;
        isSpinning = false;
        yield return null;
    }

    private void Move()
    {
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
        //TODO: udelat pohyb k mysi
    }
}


