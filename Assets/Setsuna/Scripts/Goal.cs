using System;
using UnityEngine;

namespace Sample
{
    public class Goal : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("OK!OK!OK!");
        }
    }
}