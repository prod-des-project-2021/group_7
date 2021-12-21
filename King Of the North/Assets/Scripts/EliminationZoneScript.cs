
using UnityEngine;

public class EliminationZoneScript : MonoBehaviour

{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        }
    }

}