using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessageTriggers : MonoBehaviour
{
    public GameObject player;

    //UI text to be activated with the triggers
    public GameObject textUI;

    //triggers to be activate texts
    public GameObject triggerUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            textUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            textUI.SetActive(false);
        }
    }
}
