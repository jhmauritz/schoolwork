using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotSpeed, 0);

        transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);
    }
}
