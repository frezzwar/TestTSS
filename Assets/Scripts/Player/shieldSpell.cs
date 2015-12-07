using UnityEngine;
using System.Collections;

public class shieldSpell : MonoBehaviour
{
    public void ActivateShields()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
    }

    public void DeactivateShields()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
