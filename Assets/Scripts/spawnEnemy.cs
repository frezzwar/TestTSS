using UnityEngine;
using System.Collections;

public class spawnEnemy : MonoBehaviour {


	public GameObject enemy;

	public float fireDelay = 3f;
	float cooldown = 0;

	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if ( cooldown <= 0 && GlobalStuff.Instance.spawn == true)
		{
			Instantiate(enemy, transform.FindChild("SpawnPoint").position, transform.rotation);
			cooldown = fireDelay;
		}
	}
}
