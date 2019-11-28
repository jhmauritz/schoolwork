﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //NavPoints for the enemy to Patrol
    public NavPoint[] myNavPoints;
    private int navIndex = 0;

    //Player Nav System
    public PlayerNavPoint[] myPlayerNavPoints;
    private int playerIndex = 0;
    
    //The NavMesh Agent
    public NavMeshAgent agent;

    //Moving the enemy towards the player
    public bool isPlayerHere = false;

    //Bullet Activation
    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerNavPoint>())
        {
            isPlayerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerNavPoint>())
        {
            isPlayerHere = false;
        }
    }

    private void Update()
    {
        PlayerHere();

        if(isPlayerHere == true)
        {
            BulletSpawm();
        }
    }

    private void PlayerHere()
    {
        if (isPlayerHere)
        {
            FollowSystem();
        }

        else
        {
            PatrolSystem();
        }
    }

    public void PatrolSystem()
    {
        //check to see if array is empty
        if (myNavPoints.Length == 0)
        {
            Debug.Log("No Places to go!");
        }

        agent.SetDestination(myNavPoints[navIndex].transform.position); 
    }

    public void FollowSystem()
    {
        //check to see if array is empty
        if(myPlayerNavPoints.Length == 0)
        {
            Debug.Log("Nothing in here!");
        }

        agent.SetDestination(myPlayerNavPoints[playerIndex].transform.position);
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
