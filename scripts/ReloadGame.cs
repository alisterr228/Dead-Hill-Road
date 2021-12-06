using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    public Button reloadB;
    public GameObject reloadPanel;
    public CarController car;
    public string carName;

    private float timer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        reloadB.onClick.AddListener(Reload);
        car = GameObject.FindGameObjectWithTag(carName).GetComponent<CarController>();
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (car.oil == 0)
            Timer();

        if (car.oil > 0)
            timer = 1.0f;
    }

    private void Timer()
    {
        timer -= 0.3f * Time.deltaTime;

        if(timer <= 0)
        {
            timer = 0f;
            reloadPanel.SetActive(true);
        }
    }
}
