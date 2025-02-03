using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public AudioSource sfxSource;

    public AudioClip shootSound;

    public Bullet bulletScript;

    public GameObject bulletPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Press Space to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            //Make bullet direction same as player
            Vector2 direction = transform.up;
            Quaternion playerRotation = transform.rotation;
            bulletScript.ShootBullet(direction, playerRotation);
            //Play sfx while shoot
            sfxSource.clip = shootSound;
            sfxSource.Play();
        }
    }
}
