using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    public static event Action OnLevelPass;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnLevelPass();
        }
    }
}
