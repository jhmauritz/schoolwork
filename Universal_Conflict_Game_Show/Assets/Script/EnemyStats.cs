using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : Stats
{
    public float healthBarYOffset = 2;
    public GameObject player;
    
    public override void Update()
    {
        base.Update();
        PositionHealthBar();
    }

    private void PositionHealthBar()
    {
        Vector3 currPos = transform.position;

        healthBar.position = new Vector3(currPos.x, currPos.y + healthBarYOffset, currPos.z);

        healthBar.LookAt(player.transform);
    }

    //Make a new bullet script that sees the capsule collider and runs through it and does damage a different way
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BullRefPlayer>())
        {
            ChangeHealth(-2);
        }
    }
}
