using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float speed;
	public float selfDestructTimer;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag != "Bullet" && obj.gameObject.layer != gameObject.layer)
		{
			Destroy (gameObject);
		}

	}

	// Update is called once per frame
	void Update () {

		selfDestructTimer = selfDestructTimer - Time.deltaTime;
		
		if (selfDestructTimer <= 0)
		{
			Destroy(gameObject);
		}

		Vector3 position = transform.position;
		Vector3 velocity = new Vector3 (0, speed * Time.deltaTime, 0);
		position += transform.rotation * velocity;
		transform.position = position;
	
	}
}
//potientiel bug: Når skud rammer enemy, trigger den, og dør med det samme.
//Hvornår bliver triggers checked, og dør den inden modstanderen trigger og mister liv?