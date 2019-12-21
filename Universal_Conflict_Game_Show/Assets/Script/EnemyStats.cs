using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : Stats
{
    public float healthBarYOffset = 2;
    public GameObject player;
    public float rotationSpeed = 2;
    public GameObject hitmarker;

    public override void Awake()
    {
        base.Awake();
        hitmarker.SetActive(false);
    }

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
            damageAudioHolder.GetComponent<AudioSource>().Play();
            HitMakrker(0.05f);
        }

        if (other.gameObject.GetComponent<TrapRef>())
        {
            ChangeHealth(-1);
            damageAudioHolder.GetComponent<AudioSource>().Play();
        }
    }

    private void HitMakrker(float showTime)
    {
        StartCoroutine(ShowHitTime(showTime));

    }

    IEnumerator ShowHitTime(float hitTime)
    {
        hitmarker.SetActive(true);
        yield return new WaitForSeconds(hitTime);
        hitmarker.SetActive(false);

    }
}
