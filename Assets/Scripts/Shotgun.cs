using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    
    public Transform spawnPoint;
    public float distance = 15f;

    public Transform muzzle;
    public GameObject impact;

     public GameObject bullet;

    

    Camera cam;

    public float recoilForce;

    public bool canShoot;

    public bool hasShot = false;

    public Rigidbody playerRb;

    public PlayerMovement isGrounded;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            Shoot();
            canShoot = false;
            Invoke("LaterReset", 0.2f);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && canShoot == true)
        {
            ReversetShoot();
            canShoot = false;
            Invoke("LaterReset", 0.01f);
        }

        if(isGrounded.grounded && hasShot == true)
        {

            Invoke("ResetShooting", 0.01f);

        }
        
        
    }

    void Shoot()
    {
       
        playerRb.velocity = new Vector3(0,0,0);
        playerRb.AddForce(new Vector3(-transform.forward.x, 0.5f, -transform.forward.z) * recoilForce, ForceMode.Impulse);
        
        Instantiate(bullet, muzzle.position, muzzle.rotation);

    }

    void ReversetShoot()
    {
        playerRb.velocity = new Vector3(0,0,0);
        playerRb.AddForce(new Vector3(transform.forward.x, 0.2f, transform.forward.z) * recoilForce, ForceMode.Impulse);
    }
    void ResetShooting()
    {
        canShoot = true;
        hasShot = false;
    }

    void LaterReset()
    {
        hasShot = true;
    }

    
}
