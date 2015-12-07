using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {

	public GameObject bullet;
	public float fireDelay = 0.05f;
	float cooldown = 0;
    public float bulletSpeed = 10;
    public float bulletSelfdestructTimer = 1;
    public AudioSource shootingSound;
    
    void Update ()
	{
		cooldown -= Time.deltaTime;
		if (Input.GetButton("Fire1") && cooldown <= 0)
		{
            bullet.GetComponents<BulletBehavior>()[0].speed = bulletSpeed;
            bullet.GetComponents<BulletBehavior>()[0].selfDestructTimer = bulletSelfdestructTimer;
            Instantiate(bullet, transform.FindChild("GunSpot").position, transform.rotation);
			cooldown = fireDelay;
            shootingSound.Play();
		}
	}
}