using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position; 
    }
}
