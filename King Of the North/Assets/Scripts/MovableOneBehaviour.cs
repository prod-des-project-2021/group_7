using UnityEngine;
public class MovableOneBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }      

private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // collision.gameObject.transform.SetParent(transform);
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // collision.gameObject.transform.SetParent(null);
            collision.transform.parent = null;

        }
    }
}
