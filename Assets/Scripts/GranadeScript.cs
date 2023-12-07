using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GranadeScript : MonoBehaviour
{
    public Rigidbody rb;

    

    public GameObject trampoline;

    public Transform spawnPoint;

    public GranadeLauncher whenToShoot;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("StopBullet", 0.7f);

        whenToShoot = GameObject.FindGameObjectWithTag("Gun").GetComponent<GranadeLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
        
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            rb.constraints = RigidbodyConstraints.None;
            var copy = Instantiate(trampoline, spawnPoint.position, spawnPoint.rotation);
            Destroy(copy, 3f);
            Invoke("DestroyBullet", 1.1f);
        }
    }

    void StopBullet()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        
    }

       

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {

    if(other.gameObject.CompareTag("Ground"))
    {
        Destroy(gameObject);
        
        whenToShoot.canShoot = true;
    }

    }
}
