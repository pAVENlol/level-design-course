using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{

    public GunScript gun1;

    public Shotgun gun2;
    public GranadeLauncher gun3;

    public GameObject Gun;



    bool hasGun1 = false;
    bool hasGun2 = false;
    bool hasGun3 = false;


    bool gun1Active = false;
    bool gun2Active = false;

    bool gun3Active = false;

    

    // Update is called once per frame
    void Update()
    {
        if(hasGun1 == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun1Active = true;
            gun2Active = false;
            gun3Active = false;
            Gun.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if(hasGun2 == true && Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun1Active = false;
            gun2Active = true;
            gun3Active = false;
            Gun.GetComponent<Renderer>().material.color = Color.blue;
        }

        if(hasGun3 == true && Input.GetKeyDown(KeyCode.Alpha3))
        {
            gun1Active = false;
            gun2Active = false;
            gun3Active = true;
            Gun.GetComponent<Renderer>().material.color = Color.green;
        }


        if(gun1Active == true)
        {
            gun1.enabled = true;
        }
        else
        {
            gun1.enabled = false;
        }

         if(gun2Active == true)
        {
            gun2.enabled = true;
        }
        else
        {
            gun2.enabled = false;
        }

         if(gun3Active == true)
        {
            gun3.enabled = true;
        }
        else
        {
            gun3.enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("gun1Pickup"))
        {
            hasGun1 = true;
            gun1Active = true;
            gun2Active = false;
            gun3Active = false;
            Destroy(other.gameObject);
            Gun.GetComponent<Renderer>().material.color = Color.yellow;
            
            Debug.Log("Works");
            
        }
        if(other.gameObject.CompareTag("gun2Pickup"))
        {
            hasGun2 = true;
            gun2Active = true;
            gun1Active = false;
            gun3Active = false;
            Destroy(other.gameObject);
            Gun.GetComponent<Renderer>().material.color = Color.blue;
            
            
        }
        if(other.gameObject.CompareTag("gun3Pickup"))
        {
            hasGun3 = true;
            gun3Active = true;
            gun2Active = false;
            gun1Active = false;
            Destroy(other.gameObject);
            Gun.GetComponent<Renderer>().material.color = Color.green;
            
            
        }
    }
}
