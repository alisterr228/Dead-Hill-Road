using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectInScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f,0f,1f));
    }
}
