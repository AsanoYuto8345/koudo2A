using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    //SET Ball prefab by GUI 
    [SerializeField] private GameObject _ballPrefab;

    //Ball Shooting Parameters
    [SerializeField] private float _shootForce = 7;
    [SerializeField] private float _coolTime = 2;

    //SET BallShooter Cube_1
    [SerializeField] private Transform _initBallPos;
    private float _timeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        _timeCounter += Time.deltaTime;
        if (_timeCounter > _coolTime)
        {
            _timeCounter = 0;
            Shoot();
        }
    }

    void Shoot() //Function for Shooting Ball
    {
        //Instantiate a ball and shoot it 
        GameObject ball = Instantiate(_ballPrefab);
        ball.transform.position = _initBallPos.position;
        ball.GetComponent<Rigidbody>().AddForce(_initBallPos.forward * _shootForce, ForceMode.Impulse);
    }
}
