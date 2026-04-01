using System;
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
    public event Action OnHit;
    private void Start()
    {
        movement = GetComponent<IMovement>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (movement.SpinMode == SpinMode.NotSpinning)
            return;

        var other = collision.gameObject;

        if (other.TryGetComponent<IDamageable>(out var dmg))
        {
            dmg.Damage(damage);
            var otherRb = other.GetComponent<Rigidbody>();

            Vector3 direction = (other.transform.position - transform.position).normalized;

            rb.linearVelocity *= 0.3f;
            otherRb.linearVelocity *= 0.3f;

            rb.AddForce(-direction * strength, ForceMode.Impulse);
            otherRb.AddForce(direction * strength, ForceMode.Impulse);

            OnHit?.Invoke();
        }
    }
}