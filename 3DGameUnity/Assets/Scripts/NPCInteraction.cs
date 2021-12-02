/***
 * Created by: Kami Jurenka
 * Date Created: 11/17/2021
 * 
 * Last Edited: 11/17/2021
 * 
 * Description: Triggers the NPC's Dialogue
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Speak = true;
    }
}
