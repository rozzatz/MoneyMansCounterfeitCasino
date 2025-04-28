using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AbnormalAmeobPowers : MonoBehaviour
{
    private TempAmeobScript ameobScript;
    private GameManager gm;
    public bool bamBomb;
    public bool emBrain;
    public bool jimmy;
    public bool cat;

    public GameObject[] rareAmeobs;
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

    public void AbnormalTapAmeob()
    {
        if (bamBomb)
        {

            GameObject[] rares = GameObject.FindGameObjectsWithTag("rare");
            int roll = Random.Range(0, rares.Length);
            gm.coins += 500;
            TempAmeobScript rareScript = rares[roll].GetComponent<TempAmeobScript>();
            rareScript.Sacrifice();

        }
        else if (emBrain)
        {
            
            
            GameObject basic = GameObject.FindGameObjectWithTag("basic");
            TempAmeobScript basicScript = basic.GetComponent<TempAmeobScript>();
            if (basicScript.ameobAmount >= 5)
            {
                basicScript.ameobAmount -= 5;
                int roll = Random.Range(0, rareAmeobs.Length);
                rareAmeobs[roll].SetActive(true);
                TempAmeobScript addMore = rareAmeobs[roll].GetComponent<TempAmeobScript>();
                addMore.ameobAmount += 1;
            }
            else
            {
                ameobScript.ameobAmount -= 1;
            }


        }
        else if (jimmy)
        {
            int roll = Random.Range(0, rareAmeobs.Length);
            rareAmeobs[roll].SetActive(true);
            rareAmeobs[roll].GetComponent<TempAmeobScript>().ameobAmount += 50;

        }
        else if (cat)
        {
            gm.doubleMoolah = true;
        }
        
            if (ameobScript.onTapDelete == true)
            ameobScript.ameobAmount -= 1;
    }
}
