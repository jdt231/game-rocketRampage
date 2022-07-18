using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rocket rocketShip;
    public Transform endOfLevel;

    public float smoothSpeed = 10f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    float maxX;
    float maxXOffset = 50f;

    void Start()
    {
        maxX = endOfLevel.position.x - maxXOffset;
    }

    void LateUpdate()
    {
        if (rocketShip.isAlive)
        {
            Vector3 shipPosition = new Vector3(Mathf.Clamp(rocketShip.transform.position.x, 0f, maxX), transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, shipPosition, ref velocity, smoothSpeed * Time.deltaTime);
        }

    }
}
