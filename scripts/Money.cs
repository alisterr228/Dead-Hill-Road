using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public string carCarcouseName;
    public MoneyManager monManag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == carCarcouseName)
        {
            monManag.moneyCount += 5;
            Destroy(gameObject);
        }
    }
}
