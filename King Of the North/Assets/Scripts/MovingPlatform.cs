using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
