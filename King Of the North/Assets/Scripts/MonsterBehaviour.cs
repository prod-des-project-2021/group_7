using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public float speed;
    public Transform[] pathPoints;
    public SpriteRenderer flip;

    public int damageOnCollision = 40; 


    private Transform target;
    private int destinationPoint;
    void Start()
    {
        target = pathPoints[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
 
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destinationPoint = (destinationPoint + 1) % pathPoints.Length;
            target = pathPoints[destinationPoint];
            flip.flipX = !flip.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerLife playerLife = collision.transform.GetComponent<PlayerLife>();
            playerLife.DamageHit(damageOnCollision);
        }
    }
}
