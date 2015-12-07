using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnEnemy : MonoBehaviour {

    public List<GameObject> listOfPossibleEnemies = new List<GameObject>();
	GameObject enemy;
    float health;
    int edge;
    float position;
    int isNegative;
    Vector3 posVector = new Vector3(0, 0, 0);
   
    
    public float fireDelay = 3f;
	float cooldown = 0;

    void Star()
    {
     
    }

	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if ( cooldown <= 0 && GlobalStuff.Instance.spawn == true)
		{
            posVector = new Vector3(0, 0, 0);
            edge = Random.Range(0, 5);
            position = Random.Range(0f, 1f);
            isNegative = Random.Range(0, 2);
           
            if (edge == 0)
            {
                posVector.y = 18f;
                posVector.x = position * 25.6f;
                if (isNegative == 0)
                {
                    posVector.x = posVector.x * -1;
                }
                gameObject.transform.position = posVector;

            }
            else if (edge == 1)
            {
                posVector.y = -18f;
                posVector.x = position * 25.6f;
                if (isNegative == 0)
                {
                    posVector.x = posVector.x * -1;
                }
                gameObject.transform.position = posVector;
            }
            else if (edge == 3)
            {
                posVector.y = position * 18f;
                posVector.x = 25.6f;
                if (isNegative == 0)
                {
                    posVector.y = posVector.y * -1;
                }
                gameObject.transform.position = posVector;
            }
            else if (edge == 4)
            {
                posVector.y = position * 18f;
                posVector.x = -25.6f;
                if (isNegative == 0)
                {
                    posVector.y = posVector.y * -1;
                }
                gameObject.transform.position = posVector;
            }

            int randomEnemyNumber = Random.Range(0, listOfPossibleEnemies.Count);
            enemy = listOfPossibleEnemies[randomEnemyNumber];
            InitializeEnemy(enemy);
            Instantiate(enemy, gameObject.transform.position, transform.rotation);
			cooldown = fireDelay;
		}
	}

    void InitializeEnemy(GameObject enemy)
    {
        switch (enemy.transform.name)
        {
            case "SniperEnemy":
         
                break;
            case "BruiserEnemy":
           
                break;
        }
    } 
}
