/***
 * Created by: Kami Jurenka
 * Date Created: 9/29/2021
 * 
 * Last Edited: 11/17/2021
 * 
 * Description: Game manager to control global game behaviors
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    /***VARIABLES***/
    #region Game Manager Singleton
    static GameManager gm;//private
    public static GameManager GM { get { return gm; } }//public
    void CheckGameManagerIsInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
        IsPlayerDead = false;
    }// end CheckGameManagerIsInScene()
    #endregion

    public static int Score;
    public static bool Speak;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public TMP_Text NPCText = null;
    public TMP_Text WinnerText = null;
    public GameObject Player;
    public static bool IsPlayerDead = false;
    public Canvas myCanvas = null;
    public Canvas NPCCanvas = null;
    public bool Instructions = false;


    private void Awake()
    {
        CheckGameManagerIsInScene();


        gm.myCanvas.gameObject.SetActive(true);

    }// End Awake
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        if (Speak && !Instructions)
        {
            Instructions = true;
            StartCoroutine(Waiter());
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        /*if(Speak == true)
        {
            gm.NPCText.gameObject.SetActive(true);
        }
        else
        {
            gm.NPCText.gameObject.SetActive(false);
        }
        */

    }

    IEnumerator Waiter()
    {
        gm.NPCCanvas.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Due to certain circumstances... I no longer need this house and would like help tearing it down");
        yield return new WaitForSecondsRealtime(3);
        NPCText.SetText("Thankfully, blowing it up will be easier than it was making it, haha!" +
            " Even a simple creature like you should be able to do it");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("I'll give you a list of all the tools you'll need to set up the fuse box at the top." +
            " For your troubles you can have some of my earthly possessions I see you need");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Take all the time you need to fix up the fusebox but once you do the job, you'll only have about a minute before BOOM!" +
            " So maybe keep an eye on what you want while you're walking around");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("It's also been uninhabited for a bit sooooo try not to bother the spiders. Don't get in their personal space and they won't get in yours");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Thanks for helping me out champ!");
        yield return new WaitForSecondsRealtime(3);
        gm.NPCCanvas.gameObject.SetActive(false);
        Speak = false;
    }


    public static void WinGame()
    {
        if (gm.WinnerText != null)
        {
            gm.WinnerText.gameObject.SetActive(true);
        }
    }
}