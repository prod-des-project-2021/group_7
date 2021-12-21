using UnityEngine;
using UnityEngine.SceneManagement;


public class OnloadScene : MonoBehaviour
{
    public GameObject[] objects;
    void Update()
    {
        foreach (var element in objects){
            DontDestroyOnLoad(element);
        }
    }
}
