using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BullRefEnemy>())
        {
            Debug.Log("it hit!!!");

            ChangeHealth(-2);
        }
    }
}
