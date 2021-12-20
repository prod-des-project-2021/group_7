
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public GameObject player;
    public float timetimeOffset;
    public Vector3 positionOffset;

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + positionOffset, ref velocity, timetimeOffset);
    }
}
