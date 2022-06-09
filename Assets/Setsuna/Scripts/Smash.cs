using System;
using UnityEngine;

namespace Sample
{
    public class Smash : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            other.attachedRigidbody.AddForce(new Vector3(20, 10), ForceMode.Impulse);
        }
    }
}