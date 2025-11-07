using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject launchPoint;
    private float speed = 300;

    public void ShootBall()
    {
        GameObject ball = Instantiate(sphere, launchPoint.transform.position, launchPoint.transform.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }
}