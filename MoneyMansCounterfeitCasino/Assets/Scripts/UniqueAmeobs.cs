using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueAmeobs : MonoBehaviour
{
    private TempAmeobScript ameobScript;
    private GameManager gm;
    public bool allSeeing;
    public bool triLeg;
    public bool wizard;
    public bool enormab;
    public bool moneyMan;
    public bool fourD;

    public int dupliLimit;

    public GameObject[] wizardAmeobs; 
    // Start is called before the first frame update
    void Start()
    {
        ameobScript = GetComponent<TempAmeobScript>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enormab)
        {
            gm.ballSack = true;
        }
    }

    public void UniqueTapAmeob()
    {
        if (allSeeing)
        {
            GameObject[] rares = GameObject.FindGameObjectsWithTag("rare");
            int rareAmount = 0;
            for(int i = 0; i < rares.Length; i++)
            {
                rareAmount += rares[i].GetComponent<TempAmeobScript>().ameobAmount;

            }
            gm.coins += (rareAmount * rareAmount);
        }
        else if (triLeg)
        {
            dupliLimit += gm.roundCount;
            ameobScript.ameobAmount *= 2;
            if(ameobScript.ameobAmount >= dupliLimit)
            {
                ameobScript.ameobAmount = dupliLimit;
            }
        }
        else if (wizard)
        {
            //youre a wizard harry
            int roll = Random.Range(0, wizardAmeobs.Length);
            wizardAmeobs[roll].SetActive(true);
            TempAmeobScript wizardScript = wizardAmeobs[roll].GetComponent<TempAmeobScript>();
            wizardScript.ameobAmount++;
        }
        else if (enormab)
        {
            GameObject[] rares = GameObject.FindGameObjectsWithTag("rare");
            int roll = Random.Range(0, rares.Length);
            TempAmeobScript rareScript = rares[roll].GetComponent<TempAmeobScript>();
            rareScript.Sacrifice();
        }
        else if (moneyMan)
        {
            gm.coins += (100 * gm.roundCount);
        }
        else if (fourD)
        {
            //he will look cool
            gm.gameWin = true;

        }
    }
}
