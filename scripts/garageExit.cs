using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garageExit : MonoBehaviour
{
    public GameObject camGarage;
    public GameObject camCar;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "zaprR")
        {
            camGarage.SetActive(false);
            camCar.SetActive(true);
        }
    }
}
