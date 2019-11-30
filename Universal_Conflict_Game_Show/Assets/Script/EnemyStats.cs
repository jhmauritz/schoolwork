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

        if(player == null)
        {
            Debug.Log("They just vanished!");
        }
    }

    private void PositionHealthBar()
    {
        Vector3 currPos = transform.position;

        healthBar.position = new Vector3(currPos.x, currPos.y + healthBarYOffset, currPos.z);

        healthBar.LookAt(player.transform);

        if (player == null)
        {
            Debug.Log("They just vanished!");
        }
    }

    //Make a new bullet script that sees the capsule collider and runs through it and does damage a different way
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BullRefPlayer>())
        {
            ChangeHealth(-2);
        }

        if (other.gameObject.GetComponent<TrapRef>())
        {
            ChangeHealth(-1);
        }
    }
}
