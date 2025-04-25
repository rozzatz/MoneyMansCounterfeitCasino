
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float coins;
    public float roundCount;
    
    public float quota;
    public float quotaMult;
    public bool doubleMoolah = false;
    public TMP_Text coinText;
    public TMP_Text roundText;
    public TMP_Text quotatext;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
        roundText.text = "Round: " + roundCount;
        quotatext.text = "Quota: " + quota;
    }

    public void EndRound()
    {
        if(coins >= quota)
        {
            roundCount++;
            

            quota *= quotaMult;
        }
        else
        {
            Debug.Log("You didn't go to Miguel's Bar Mitzvah");
        }
    }


}