using UnityEngine;
using System.Collections;

public class PlayerSkills : MonoBehaviour {

	float fireDelay = 10f;
	float cooldown = 0f;
	float durationLeft = 0f;
	float duration = 3f;
    bool active = false;
	
	// Update is called once per frame
	void Update () 
	{
		cooldown -= Time.deltaTime;
		durationLeft -= Time.deltaTime;
		if (Input.GetButtonDown("Jump") && cooldown <= 0)
		{
            cooldown = fireDelay;
            durationLeft = duration;
            GlobalStuff.Instance.playerInvul = true;
            active = true;
            transform.FindChild("ShieldSpell").GetComponent<shieldSpell>().ActivateShields();

        }

		if (durationLeft <= 0 && active == true)
		{
            active = false;
			GlobalStuff.Instance.playerInvul = false;
            transform.FindChild("ShieldSpell").GetComponent<shieldSpell>().DeactivateShields();
        }

        if (Input.GetButtonDown("Fire2") && GlobalStuff.Instance.points >= 3000)
        {
            GlobalStuff.Instance.points -= 3000;
            GlobalStuff.Instance.level++;
            Debug.Log(GlobalStuff.Instance.level);
        }
	}
}