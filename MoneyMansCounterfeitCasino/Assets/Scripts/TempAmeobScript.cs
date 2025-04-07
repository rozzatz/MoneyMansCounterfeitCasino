using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempAmeobScript : MonoBehaviour
{
    private GameManager gm;

    

    private LootTable loot;

    public int ameobAmount; //amount of ameobs the holder has


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        loot = GetComponent<LootTable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ameobAmount == 0)
        {
            gameObject.SetActive(false);

        }
    }

    public void OnMouseDown()
    {
        ameobAmount -= 1;
        loot.BasicLootCalc();
        gm.coins += loot.lootResult;
    }

    public void TapAmeob()
    {
        //transfer onmousedown here later
    }
}
