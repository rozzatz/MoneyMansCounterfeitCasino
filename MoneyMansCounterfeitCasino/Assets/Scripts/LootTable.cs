using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public int lootResult;
    public int lowestValue;
    public int highestValue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //placeholder calculations for the loot baby
    public void BasicLootCalc()//for those of you just joining, calc is short for calculator
    {
        lootResult = Random.Range(lowestValue, highestValue);
        
    }
}
