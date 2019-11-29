using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndPlayer : MonoBehaviour
{
    public Shader baseShader;
    public Shader fadeShader;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered the trigger");

        if (other.gameObject.GetComponent<PlayerNavPoint>())
        {
            GetComponent<Renderer>().material.shader = fadeShader;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has exited the trigger");

        if (other.gameObject.GetComponent<PlayerNavPoint>())
        {
            GetComponent<Renderer>().material.shader = baseShader;
        }
    }
}
