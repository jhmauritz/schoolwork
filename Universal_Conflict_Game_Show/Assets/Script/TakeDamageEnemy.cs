using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnemy : MonoBehaviour
{
    EnemyStats es;
    public GameObject bullet;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletReference>())
        {
            Debug.Log("it hit!!!");
        }
    }
}
