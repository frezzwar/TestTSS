using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {

	public GameObject bullet;
	public float fireDelay = 0.05f;
	float cooldown = 0;
	
	// Update is called once per frame
	void Update ()
	{
		cooldown -= Time.deltaTime;
		if (Input.GetButtonDown("Fire1") && cooldown <= 0)
		{
			Instantiate(bullet, transform.FindChild("GunSpot").position, transform.rotation);
			cooldown = fireDelay;
		}
	}
}