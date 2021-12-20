using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public int maxLife = 100;
    public int currentLife;
    public bool isInvisible = false; 
    public float invisibilityFlash = 0.10f;
    public float invisibilityDelay = 3f;



    public SpriteRenderer graphics;




    public LifeBar lifeBar;



    void Start()
    {
        currentLife = maxLife;
        lifeBar.SetMaxLife(maxLife);
        
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.H)){
            DamageHit(20);
        }
        
    }

    public void DamageHit(int damage)

    {
         if (!isInvisible)
        {
            currentLife -= damage;
            lifeBar.SetLife(currentLife);

            isInvisible = true;
            StartCoroutine(InvisibilityFlash());
            StartCoroutine(InvisibilityDelay());
        }
    }

//Using coroutine to flash the player while being damaged
    public IEnumerator InvisibilityFlash()
    {
        while (isInvisible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invisibilityFlash);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invisibilityFlash);
        }
    }

    public IEnumerator InvisibilityDelay()
    {
        yield return new WaitForSeconds(invisibilityDelay);
        isInvisible = false;
    }
}
