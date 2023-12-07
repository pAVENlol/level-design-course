using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public GameObject connectedObject;
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(connectedObject);
            Debug.Log("hit");
        }
    }
}
