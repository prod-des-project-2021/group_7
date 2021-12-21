// using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public string sceneName;
    // private Animator fadeSystem;

    // private void Awake()
    // {
    //     fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    // public IEnumerator loadNextScene()
    // {
    //     LoadAndSaveData.instance.SaveData();
    //     fadeSystem.SetTrigger("FadeIn");
    //     yield return new WaitForSeconds(1f);
    //     SceneManager.LoadScene(sceneName);
    // }
}
