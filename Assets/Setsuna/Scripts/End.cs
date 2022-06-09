using System;
using UnityEngine;

namespace Sample
{
    public class End : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            other.attachedRigidbody.velocity = new Vector3();
            Debug.Log("OK!OK!OK!");
        }
    }
}