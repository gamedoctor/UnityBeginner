using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal2 : MonoBehaviour
{
    public GameObject goalPtc;
    
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //Goal Particle Start
        goalPtc.SetActive(true);
        goalPtc.transform.position = other.gameObject.transform.position;
    }
}
