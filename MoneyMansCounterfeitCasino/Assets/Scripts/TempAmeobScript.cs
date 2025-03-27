using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempAmeobScript : MonoBehaviour
{
    private GameManager gm;

    private LootTable loot;

    public int cost;//delete later


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        loot = GetComponent<LootTable>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnMouseDown()
    {
        if(gm.coins >= cost)
        {
            gm.coins -= cost;
            loot.BasicLootCalc();

            gm.coins += loot.lootResult;
        }
        else
        {
            Debug.Log("I don't deal with poors");
        }
            
        
    }
}
