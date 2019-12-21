using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    public GameObject enemy;
    public Image damageImage;
    public GameObject hitmarker;

    public bool isPlayerDamaged= false;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;

    private bool onFire;

    public override void Update()
    {
        base.Update();

        if (isPlayerDamaged == true)
        {
            damageImage.color = flashColour;
        }

        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        isPlayerDamaged = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BullRefEnemy>())
        {
            ChangeHealth(-2);
            damageAudioHolder.GetComponent<AudioSource>().Play();
            isPlayerDamaged = true;
        }

        if (other.gameObject.GetComponent<TrapRef>())
        {
            damageAudioHolder.GetComponent<AudioSource>().Play();
            isPlayerDamaged = true;

            DamageOverTime(2, 2);
        }
    }

    public void DamageOverTime(int damageAmount, int damageTime)
    {
        StartCoroutine(DoFireDamage(damageAmount, damageTime));
    }

    IEnumerator DoFireDamage(float damageAmount, float duration)
    {
        float amountDamaged = 0;
        float damagePerLoop = damageAmount / duration;
        while(amountDamaged < damageAmount)
        {
            currHealth -= damagePerLoop;
            amountDamaged += damagePerLoop;

            healthFill.value = currHealth;
            yield return new WaitForSeconds(1f);
        }

    }
}
