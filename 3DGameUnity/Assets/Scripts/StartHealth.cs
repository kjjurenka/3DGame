using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollectItems.CollectingHealth = true;
    }
}
