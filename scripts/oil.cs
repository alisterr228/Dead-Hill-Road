using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oil : MonoBehaviour
{
    public string carCarcouseName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == carCarcouseName)
        {
            other.gameObject.GetComponentInParent<CarController>().oil = 1.5f;
            Destroy(gameObject);
        }
    }
}
