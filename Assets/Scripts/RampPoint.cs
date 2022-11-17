using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampPoint : MonoBehaviour
{
    public static event Action OnJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnJump();
        }
    }
}
