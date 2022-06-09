using System;
using UnityEngine;

namespace Sample
{
    public class Goal : MonoBehaviour
    {
        public static bool goal;
        public void OnTriggerEnter(Collider other)
        {
            Sample.goal = true;
            Debug.Log("OK!OK!OK!");
        }
    }
}