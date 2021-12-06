using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombi : MonoBehaviour
{
    public GameObject zapr;
    public NavMeshAgent na;
    public float speed;

    private void Start()
    {
        zapr = GameObject.FindGameObjectWithTag("zaprR");
        na = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        na.destination = zapr.transform.position;
    }
}
