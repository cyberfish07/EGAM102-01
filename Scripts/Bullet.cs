using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Setting up variables
    public float speed = 300f;
    public float lifetime = 1f;
    public Rigidbody2D bulletRigidbody;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }
    void Update()
    {

    }

    public void ShootBullet(Vector2 direction, Quaternion playerRotation)
    {
        //Add a force to the bullet
        bulletRigidbody.AddForce(direction * speed);
        //Destroy the bullet after it reaches its max lifetime
        Destroy(gameObject, lifetime);
        //Make bullet direction same as player
        transform.rotation = playerRotation;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
