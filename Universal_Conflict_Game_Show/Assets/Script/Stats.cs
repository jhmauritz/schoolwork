using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject controller;

    public Transform healthBar;
    public Slider healthFill;

    public float currHealth;
    public float maxHealth = 20;

    public virtual void Awake()
    {
        currHealth = maxHealth;
    }



    public virtual void Update()
    {
        if (currHealth <= 0)
        {
            Debug.Log("Is Dead I Swear!");

            Destroy(controller);
        }
    }

    public void ChangeHealth(int amount)
    {
        currHealth += amount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);

        healthFill.value = currHealth;
    }
}
