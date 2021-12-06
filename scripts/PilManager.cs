using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilManager : MonoBehaviour
{
    [SerializeField] private CarController carContr;
    public ParticleSystem ps;
    public WheelCollider wc;

    // Start is called before the first frame update
    void Start()
    {
        carContr = gameObject.GetComponentInParent<CarController>();
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //ps.startLifetime = Mathf.Clamp(wc.rpm, -0.5f, 0.5f);

        if (wc.isGrounded && wc.rpm != 0)
            ps.gameObject.SetActive(true);

        if (!wc.isGrounded || wc.rpm == 0)
            ps.gameObject.SetActive(false);
    }
}
