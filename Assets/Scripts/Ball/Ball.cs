using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.TryGetComponent(out PlatformSegment platformSegment)) return;
        if (platformSegment.transform.parent.gameObject.TryGetComponent(out FinishPlatform finishPlatform)) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
