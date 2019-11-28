﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInActiveDoors : MonoBehaviour
{
    //can be either enemy or player, whoever is activating wall
    public GameObject charactercontroller;

    //the enemy that will be destroyed, deactivating the exit wall
    public GameObject enemy;

    //the wall in use if beginning section
    public GameObject begWall;

    //the wall at the end of the level
    public GameObject endWall;

    //the trigger the wall is using
    public GameObject trigger;

    public void Start()
    {
        begWall.SetActive(false);
        trigger.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == charactercontroller)
        {
            begWall.gameObject.SetActive(true);
        }

        if (other.gameObject == charactercontroller)
        {
            begWall.gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        
        IsEnemyDead();
    }

    private void IsEnemyDead()
    {
        if (enemy == null)
        {
            endWall.SetActive(false);
        }
    }
}
