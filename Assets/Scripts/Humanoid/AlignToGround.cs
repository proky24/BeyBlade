using UnityEngine;
public class AlignToGround : MonoBehaviour
{
    private RaycastHit raycastHit;
    [SerializeField]
    private LayerMask layerMask;
    public float DistanceFromGround { get { return raycastHit.distance; } }
    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out raycastHit, 10, layerMask))
        {
            Vector3 groundNormal = raycastHit.normal;
            Vector3 projectedForward = Vector3.ProjectOnPlane(transform.forward, groundNormal).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(projectedForward, groundNormal);
            transform.rotation = targetRotation;
        }
    }
}