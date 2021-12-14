/*
 * Author: Kami Jurenka
 * Date Created: 12/9/2021
 * Date Modified: 12/9/2021
 * Description: Start Timer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public static float timeRemaining;
    bool start = false;
    private void Update()
    {
        if (start)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        timeRemaining = 120f;
        if (timeRemaining > 0 && CollectItems.Collectables == 6)
        {
            GameManager.startTimer();
            start = true;
            CollectItems.CollectingHealth = true;
           
        }
        
    }
}
