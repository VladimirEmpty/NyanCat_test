using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        offset = target.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position - offset;
        targetPosition.y = transform.position.y;

        transform.position = targetPosition;
    }
}
