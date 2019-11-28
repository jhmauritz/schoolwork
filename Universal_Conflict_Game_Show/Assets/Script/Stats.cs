using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject controller;

    public Transform healthBar;
    public Slider healthFill;

    public float currHealth;
    public float maxHealth = 20;

    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed;

    public virtual void Awake()
    {
        currHealth = maxHealth;
    }



    public virtual void Update()
    {
        if (currHealth <= 0)
        {
            Debug.Log("Is Dead I Swear!");

            Destroy(controller);
        }
    }

    public virtual void BulletSpawm()
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

    public void ChangeHealth(int amount)
    {
        currHealth += amount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);

        healthFill.value = currHealth;
    }
}
