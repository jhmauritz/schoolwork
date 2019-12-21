using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject UIEnemyDead;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            SceneManager.LoadScene(6);
            
        }
    }


}
