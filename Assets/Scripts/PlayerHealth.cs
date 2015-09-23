using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float health = 5f;
	public GameObject healthTxtObject;
	public GameObject deathTextObject;

	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.name == "Red_shot(Clone)" && GlobalStuff.Instance.playerInvul == false)
		{
			health--;
			Text text = healthTxtObject.GetComponent<Text>(); //get the text component in the gameobject you assigned
			string helthText = "Health: " + health;
			text.text = helthText; //set the text in the text component
			
		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (health < 1)
		{
			Destroy(gameObject);
			Text text = deathTextObject.GetComponent<Text>(); //get the text component in the gameobject you assigned
			text.text = "YOU FUCKING DIED"; //set the text in the text component
		}
	}
}
