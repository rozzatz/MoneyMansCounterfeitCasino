using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject camera;

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
        if (shopWindow.activeInHierarchy)
        {
            shopWindow.SetActive(false);
            camera.transform.position = new Vector3(0, 1, -10);
        }
        else if(shopWindow.activeInHierarchy == false)
        {
            shopWindow.SetActive(true);
            camera.transform.position = new Vector3(0, 1000, -10);
        }

            camera.transform.position = new Vector3(0, 1000, -10);
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);
        camera.transform.position = new Vector3(0, 1, -10);
    }


}
