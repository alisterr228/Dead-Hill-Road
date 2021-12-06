using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int moneyCount;
    public Text moneyTxt;
    public Text mainMenuMoney;

    // Update is called once per frame
    void Update()
    {
        moneyTxt.text = moneyCount + "";
        mainMenuMoney.text = moneyCount + "";
    }
}
