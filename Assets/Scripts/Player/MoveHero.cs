using UnityEngine;
using System.Collections;

public class MoveHero : MonoBehaviour {

	public Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	


	// Update is called once per frame
	void FixedUpdate () 
	{
		//Rotation to mouse - I don't know how. Figure that out, please
		Vector3 mousePos = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.Euler(0, 0, angle-90);
		transform.rotation = rotation;

		Vector2 moveDirection = new Vector2 (transform.position.x + (GlobalStuff.Instance.playerSpeed * Time.deltaTime * Input.GetAxis ("Horizontal")),
		                                     transform.position.y + (GlobalStuff.Instance.playerSpeed * Time.deltaTime * Input.GetAxis ("Vertical")));

		//rb.velocity = moveDirection;

		if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0)
		{
			rb.velocity = Vector2.zero;
		}
		else
		{
			rb.MovePosition (moveDirection);
		}
	
	}
}

