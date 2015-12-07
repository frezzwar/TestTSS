using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Singleton class. Use for global variables.
public class GlobalStuff : MonoBehaviour {

    //Put global variables here
    public GameObject healthTxtObject;
    public float playerDamage = 1f;
	public float playerSpeed = 5f;
	public float playerBulletSpeed = 20f;
	public bool spawn = false;
	public bool playerInvul = false;
    public int points;
    public int level;
    public int playerHealthMax;
    int playerHealthCurrent;

    public int PlayerHealthCurrent
    {
        set
        {
            playerHealthCurrent = value;
            string healthText = "Health: " + playerHealthCurrent;
            healthTxtObject.GetComponent<Text>().text = healthText; //set the text in the text component
        }
        get { return playerHealthCurrent; }
    }
    
    
    

    void Start()
    {
        healthTxtObject = GameObject.Find("Canvas/PlayerHealthText");
        points = 0;
        level = 1;
        PlayerHealthCurrent = 100;
    }


	//Make it a singleton. This is pure magic.
	private static GlobalStuff instance;
	public static GlobalStuff Instance
	{
		get { return instance ?? (instance = new GameObject("GlobalStuff").AddComponent<GlobalStuff>()); }
	}
}
