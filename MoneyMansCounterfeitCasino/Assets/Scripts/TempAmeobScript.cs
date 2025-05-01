using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TempAmeobScript : MonoBehaviour //no longer temporary
{
    private GameManager gm;
    private AmeobUIScript ameobInfo;
    private AbnormalAmeobPowers abnormality;
    private ExtraordinaryAmeobs extraa;
    private UniqueAmeobs uniquity;

    public GameObject infoBackground;
    public GameObject shop;

    public bool basicorrare;
    public bool abnormal;
    public bool extraordinary;
    public bool unique;
    
    public string ameobityName;
    public string ameobityDesc;

    private LootTable loot;

    public int ameobAmount; //amount of ameobs the holder has

    public bool onTapDelete = true; // bool value that sees if this specific ameob will die if tapped(most abnormal/ameobs with abilities live even with a tap)
    

    void Start()
    {
        //gets the game manager, loot script, ameob info background, and abnormal scripts
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        loot = GetComponent<LootTable>();
        ameobInfo = infoBackground.GetComponent<AmeobUIScript>();
        if (abnormal)
        {
            abnormality = GetComponent<AbnormalAmeobPowers>();
        }
        if (unique)
        {
            uniquity = GetComponent<UniqueAmeobs>();
        }
        if (extraordinary)
        {
            extraa = GetComponent<ExtraordinaryAmeobs>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the ameob amount is 0 or not, and if it is it deactivates the background
        if(ameobAmount <= 0)
        {
            gameObject.SetActive(false);
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<BoxCollider2D>().enabled = false;
            infoBackground.SetActive(false);
        }
        //checks if the shop is open and closes the info background if it is
        if (shop.activeInHierarchy)
        {
            infoBackground.SetActive(false);
        }

        if(unique && gameObject.activeInHierarchy)
        {
            uniquity.UniquePassive();

        }
        
    }

    public void OnMouseDown()
    {
        //sets the infobackground to the ameobs and sets the description and name
        if (infoBackground.activeInHierarchy == true)
        {
            infoBackground.SetActive(false);
        }
        else if(infoBackground.activeInHierarchy == false)
        {
            infoBackground.SetActive(true);
        }
        
        infoBackground.transform.SetParent(gameObject.transform);
        infoBackground.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y + 2, gameObject.transform.position.z);
        ameobInfo.ameobName.text = ameobityName;
        ameobInfo.ameobAbility.text = ameobityDesc;
        ameobInfo.ameobCount.text = "Ameob Amount: " + ameobAmount;
    }

    public void TapAmeob()
    {
        //if the ameob is basic or rare, it does this
        if (basicorrare)
        {
            //if double moolah is active then it doubles the money
            if (gm.doubleMoolah == true)
            {
                if (onTapDelete == true)
                { ameobAmount -= 1; }
                loot.BasicLootCalc();
                gm.coins += loot.lootResult * 2;
                gm.doubleMoolah = false;
            }
            //else it just makes a random amount of money
            else
            {
                if (onTapDelete == true)
                { 
                    ameobAmount -= 1; 
                }
                loot.BasicLootCalc();
                gm.coins += loot.lootResult;
            }
        }
        //if the ameob is abnormal it accesses the abnormal script and does the abnormal tap
        else if (abnormal)
        {
            abnormality.AbnormalTapAmeob();
        }
        else if(extraordinary)
        {
            extraa.ExtraTappy();
        }
        else if (unique)
        {
            uniquity.UniqueTapAmeob();
        }
        
        
    }

    public void Sacrifice()
    {
        //if the player sacrifices the ameob they lose one ameob
        
        if (gm.ballSack)
        {
            ameobAmount -= 1;
            gm.coins += 50;
        }
        else
        {
            ameobAmount -= 1;
        }
    }
}
