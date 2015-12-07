using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Singleton class. Use for global variables.
public class EmemyBehavior : MonoBehaviour {


    GameObject pointsTextObject;

    void Start()
    {
        pointsTextObject = GameObject.Find("Canvas/PlayerPointsText");
    }

    //Check to see if the enemy is dead.
    public void DeathCheck (GameObject go, float health, int pointsWorth, AudioSource deathSound)
	{
		if (health <= 0)
		{
            Destroy(go);
            GlobalStuff.Instance.points += pointsWorth;
            string pointsText = "XP: " + GlobalStuff.Instance.points;
            pointsTextObject.GetComponent<Text>().text = pointsText; //set the text in the text component
            //deathSound.Play();
        }
	}

    public void GivePoints (int pointsWorth)
    {
        GlobalStuff.Instance.points += pointsWorth;
        string pointsText = "XP: " + GlobalStuff.Instance.points;
        pointsTextObject.GetComponent<Text>().text = pointsText; //set the text in the text component
    }

	//Find a target if we don't have any.
	public Transform FindPlayer()
	{
		GameObject[] listOfPlayers = GameObject.FindGameObjectsWithTag("Player");
		if (listOfPlayers.Length == 0)
		{
			return null;
		}
		//Her burde man sortere listen, så den nærmeste spiller er føst.
		//Lige nu er der kun 1 spiller, så det er lidt ligemeget.
		//Hvis der er flere spillere, så kan en fjende kun jagte en spiller. Den spiller bliver ikke ændret før han dør.
		return listOfPlayers[0].transform;
	}

	//Rotate to find the target.
	public void Rotate(Transform targetTransform, Transform enemyTransform, float rotSpeed)
	{
		Quaternion desire = Desire (targetTransform, enemyTransform);
		enemyTransform.rotation = Quaternion.RotateTowards (enemyTransform.rotation, desire, rotSpeed * Time.fixedDeltaTime);
	}

	//Find angle towards target.
	public float Angle (Transform targetTransform, Transform enemyTransform)
	{
		Quaternion desire = Desire (targetTransform, enemyTransform);
		float targeting = Mathf.Abs (enemyTransform.rotation.z) - Mathf.Abs (desire.z);
		targeting = Mathf.Rad2Deg * Mathf.Abs (targeting);
		return targeting;
	}

	//Find desired angle
	Quaternion Desire (Transform targetTransform, Transform enemyTransform)
	{
		Vector3 dir = targetTransform.position - enemyTransform.position;
		dir.Normalize ();
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		Quaternion desire = Quaternion.Euler (0, 0, zAngle);
		return desire;
	}

	public void Move (Transform enemyTransform, Transform playerTransform, Rigidbody2D rb, float minDistance, float speed)
	{
		float distance = (enemyTransform.position - playerTransform.position).magnitude;

		

		if (distance > minDistance)
		{
			Vector3 positionn = enemyTransform.position;
			Vector3 velocity = new Vector3 (0, speed * Time.fixedDeltaTime, 0);
			positionn += enemyTransform.rotation * velocity;
			
			rb.MovePosition (positionn);
		}
		else
		{
			rb.velocity = Vector2.zero;
		}

	}

	//Make it a singleton. This is pure magic.
	private static EmemyBehavior instance;
	public static EmemyBehavior Instance
	{
		get { return instance ?? (instance = new GameObject("EmemyBehavior").AddComponent<EmemyBehavior>()); }
	}
}
