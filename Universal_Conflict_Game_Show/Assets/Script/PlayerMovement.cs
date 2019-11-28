using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    public float moveSpeed = 5.0f;

    //Bullet Activation
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotSpeed, 0);

        transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            BulletSpawm();
        }
    }

    public void BulletSpawm()
    {
        //Bullet Initiation
        GameObject TempBullHandle;
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
