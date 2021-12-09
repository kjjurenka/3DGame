using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public static bool NPCtalking = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        NPCtalking = true;
    }
}
