/*
 * Author: Kami Jurenka
 * Date Created: 12/9/2021
 * Date Modified: 12/9/2021
 * Description: Control Button Behavior
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Instructions()
    {
        GameManager.InstructionsScreen();
    }

    public void Begin()
    {
        GameManager.StartGame();
    }

    public void Back()
    {
        GameManager.ShowMainMenu();
    }

}
