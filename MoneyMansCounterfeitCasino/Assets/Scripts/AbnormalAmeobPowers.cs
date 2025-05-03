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
        //checks the type of ameob they are
        if (bamBomb)
        {
            //finds all rare ameobs in the scene and sacrifices itself
            GameObject[] rares = GameObject.FindGameObjectsWithTag("rare");
            
            if(rares.Length > 0)
            {
                int roll = Random.Range(0, rares.Length);
                gm.coins += 999;
                TempAmeobScript rareScript = rares[roll].GetComponent<TempAmeobScript>();
                rareScript.Sacrifice();
                //if gerald says doublemoolah then double moolah
                if (gm.doubleMoolah)
                {

                    gm.coins += 999 * 2;

                    rareScript.Sacrifice();
                }
            }
            
            

        }
        else if (emBrain)
        {
            
            //finds the basic ameob and gets the ameob script
            GameObject basic = GameObject.FindGameObjectWithTag("basic");
            if(basic != null)
            {

                TempAmeobScript basicScript = basic.GetComponent<TempAmeobScript>();

                if (basicScript.ameobAmount >= 5)
                {
                    //uses up 5 ameobs but creates a rare ameob.
                    basicScript.ameobAmount -= 5;
                    int roll = Random.Range(0, rareAmeobs.Length);
                    rareAmeobs[roll].SetActive(true);
                    TempAmeobScript addMore = rareAmeobs[roll].GetComponent<TempAmeobScript>();
                    addMore.ameobAmount += 1;
                }
                else if (basicScript.ameobAmount <= 5)
                {
                    //if there are less then 5 basics in the scene then embrainium dies and nothing happens
                    ameobScript.ameobAmount -= 1;
                    
                }
            }
            if(basic == null)
            {
                ameobScript.ameobAmount -= 1;
            }


        }
        else if (jimmy)
        {
            //jimmy is op he gives you 50 rares
            int roll = Random.Range(0, rareAmeobs.Length);
            rareAmeobs[roll].SetActive(true);
            rareAmeobs[roll].GetComponent<TempAmeobScript>().ameobAmount += 50;

        }
        else if (cat)
        {
            // supposed to be  gerald, he doubles the moolah
            gm.doubleMoolah = true;
        }
        
            if (ameobScript.onTapDelete == true)
        {
            //deletes the ameobs
            ameobScript.ameobAmount -= 1;
        }
            
    }
}
