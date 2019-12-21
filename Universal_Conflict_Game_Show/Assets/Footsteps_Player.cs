using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps_Player : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioS;
    public AudioClip ac;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 1f && audioS.isPlaying == false)
        {
            audioS.Play();
            Debug.Log("Footsteps playing");
        }
    }
}
