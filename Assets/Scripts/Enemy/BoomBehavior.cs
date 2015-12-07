using UnityEngine;
using System.Collections;

public class BoomBehavior : MonoBehaviour
{

    public int health = 1;
    Rigidbody2D rb;
    Transform player;
    public float rotSpeed = 180f;
    public float targetAngle = 2.5f;
    public float minDistance = 0f;
    public float moveSpeed = 5f;
    public int pointsWorth = 1;
    public AudioSource explotionSound;

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
        else if (obj.gameObject.name == "Test Ship")
        {
            Explode();

            Debug.Log(obj.gameObject.name);
        }
    }

    void Explode()
    {
        Debug.Log("kage");
        EmemyBehavior.Instance.GivePoints(pointsWorth);
        //explotionSound.Play();
        if (Vector2.Distance(transform.position, player.position) < 2)
        {
            GlobalStuff.Instance.PlayerHealthCurrent--;
        }
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        //Custum DeathCheck
        if (health <= 0)
        {
            Explode();
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
