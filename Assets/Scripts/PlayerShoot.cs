using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip shootSound;
    public Bullet bulletScript;
    public GameObject bulletPrefab;

    void Update()
    {
        // Get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 directionToMouse = (mousePos - transform.position).normalized;

        // Face the mouse
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Click mouse to shoot
        if (Input.GetMouseButtonDown(0))
        {
            // Create bullet
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();

            // Calculate the direction
            bulletScript.ShootBullet(directionToMouse, transform.rotation);
            sfxSource.clip = shootSound;
            sfxSource.Play();
        }
    }
}