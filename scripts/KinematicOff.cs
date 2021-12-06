using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KinematicOff : MonoBehaviour
{
    public MoneyManager mm;

    private void Start()
    {
        mm = GameObject.FindGameObjectWithTag("userInterface").GetComponent<MoneyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "zaprR")
        {
            gameObject.GetComponentInParent<zombi>().enabled = false;
            gameObject.GetComponentInParent<Animator>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            mm.moneyCount += 5;
            Destroy(gameObject, 2f);
        }
    }
}
