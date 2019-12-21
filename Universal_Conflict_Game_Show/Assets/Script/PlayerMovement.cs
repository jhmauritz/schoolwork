using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;
    Rigidbody rb;

    //UI elements
    public GameObject enemy;
    public GameObject uiText;

    //Bullet Activation
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed;

    //Sound Effects
    public GameObject weapon;
    public float stepRate = 0.5f;
    public float stepCoolDown;
    AudioSource audioSource;
    public bool isSoundPlaying = false;

    //Bullet firerate variable
    public float FireRate = 0.75f;
    private float NextTimeToFire;

    //Lock cursor
    bool cursorLocked;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation); 

        if (Input.GetButtonDown("Fire1") && Time.time > NextTimeToFire)
        {
            BulletSpawm();
            weapon.GetComponent<AudioSource>().Play();
        }

        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            audioSource.Play();
        }

        else if (!Input.GetButtonDown("Horizontal") || !Input.GetButtonDown("Vertical"))
        {
            audioSource.Stop();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && cursorLocked == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursorLocked = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && cursorLocked == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cursorLocked = false;
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

        //Bullet FireRate
        NextTimeToFire = Time.time + FireRate;
    } 
}



