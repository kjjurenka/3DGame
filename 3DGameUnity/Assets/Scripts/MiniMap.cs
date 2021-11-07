/***
 * Author: Kami Jurenka
 * Date Created: 10/25/2021
 * Date Modified: 10/25/2021
 * Description: Behaviors for minimap camera, including following the player
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
    public int HeadRoom;

    private void LateUpdate()
    {
        Vector3 newPos = player.position;//record pos of player
        newPos.y = player.position.y + HeadRoom;//resets camera y
        transform.position = newPos;//repositions camera

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); // rotates camera based on player
    }
}
