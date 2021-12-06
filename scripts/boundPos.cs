using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundPos : MonoBehaviour
{
    public Transform pivotT;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = pivotT.transform.position; 
    }
}
