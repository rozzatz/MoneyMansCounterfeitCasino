
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float coins;
    public int roundCount;
    
    public float quota;
    public float quotaMult;
    public bool doubleMoolah = false;
    public bool ballSack = false;
    public bool gameWin;
    public bool gameLose;

    
    public TMP_Text coinText;
    public TMP_Text shopCoins;
    public TMP_Text roundText;
    public TMP_Text quotatext;
    public TMP_Text gameOver;
    public GameObject camera;
    public GameObject gameOverScreen;

    public GameObject quitUI;
    
    public GameObject enormaby;
    void Start()
    {
        gameOverScreen.SetActive(false);
        quitUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coins = Mathf.Abs(coins);
        //sets all the text
        coinText.text = "Coins: " + coins;
        shopCoins.text = "Coins: " + coins;
        roundText.text = "Round: " + roundCount;
        quotatext.text = "Quota: " + quota;
        if (enormaby.activeInHierarchy)
        {
            ballSack = true;
        }
        else if(enormaby.activeInHierarchy == false)
        {
            ballSack = false;
        }
    }

    public void EndRound()
    {
        //the rounds system
        if(coins >= quota)
        {
            roundCount++;
            

            quota = Mathf.Abs(quota * quotaMult);
            if(roundCount % 10 == 0)
            {
                gameWin = true;
                quitUI.SetActive(true);
            }
        }
        else
        {
            quitUI.SetActive(true);
            gameLose = true;
        }
    }

    public void GameOver()
    {
        if (gameLose)
        {
            camera.transform.position = new Vector3(0, 1000, -10);
            gameOverScreen.SetActive(true);
            
            gameOver.text = "YOU LOSE";
        }

        if (gameWin)
        {
            camera.transform.position = new Vector3(0, 1000, -10);
            gameOverScreen.SetActive(true);
            
            gameOver.text = "YOU WIN";
        }
    }

    public void Continue()
    {
        quitUI.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }

    

    


}