using UnityEngine;
public class DamagerModule : MonoBehaviour
{
    private IMovement movement;
    private Rigidbody rb;
    [Header("Vlastnosti")]
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float strength = 15f;
    private void Start()
    {
        movement = GetComponent<IMovement>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (movement.SpinMode == SpinMode.NotSpinning)
            return;

        if (other.TryGetComponent<IDamageable>(out var dmg))
        {
            dmg.Damage(damage);
            var otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = (other.transform.position - transform.position).normalized;

            rb.linearVelocity = Vector3.zero;
            otherRb.linearVelocity = Vector3.zero;

            rb.AddForce(-direction * strength);
            otherRb.AddForce(direction * strength);
        }
    }
}