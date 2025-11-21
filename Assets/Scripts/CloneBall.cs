using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public Vector3 startPos;
    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        transform.position += new Vector3(0f, 0f, -0.05f);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
        }
    }
}