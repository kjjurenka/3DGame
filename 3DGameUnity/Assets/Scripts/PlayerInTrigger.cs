/*
 * Author: Kami Jurenka
 * Date Created: 12/10/2021
 * Date Modified: 12/10/2021
 * Description: See if the player is in the trigger
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInTrigger : MonoBehaviour
{
    public static bool InTheHouse = false;
    private void OnTriggerEnter(Collider other)
    {
        InTheHouse = true;
    }

    private void OnTriggerExit(Collider other)
    {
        InTheHouse = false;
    }
}
