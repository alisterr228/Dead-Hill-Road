using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oilManager : MonoBehaviour
{
    public Slider oilCount;
    public CarController cContr;
    public string carType;

    // Start is called before the first frame update
    void Start()
    {
        cContr = GameObject.FindGameObjectWithTag(carType).GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        oilCount.value = cContr.oil;
    }
}
