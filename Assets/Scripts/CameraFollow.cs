using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    protected float smoothing = 10f;

    // Update is called once per frame
    void Update()
    {
        // Vector3 newPosition = target.position + offset;
        Vector3 newPosition = Vector2.Lerp(transform.position, target.position + offset, smoothing * Time.deltaTime);
         newPosition.z = -10;
         transform.position = newPosition;
    }
}
