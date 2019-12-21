using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public GameObject player;
    private int nextScene;
    public bool isPlayerHere = false;
    public Color inRange;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        if(isPlayerHere == true && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            isPlayerHere = true;
        }
    }

}
