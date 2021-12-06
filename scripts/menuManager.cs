using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Button start;
    public GameObject panelMenu;
    public GameObject menuGameplay;

    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(ButtonStart);
    }

    private void ButtonStart()
    {
        panelMenu.SetActive(false);
        CarDir.move = 1;
        StartCoroutine(StartMenuGamePlay());
    }

    private IEnumerator StartMenuGamePlay()
    {
        yield return new WaitForSeconds(2.5f);
        CarDir.move = 0;
        menuGameplay.SetActive(true);
    }
}
