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
            ChangeHealth(-2);
        }

        if (other.gameObject.GetComponent<TrapRef>())
        {
            ChangeHealth(-2);
        }
    }
}
