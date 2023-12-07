using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    public float speed = 20.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Invoke("DestroyBullet", 0.1f);
    }
 void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
