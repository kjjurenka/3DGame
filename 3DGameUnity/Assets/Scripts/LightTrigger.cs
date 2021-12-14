using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject Light;
    bool PressF = false;
    private void Awake()
    {
        Light.GetComponent<Light>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Light.GetComponent<Light>().enabled = true;
        if (PressF == false)
        {
            GameManager.CanSpeak();
            PressF = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Light.GetComponent<Light>().enabled = false;
    }
}
