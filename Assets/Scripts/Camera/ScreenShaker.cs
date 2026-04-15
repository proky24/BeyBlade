using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class ScreenShaker : MonoBehaviour
{
    [SerializeField]
    private float randomness = 1;
    [SerializeField]
    private int shakes = 5;
    [SerializeField]
    private float strength;
    [SerializeField]
    private Transform cameraContainer;
    [SerializeField]
    private float interval = 0.1f;
    public void AddOnHit(DamagerModule dm)
    {
        dm.OnHit += StartCor;
    }
    public void RemoveOnHit(DamagerModule dm)
    {
        dm.OnHit -= StartCor;
    }
    private void StartCor()
    {
        StartCoroutine(Shake(strength));
    }
    public IEnumerator Shake(float strength)
    {
        int shakesAmount = shakes;

        while (shakesAmount > 0)
        {
            float randomNum = Random.Range(0, randomness);
            float x = Random.Range(-randomNum * strength, randomNum * strength);
            float y = Random.Range(-randomNum * strength, randomNum * strength);
            transform.position = new Vector3(x, y, 0) + cameraContainer.position;
            shakesAmount--;
            yield return new WaitForSeconds(interval);
        }

        transform.position = Vector3.zero + cameraContainer.position;
        yield return null;
    }
}