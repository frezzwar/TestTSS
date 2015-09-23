using UnityEngine;
using System.Collections;

public class BruiserBehavior : MonoBehaviour {
	
	public int health = 2;
	public GameObject bullet;
	public float fireDelay = 1f;
	float cooldown = 0;
	Rigidbody2D rb;
	Transform player;
	public float rotSpeed = 180f;
	public float targetAngle = 2.5f;
	public float distance = 1f;
	public float bulletSpeed = 4;
	public float bulletSelfdestructTimer = 3;
	public float moveSpeed = 2f;
	
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
	void Shoot (){
		
		if (cooldown <= 0)
		{
			Debug.Log("hej " + gameObject.name);
			//bullet.GetComponents<BulletBehavior>()[0].speed = bulletSpeed;
			//bullet.GetComponents<BulletBehavior>()[0].selfDestructTimer = bulletSelfdestructTimer;
			Instantiate(bullet, transform.FindChild("GunSpot").position, transform.rotation);
			cooldown = fireDelay;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		cooldown -= Time.fixedDeltaTime;
		
		EmemyBehavior.Instance.DeathCheck (gameObject, health);
		
		if (player == null)
		{
			player = EmemyBehavior.Instance.FindPlayer ();
		}
		else
		{
			EmemyBehavior.Instance.Rotate(player, transform, rotSpeed);
			
			if (EmemyBehavior.Instance.Angle(player, transform) < targetAngle)
			{
				Shoot ();
				EmemyBehavior.Instance.Move(transform, player, rb, distance, moveSpeed);
			}
		}
	}
}
