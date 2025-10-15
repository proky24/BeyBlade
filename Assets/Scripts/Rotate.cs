using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private bool isRotating = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isRotating = true;
        }

        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
