using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LootboxScript : MonoBehaviour
{
    public GameObject[] ameobsTypeOne;
    public GameObject[] rareAmeobs;
    public GameObject uniqueAmeob;
    public GameObject[] ameobsTypeTwo;
    public float cost;
    
    //public Transform spawnPos;
    
    public bool basicLoot;
    public bool extraordinaryLoot;
    public bool moneyManLoot;

    public float[] lootType;
    public float[] rareLoot;
    public float uniqueLoot;
    public float[] extraLoot;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //find the gamemanager
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LootBoxRoll()
    {
        //if the player has enough coins this happens
        if(gm.coins >= cost)
        {
            //takes away coins and then randomly picks a value from 1 - 100
            gm.coins -= cost;
            float roll = Random.Range(1, 100);
            if (basicLoot)
            {
                if (roll <= lootType.Max() && roll >= lootType.Min())
                {
                    int ameobRoll = Random.Range(0, ameobsTypeOne.Length);
                    ameobsTypeOne[ameobRoll].SetActive(true);
                    TempAmeobScript rolledAmeob = ameobsTypeOne[ameobRoll].GetComponent<TempAmeobScript>();
                    rolledAmeob.ameobAmount++;
                }
                else if(roll <= rareLoot.Max() && roll >= rareLoot.Min())
                {
                    int rareameobRoll = Random.Range(0, rareAmeobs.Length);
                    rareAmeobs[rareameobRoll].SetActive(true);
                    TempAmeobScript rolledAmeob = rareAmeobs[rareameobRoll].GetComponent<TempAmeobScript>();
                    rolledAmeob.ameobAmount++;
                }
                else if(roll == uniqueLoot)
                {
                    uniqueAmeob.SetActive(true);
                    TempAmeobScript unique = uniqueAmeob.GetComponent<TempAmeobScript>();
                    unique.ameobAmount++;
                }
            }
            else if (extraordinaryLoot)
            {
                if (roll <= lootType.Max() && roll >= lootType.Min())
                {
                    int ameobRoll = Random.Range(0, ameobsTypeOne.Length);
                    ameobsTypeOne[ameobRoll].SetActive(true);
                    TempAmeobScript rolledAmeob = ameobsTypeOne[ameobRoll].GetComponent<TempAmeobScript>();
                    rolledAmeob.ameobAmount++;
                }
                else if (roll <= rareLoot.Max() && roll >= rareLoot.Min())
                {
                    int rareameobRoll = Random.Range(0, rareAmeobs.Length);
                    rareAmeobs[rareameobRoll].SetActive(true);
                    TempAmeobScript rolledAmeob = rareAmeobs[rareameobRoll].GetComponent<TempAmeobScript>();
                    rolledAmeob.ameobAmount++;
                }
                else if(roll<= extraLoot.Max() && roll >= extraLoot.Min())
                {
                    int extraameobRoll = Random.Range(0, ameobsTypeTwo.Length);
                    rareAmeobs[extraameobRoll].SetActive(true);
                    TempAmeobScript rolledAmeob = rareAmeobs[extraameobRoll].GetComponent<TempAmeobScript>();
                    rolledAmeob.ameobAmount++;
                }
                else if (roll == uniqueLoot)
                {
                    uniqueAmeob.SetActive(true);
                    TempAmeobScript unique = uniqueAmeob.GetComponent<TempAmeobScript>();
                    unique.ameobAmount++;
                }
            }
            else if (moneyManLoot)
            {
                if(roll <= lootType.Max() && roll >= lootType.Min())
                {
                    Debug.Log("CONFETTI");
                }
                else if(roll == uniqueLoot)
                {
                    uniqueAmeob.SetActive(true);
                    TempAmeobScript unique = uniqueAmeob.GetComponent<TempAmeobScript>();
                    unique.ameobAmount++;
                }
            }
            
            
        }
        else
        // if the player does not have enough coins this happens
        {
            Debug.Log("YOU TRYNA SCAM ME BOI????????!!!!!!!!!");
        }
    }
}
