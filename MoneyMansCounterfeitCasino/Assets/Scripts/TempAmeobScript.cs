using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TempAmeobScript : MonoBehaviour
{
    private GameManager gm;
    public GameObject infoBackground;
    

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
        
        
    }

    public void TapAmeob()
    {
        //transfer onmousedown here later
        ameobAmount -= 1;
        loot.BasicLootCalc();
        gm.coins += loot.lootResult;
    }
}
