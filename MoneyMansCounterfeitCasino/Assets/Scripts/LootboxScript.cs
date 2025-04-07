using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootboxScript : MonoBehaviour
{
    public GameObject[] possibleAmeobs;
    public float cost;
    public float rarity;
    public Transform spawnPos;
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
            if(roll > rarity)
            {
                Debug.Log("Confetti");
            }
            else if(roll <= rarity)
            {
                int ameobRoll = Random.Range(0, possibleAmeobs.Length);
                possibleAmeobs[ameobRoll].SetActive(true);
                TempAmeobScript rolledAmeob = possibleAmeobs[ameobRoll].GetComponent<TempAmeobScript>();
                rolledAmeob.ameobAmount++;

            }
        }
        else
        // if the player does not have enough coins this happens
        {
            Debug.Log("YOU TRYNA SCAM ME BOI????????!!!!!!!!!");
        }
    }
}
