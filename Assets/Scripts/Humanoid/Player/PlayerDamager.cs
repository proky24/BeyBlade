using UnityEngine;
public class PlayerDamager : MonoBehaviour
{
    [Header("Vlastnosti")]
    [SerializeField]
    private float damage = 10f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out var dmg))
        {
            dmg.Damage(damage);
        }
    }
}