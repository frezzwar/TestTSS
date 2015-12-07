using UnityEngine;
using System.Collections;

public class CarrierBehavior : MonoBehaviour
{

    public int health = 10;
    Rigidbody2D rb;
    Transform player;
    public float rotSpeed = 120f;
    public float targetAngle = 2.5f;
    public float minDistance = 10f;
    public float moveSpeed = 5f;
    public int pointsWorth = 100;
    public AudioSource deathSound;
    public float carrierBuildCooldown;
    public float carrierBuildTimer;
    public float carrierReleaseCooldown;
    public float carrierReleaseTimer;
    public int carriersLeft;
    Transform child;
    public GameObject interceptor;

    void Start()
    {
        child = transform.FindChild("spawnPoint");
        rb = GetComponent<Rigidbody2D>();
        carriersLeft = 10;
        carrierBuildCooldown = 1f;
        carrierReleaseCooldown = 0.2f;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.gameObject.name == "BlueShot(Clone)")
        {
            health--;
        }
    }

    void FixedUpdate()
    {
        EmemyBehavior.Instance.DeathCheck(gameObject, health, pointsWorth, deathSound);
        carrierBuildTimer -= Time.fixedDeltaTime;
        carrierReleaseTimer -= Time.fixedDeltaTime;
        if (carrierBuildTimer <= 0)
        {
            carriersLeft++;
            carrierBuildTimer = carrierBuildCooldown;
        }
        if (carrierReleaseTimer <= 0 && carriersLeft > 0)
        {
            Instantiate(interceptor, child.position, transform.rotation);
            carrierReleaseTimer = carrierReleaseCooldown;
            carriersLeft--;
        }

        if (player == null)
        {
            player = EmemyBehavior.Instance.FindPlayer();
        }
        else
        {
            EmemyBehavior.Instance.Rotate(player, transform, rotSpeed);

            if (EmemyBehavior.Instance.Angle(player, transform) < targetAngle)
            {
                EmemyBehavior.Instance.Move(transform, player, rb, minDistance, moveSpeed);
            }
        }
    }
}
