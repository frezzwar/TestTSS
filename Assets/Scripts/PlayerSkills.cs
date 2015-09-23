using UnityEngine;
using System.Collections;

public class PlayerSkills : MonoBehaviour {

	float fireDelay = 10f;
	float cooldown = 0f;
	float durationLeft = 0f;
	float duration = 3f;
	
	// Update is called once per frame
	void Update () 
	{
		cooldown -= Time.deltaTime;
		durationLeft -= Time.deltaTime;
		if (Input.GetButtonDown("Jump") && cooldown <= 0)
		{
			cooldown = fireDelay;
			durationLeft = duration;
			gameObject.AddComponent<CircleCollider2D>();
			gameObject.GetComponent<CircleCollider2D>().radius = 1.5f;
			GlobalStuff.Instance.playerInvul = true;
		}

		if (durationLeft <= 0 && gameObject.GetComponent<CircleCollider2D>())
		{
			Destroy(gameObject.GetComponent<CircleCollider2D>());
			GlobalStuff.Instance.playerInvul = false;
		}
	}
}