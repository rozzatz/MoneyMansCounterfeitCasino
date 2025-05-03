using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraordinaryAmeobs : MonoBehaviour
{
    private TempAmeobScript ameobScript;
    private GameManager gm;
    public bool dellish;
    public bool oswald;
    public bool isocule;
    public bool ourple;
    public bool aurous;
    public bool xander;

    public GameObject greenAmeob;
    public GameObject redAmeob;
    public GameObject blueAmeob;
    public GameObject basicAmeob;
    public GameObject purpleAmeob;
    public GameObject orangeAmeob;
    public GameObject geralds;
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

    public void ExtraTappy()
    {
        if (dellish)
        {
            if (redAmeob.activeInHierarchy)
                gm.coins += (200 * redAmeob.GetComponent<TempAmeobScript>().ameobAmount); 
        }
        else if (oswald)
        {
            if (greenAmeob.activeInHierarchy)
            {
                TempAmeobScript greeny = greenAmeob.GetComponent<TempAmeobScript>();
                greeny.ameobAmount *= 2;
            }
            
        }
        else if (isocule)
        {
            if(blueAmeob.activeInHierarchy && basicAmeob.activeInHierarchy)
            {
                TempAmeobScript bluey = blueAmeob.GetComponent<TempAmeobScript>();
                TempAmeobScript basicy = basicAmeob.GetComponent<TempAmeobScript>();
                basicy.ameobAmount += (bluey.ameobAmount *= 50);
                bluey.ameobAmount = 0;

            }
        }
        else if (ourple)
        {
            purpleAmeob.GetComponent<TempAmeobScript>().ameobAmount += 100;
            purpleAmeob.SetActive(true);
        }
        else if (aurous)
        {
            GameObject[] rares = GameObject.FindGameObjectsWithTag("rare");
            if(rares != null)
            {
                int rareAdd = 0;
                foreach(GameObject rare in rares)
                {
                    TempAmeobScript hehe = rare.GetComponent<TempAmeobScript>();
                    rareAdd += hehe.ameobAmount;
                }
                gm.coins += (rareAdd * rareAdd * rareAdd);
            }
        }
        else if (xander)
        {
            if(orangeAmeob.activeInHierarchy)
            {
                orangeAmeob.GetComponent<TempAmeobScript>().ameobAmount = 0;
                geralds.SetActive(true);
                geralds.GetComponent<TempAmeobScript>().ameobAmount += 10;
            }
        }
        if (ameobScript.onTapDelete)
        {
            ameobScript.ameobAmount -= 1;
        }
    }

    
}
