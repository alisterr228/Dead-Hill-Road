using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerZombi : MonoBehaviour
{
    public GameObject zombi;
    public GameObject zombiPrefab;

    public int pubCount;
    public float pubTime;
    private int count = 0;
    private float time = 0.3f;

    // Update is called once per frame
    void Update()
    {
        time -= pubTime * Time.deltaTime;

        if(count != pubCount && time <= 0f)
        {
            count += 1;
            zombi = Instantiate(zombiPrefab, gameObject.transform.position, Quaternion.identity);
            time = pubTime;
        }
    }
}
