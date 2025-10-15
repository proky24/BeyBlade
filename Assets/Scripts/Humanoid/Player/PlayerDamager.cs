using UnityEngine;
public class PlayerDamager : MonoBehaviour
{
    [Header("Vlastnosti")]
    [SerializeField]
    private float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var dmg))
        {
            dmg.Damage(damage);
        }
    }
}