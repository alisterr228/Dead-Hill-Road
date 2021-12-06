using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject car;
    private Vector3 carPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        carPos = new Vector3(car.transform.position.x + 10f, car.transform.position.y + 10f, 220f);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, carPos, 0.125f);
    }
}
