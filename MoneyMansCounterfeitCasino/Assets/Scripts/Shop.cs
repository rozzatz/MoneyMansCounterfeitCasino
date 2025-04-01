using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject shopWindow;
    // Start is called before the first frame update
    void Start()
    {
        shopWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        shopWindow.SetActive(true);
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);
    }


}
