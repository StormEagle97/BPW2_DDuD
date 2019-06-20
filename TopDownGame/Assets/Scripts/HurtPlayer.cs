using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive;
    private bool isrunning = false;
    public float damageDelay;
    private bool inContact = false;
    private Collider generalOther;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inContact = true;
            generalOther = other;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inContact = false;
        }
    }

    public void FixedUpdate()
    {
        if (inContact)
        {
            StartCoroutine(doDamage(generalOther));
        }

    }

    IEnumerator doDamage(Collider other)
    {
        if (!isrunning)
        {
            isrunning = true;
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            yield return new WaitForSeconds(damageDelay);
            isrunning = false;
        }
    }
}
