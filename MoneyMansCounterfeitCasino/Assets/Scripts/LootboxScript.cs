using System.Collections;
using System.Collections.Generic;
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
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LootBoxRoll()
    {
        if(gm.coins >= cost)
        {
            gm.coins -= cost;
            float roll = Random.Range(1, 100);
            if(roll > rarity)
            {
                Debug.Log("Confetti");
            }
            else if(roll <= rarity)
            {
                int ameobRoll = Random.Range(0, possibleAmeobs.Length);
                Instantiate(possibleAmeobs[ameobRoll], spawnPos.position, spawnPos.rotation);
            }
        }
        else
        {
            Debug.Log("YOU TRYNA SCAM ME BOI????????!!!!!!!!!");
        }
    }
}
