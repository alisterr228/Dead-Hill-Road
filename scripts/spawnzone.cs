using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnzone : MonoBehaviour
{
    public List<GameObject> spawner = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "zaprR")
        {
            for(int i = 0; i < spawner.Count; i++)
            {
                spawner[i].SetActive(true);
            }

            Destroy(gameObject, 20f);
        }
    }
}
