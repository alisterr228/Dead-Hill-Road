using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] WcolForward;
    public WheelCollider[] WcolBack;
    public ParticleSystem[] ps = new ParticleSystem[2];

    public Transform CenterOfMass;
    private Rigidbody rb;

    public Transform[] WheelsF;
    public Transform[] WheelsB;

    public float WheelOffset = 0.1f;
    public float WheelRadius = 0.13f;

    public float maxSteer = 30;
    public float maxAccel = 25;
    public float maxBrake = 50;
    public float speedRotate = 10f;
    public float oil = 1.5f;

    private float accel = 0;

    public class WheelData
    {
        public Transform WheelTransofrm;
        public WheelCollider Col;
        public Vector3 WheelStartPos;
        public float rotation = 0.0f;
    }

    protected WheelData[] wheels;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        wheels = new WheelData[WcolForward.Length + WcolBack.Length];

        for(int i = 0; i < WcolForward.Length; i++)
        {
            wheels[i] = SetupWheels(WheelsF[i], WcolForward[i]);
        }

        for (int i = 0; i < WcolBack.Length; i++)
        {
            wheels[i + WcolForward.Length] = SetupWheels(WheelsB[i], WcolBack[i]);
        }
    }

    private WheelData SetupWheels(Transform wheel, WheelCollider col)
    {
        WheelData result = new WheelData();

        result.WheelTransofrm = wheel;
        result.Col = col;
        result.WheelStartPos = wheel.transform.localPosition;

        return result;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float steer = 0;

        if (oil > 0)
            accel = CarDir.move;

        rb.centerOfMass = CenterOfMass.localPosition;
   
        CarMove(accel, steer);
        UpdateWheels();
        CarDigriz();
    }

    private void Update()
    {
        OilCount();
    }

    private void OilCount()
    {
        oil -= 0.03f * Time.deltaTime;

        if(accel != 0)
            oil -= 0.03f * Time.deltaTime;

        if (oil <= 0)
        {
            oil = 0f;
            accel = 0;
        }
    }

    private void UpdateWheels()
    {
        float delta = Time.deltaTime;

        foreach (WheelData w in wheels)
        {
            WheelHit hit;

            Vector3 lp = w.WheelTransofrm.localPosition;

            if (w.Col.GetGroundHit(out hit))
            {
                lp.y -= Vector3.Dot(w.WheelTransofrm.position - hit.point, transform.up) - WheelRadius;
            }
            else
            {
                lp.y = w.WheelStartPos.y - WheelOffset;
            }

            w.WheelTransofrm.localPosition = lp;

            w.rotation = Mathf.Repeat(w.rotation + delta * w.Col.rpm * 360.0f / 60.0f, 360);

            w.WheelTransofrm.localRotation = Quaternion.Euler(w.rotation, w.Col.steerAngle, 90.0f);
        }
    }

    private void CarDigriz()
    {
        foreach(WheelData w in wheels)
        {
            WheelHit hit;

            if (!w.Col.GetGroundHit(out hit) && accel > 0)
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(-Vector3.right * speedRotate));
            }


            if (!w.Col.GetGroundHit(out hit) && accel < 0)
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.right * speedRotate));
            }
        }
    }

    private void CarMove(float accel, float steer)
    {
        foreach(WheelCollider col in WcolForward)
        {
            col.motorTorque = accel * maxAccel;
        }

        foreach (WheelCollider col in WcolBack)
        {
            col.brakeTorque = 0;
            col.motorTorque = accel * maxAccel;
        }
    }
}
