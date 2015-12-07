using UnityEngine;
using System.Collections;

public class InterceptorBehavior : MonoBehaviour {

    public int health = 2;
    public GameObject bullet;
    public float fireDelay = 1f;
    float cooldown = 0;
    Rigidbody2D rb;
    Transform player;
    public float rotSpeed = 360f;
    public float targetAngle = 2.5f;
    public float distance = 0f;
    public float bulletSpeed = 4;
    public float bulletSelfdestructTimer = 3;
    public float moveSpeed = 6f;
    public int pointsWorth = 1;
    public AudioSource explotion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.name == "BlueShot(Clone)")
        {
            health--;
        }
    }

    //Bugged. Cooldown skal ikke tælle ned her.
    void Shoot()
    {

        if (cooldown <= 0)
        {
            
            bullet.GetComponents<BulletBehavior>()[0].speed = bulletSpeed;
            bullet.GetComponents<BulletBehavior>()[0].selfDestructTimer = bulletSelfdestructTimer;
            Instantiate(bullet, transform.FindChild("GunSpot").position, transform.rotation);
            cooldown = fireDelay;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;

        EmemyBehavior.Instance.DeathCheck(gameObject, health, pointsWorth, explotion);

        if (player == null)
        {
            player = EmemyBehavior.Instance.FindPlayer();
        }
        else
        {
            EmemyBehavior.Instance.Rotate(player, transform, rotSpeed);
            EmemyBehavior.Instance.Move(transform, player, rb, distance, moveSpeed);
            Shoot();

            if (EmemyBehavior.Instance.Angle(player, transform) < targetAngle)
            {
                
            }
        }
    }
}
