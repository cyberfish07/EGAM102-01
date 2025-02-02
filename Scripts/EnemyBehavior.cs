using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float torque;
    public int scoreValue;
    public Rigidbody2D EnemyRigidbody;
    // Create a Particle Prefab
    public GameObject hitParticle;
    // Get player position
    public Transform player;
    // Bool calculate
    private bool hasGameOverTriggered = false;

    // Set an event
    public event Action OnDeath;

    void Start()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyRigidbody.AddForce(Vector2.up * speed);
        EnemyRigidbody.AddTorque(torque);

        // Search player
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            // Get the direction
            Vector2 direction = (player.position - transform.position).normalized; // Make length = 1

            // Set the speed
            EnemyRigidbody.linearVelocity = direction * speed;

            // Make enemy face player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null || collision.gameObject.CompareTag("Player"))
        {
            // Create particle effect
            // Get the crush point
            if (hitParticle != null)
            {
                ContactPoint2D hit = collision.GetContact(0);
                // 四元数旋转 = 四元数.欧拉角(0, 0, 数学函数库.反正切函数用于计算二维向量的角度)
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg);
                Transform sparks = Instantiate(hitParticle.transform, hit.point, rotation);
                Destroy(sparks.gameObject, 0.2f);
            }

            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
            }

            if (OnDeath != null)
            {
                OnDeath.Invoke();
            }
            Destroy(gameObject);
        }
    }
    // Scene transfer
    public void OnDestroy()
    {
        CheckGameOver();
    }
    private void CheckGameOver()
    {
        // Prevent load scene twice
        if (hasGameOverTriggered) return;
        // Check if all enemy destroy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            hasGameOverTriggered = true;
            // Load Win or Lose
            if (ScoreManager.Instance.CurrentScore >= 50)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
}
