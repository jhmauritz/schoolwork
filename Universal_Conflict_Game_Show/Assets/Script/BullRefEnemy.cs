using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullRefEnemy : MonoBehaviour
{
    public bool isHit = false;

    void Update()
    {
        if (isHit == true)
        {
            Destroy(gameObject);
        }

        else if (isHit == false)
        {
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WallRef>())
        {
            isHit = true;
        }

        if (other.gameObject.GetComponent<PlayerStats>())
        {
            isHit = true;
        }
    }
}
