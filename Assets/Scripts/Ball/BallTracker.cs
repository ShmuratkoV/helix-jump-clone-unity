using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;
    
    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        Vector3 startPosition = _ball.transform.position;
        _cameraPosition = startPosition;
        _minimumBallPosition = startPosition;
        
        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        Vector3 ballPosition = _ball.transform.position;
        beamPosition.y = ballPosition.y;
        _cameraPosition = ballPosition;
        Vector3 direction = (beamPosition - ballPosition).normalized + _directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
