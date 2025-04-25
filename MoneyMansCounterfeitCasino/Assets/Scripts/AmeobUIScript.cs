using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmeobUIScript : MonoBehaviour
{
    //get the text to set the names and descriptions later

    private TempAmeobScript accessAmeob; //get the script from the parent.
    public TextMeshProUGUI ameobName;
    public TextMeshProUGUI ameobAbility;
    public TextMeshProUGUI ameobCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapAmeobButton()
    {
        accessAmeob = GetComponentInParent<TempAmeobScript>(); //take the parents tempameob script
        accessAmeob.TapAmeob();
        ameobCount.text = "Ameob Amount: " + accessAmeob.ameobAmount;
    }

    public void SacrificeAmeobButton()
    {
        accessAmeob = GetComponentInParent<TempAmeobScript>(); // same here
        accessAmeob.Sacrifice();
        ameobCount.text = "Ameob Amount: " + accessAmeob.ameobAmount;
    }


}
