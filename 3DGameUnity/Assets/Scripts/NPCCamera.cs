/***
 * Author: Kami Jurenka
 * Date Created: 10/25/2021
 * Date Modified: 10/25/2021
 * Description: Behaviors for minimap camera, including following the player
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCamera : MonoBehaviour
{
    public Transform NPCLocation;
    public int HeadRoom;

    private void LateUpdate()
    {
        
        Vector3 newPos = NPCLocation.position;//record pos of player
        newPos.x = NPCLocation.position.x + HeadRoom;//resets camera x
        transform.position = newPos;//repositions camera

        transform.rotation = Quaternion.Euler(0f, -NPCLocation.eulerAngles.y, 0f); // rotates camera based on player
    }
}
