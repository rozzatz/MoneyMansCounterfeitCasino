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
    private int passiveCount;
    public GameObject[] wizardAmeobs;
    public GameObject[] wizardyAmeobs;
    public GameObject[] uniquey;
    // Start is called before the first frame update
    void Start()
    {
        ameobScript = GetComponent<TempAmeobScript>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

            
    }

    public void UniqueTapAmeob()
    {
        if (allSeeing)
        {
            gm.coins += 3000;
            
        }
        else if (triLeg)
        {
            gm.coins += 500;
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
            GameObject basic = GameObject.FindGameObjectWithTag("basic");
            if(basic != null)
            {
                TempAmeobScript basicScript = basic.GetComponent<TempAmeobScript>();
                basicScript.ameobAmount += 1000;
            }
            
        }
        else if (moneyMan)
        {
            gm.coins += (100 * gm.roundCount);
        }
        else if (fourD)
        {
            //he will look cool
            int roll = Random.Range(0, uniquey.Length);
            uniquey[roll].SetActive(true);
            TempAmeobScript eue = uniquey[roll].GetComponent<TempAmeobScript>();
            eue.ameobAmount += 2;

        }
        if (ameobScript.onTapDelete)
        {
            ameobScript.ameobAmount -= 1;
        }


    }

    public void UniquePassive()
    {
        if(gm.roundCount != passiveCount)
        {
            if (allSeeing)
            {
                GameObject[] rares = GameObject.FindGameObjectsWithTag("rare");
                if (rares != null)
                {
                    int rareAmount = 0;
                    for (int i = 0; i < rares.Length; i++)
                    {
                        rareAmount += rares[i].GetComponent<TempAmeobScript>().ameobAmount;

                    }
                    gm.coins += (rareAmount * rareAmount);
                }
            }
            else if (triLeg)
            {
                dupliLimit += gm.roundCount;
                ameobScript.ameobAmount *= 2;
                if (ameobScript.ameobAmount >= dupliLimit)
                {
                    ameobScript.ameobAmount = dupliLimit;
                }
            }
            else if (wizard)
            {
                int roll = Random.Range(0, wizardyAmeobs.Length);

                wizardyAmeobs[roll].SetActive(true);
                TempAmeobScript wepee = wizardyAmeobs[roll].GetComponent<TempAmeobScript>();
                wepee.ameobAmount++;
            }
            else if (moneyMan)
            {
                gm.coins += (50 * gm.roundCount);
            }
            passiveCount = gm.roundCount;
        }
    }
}


