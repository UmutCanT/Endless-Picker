using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCheck : MonoBehaviour
{
    public static event Action OnLevelComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnLevelComplete();
        }
    }
}
