using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttobi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-750f , 0 , 0 ));
    }
}
