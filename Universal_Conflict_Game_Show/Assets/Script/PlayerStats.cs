using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed;
    GameObject TempBullHandle;

    public override void Awake()
    {
        base.Awake();
    }
    
    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.E))
        {
            //Bullet Initiation
            TempBullHandle = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
            TempBullHandle.SetActive(true);

            //Correct Bullet Rotation
            TempBullHandle.transform.Rotate(Vector3.left * 90);

            //Retrieve and Control Bullet RigidBody
            Rigidbody TempRigBod;
            TempRigBod = TempBullHandle.GetComponent<Rigidbody>();

            //Move Bullet Forward
            TempRigBod.AddForce(transform.forward * bulletSpeed);

            //Clean Up, Bullet Destroy 
            Destroy(TempBullHandle, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletReference>())
        {
            Debug.Log("it hit!!!");

            ChangeHealth(-2);
        }
    }
}
