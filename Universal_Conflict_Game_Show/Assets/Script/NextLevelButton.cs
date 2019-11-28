using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && Input.GetKeyDown(KeyCode.X))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

}
