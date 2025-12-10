using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private new Camera camera;
    [SerializeField]
    private Vector3 offset;
    private Vector3 size;
    private Vector3 newPos;
    private void Start()
    {
        size = transform.localScale;
        newPos = new();
    }
    private void LateUpdate()
    {
        if (target == null)
            return;

        newPos.x = CheckBounds(target.position.x, size.x / 2, transform.position.x, offset.x);
        newPos.y = CheckBounds(target.position.y, size.y / 2, transform.position.y, offset.y);
        newPos.z = CheckBounds(target.position.z, size.z / 2, transform.position.z, offset.z);

        camera.transform.LookAt(target);
        camera.transform.position = newPos;
    }
    private float CheckBounds(float coord, float bound, float pos, float offset)
    {
        if (coord > (bound + pos))
            return bound + pos + offset;

        if (coord < (-bound + pos))
            return -bound + pos + offset;

        return coord + offset;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.2f);
        Vector3 center = transform.position;
        Vector3 size = transform.localScale;
        Gizmos.DrawCube(center, size);
    }
}