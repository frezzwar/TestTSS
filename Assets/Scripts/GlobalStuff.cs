using UnityEngine;
using System.Collections;

//Singleton class. Use for global variables.
public class GlobalStuff : MonoBehaviour {

	//Put global variables here
	public float playerDamage = 1f;
	public float playerSpeed = 5f;
	public float playerBulletSpeed = 20f;
	public bool spawn = false;

	public bool playerInvul = false;




	//Make it a singleton. This is pure magic.
	private static GlobalStuff instance;
	public static GlobalStuff Instance
	{
		get { return instance ?? (instance = new GameObject("GlobalStuff").AddComponent<GlobalStuff>()); }
	}
}
