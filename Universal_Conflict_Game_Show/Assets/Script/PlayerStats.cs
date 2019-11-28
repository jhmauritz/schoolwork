using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    public override void Awake()
    {
        base.Awake();
    }
    
    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.E))
        {
            BulletSpawm();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletReference>())
        {
            Debug.Log("it hit!!!");

            ChangeHealth(-2);
        }
    }
}
