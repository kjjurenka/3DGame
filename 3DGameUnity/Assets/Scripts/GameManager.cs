/***
 * Created by: Kami Jurenka
 * Date Created: 9/29/2021
 * 
 * Last Edited: 12/10/2021
 * 
 * Description: Game manager to control global game behaviors
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    //public string ScorePrefix = string.Empty;
    //public TMP_Text ScoreText = null;
    public TMP_Dropdown ToolList;
    public Image List;
    public TMP_Text ListText = null;

    [Space(10)]
    public TMP_Dropdown SuppliesList;
    public Image Supplies;

    [Space(10)]
    public Image rules;
    public Button RuleButton;
    public Button StartButton;
    public Button Back;
    public Image MainMenu;

    [Space(10)]
    public TMP_Text LoserText = null;
    public TMP_Text Objective = null;
    public TMP_Text WinnerText = null;
    public TMP_Text TimerText = null;

    [Space(10)]
    public TMP_Text NPCText = null;
    public ParticleSystem Fire;
    public ParticleSystem Sparks;
    public GameObject Player;
    public GameObject NPCGhost;
    public static bool IsPlayerDead = false;
    public Canvas myCanvas = null;
    public Canvas NPCCanvas = null;
    public bool Instructions = false;
    
    public static bool playing = false;
    int min;
    int sec;
    string zero = "";
    float minDist = .2f;
    float distance;

    [Space(10)]
    #region CheckMark Variables
    public Image WrenchCheck;
    public Image HammerCheck;
    public Image DrillCheck;
    public Image PliersCheck;
    public Image ScrewdriverCheck;
    [Space(10)]
    public Image WalkieCheck;
    public Image CanCheck;
    public Image TapeCheck;
    public Image BottleCheck;
    public Image LightCheck;
    public Image PillCheck;
    #endregion


    private void Awake()
    {
        CheckGameManagerIsInScene();


        gm.myCanvas.gameObject.SetActive(true);
        

    }// End Awake
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(NPCGhost.transform.position, Player.transform.position);
        //if (NPCTrigger.NPCtalking == true && !Instructions)
        if (!Instructions && Input.GetKeyDown(KeyCode.F) && playing)
        {
            Instructions = true;
            StartCoroutine(Waiter());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Q) && playing == false)
        {
            StartGame();
            playing = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && playing == false)
        {
            InstructionsScreen();
        }
        if (Input.GetKeyDown(KeyCode.R) && playing == false)
        {
            ShowMainMenu();
        }

        if (gm.TimerText.IsActive() == true) 
        {
            min = (int)(TimerTrigger.timeRemaining / 60);
            sec = (int)(TimerTrigger.timeRemaining % 60);
            if (sec < 10)
            {
                zero = "0";
            }
            else
            {
                zero = "";
            }
            gm.TimerText.SetText(min + ":"+ zero + sec);

            if(min ==0 && sec == 0)
            {
                gm.TimerText.gameObject.SetActive(false);
                Fire.Play();
                Sparks.Play();

                if(PlayerInTrigger.InTheHouse == true)
                {
                    LoseGame();
                }
                else
                {
                    WinGame();
                }
            }
        }
    }

    public static void InstructionsScreen()
    {
        gm.rules.gameObject.SetActive(true);
        gm.RuleButton.gameObject.SetActive(false);
        gm.Back.gameObject.SetActive(true);
    }

    public static void StartGame()
    {
        gm.MainMenu.gameObject.SetActive(false);
        gm.Objective.SetText("Talk to the ghost");
        gm.Objective.gameObject.SetActive(true);
    }

    public static void ShowMainMenu()
    {
        gm.rules.gameObject.SetActive(false);
        gm.RuleButton.gameObject.SetActive(true);
        gm.Back.gameObject.SetActive(false);
    }

    public static void startTimer()
    {
        gm.TimerText.gameObject.SetActive(true);
        gm.Objective.SetText("Get Survival Supplies and Get Out before the House Explodes!");
    }

    IEnumerator Waiter()
    {
        gm.Objective.gameObject.SetActive(false);
        gm.Objective.SetText("Collect Tools and look for survival supplies");

        gm.NPCCanvas.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Due to certain circumstances... I no longer need this house and would like help tearing it down");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Thankfully, blowing it up will be easier than it was making it, haha!" +
            " Even a simple creature like you should be able to do it");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("I'll give you a list of all the tools you'll need to set up the fuse box at the top." +
            " For your troubles you can have some of my earthly possessions I see you need");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Take all the time you need to fix up the fusebox but once you do the job, you'll only have about a couple minutes before KABLOOEY!!!");
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("So maybe keep an eye on what you want while you're walking around");
        /*yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("It's also been uninhabited for a bit sooooo try not to bother the spiders. Don't get in their personal space and they won't get in yours");
        */
        yield return new WaitForSecondsRealtime(4);
        NPCText.SetText("Thanks for helping me out champ!");
        yield return new WaitForSecondsRealtime(3);
        gm.NPCCanvas.gameObject.SetActive(false);
        Speak = false;
        gm.ToolList.gameObject.SetActive(true);
        gm.List.gameObject.SetActive(true);
        gm.ListText.SetText("Tools you'll need!");

        gm.NPCGhost.gameObject.SetActive(false);
        gm.SuppliesList.gameObject.SetActive(true);
        gm.Supplies.gameObject.SetActive(true);
        gm.Objective.gameObject.SetActive(true);
    }

    public static void CollectableCheck(string CollectableName, string ObjTag)
    {
        if (ObjTag == "Tools")
        {
            switch (CollectableName)
            {
                case "Pliers":
                    gm.PliersCheck.gameObject.SetActive(true);
                    break;
                case "Drill":
                    gm.DrillCheck.gameObject.SetActive(true);
                    break;
                case "Hammer":
                    gm.HammerCheck.gameObject.SetActive(true);
                    break;
                case "Wrench":
                    gm.WrenchCheck.gameObject.SetActive(true);
                    break;
                case "Screwdriver":
                    gm.ScrewdriverCheck.gameObject.SetActive(true);
                    break;
            }
        }
        else if (ObjTag == "Health")
        {
            switch (CollectableName)
            {
                case "walkie":
                    gm.WalkieCheck.gameObject.SetActive(true);
                    Debug.Log("Pliers!");
                    break;
                case "cannedfood":
                    gm.CanCheck.gameObject.SetActive(true);
                    break;
                case "tape":
                    gm.TapeCheck.gameObject.SetActive(true);
                    break;
                case "pills":
                    gm.PillCheck.gameObject.SetActive(true);
                    break;
                case "waterbottle":
                    gm.BottleCheck.gameObject.SetActive(true);
                    break;
                case "flashlight":
                    gm.LightCheck.gameObject.SetActive(true);
                    break;
            }
        }
    }

    public static void WinGame()
    {
        if (gm.WinnerText != null)
        {
            gm.WinnerText.SetText("Congratulations! You finished and got out with " + (6-CollectItems.Collectables)+ " collectables!");
            gm.WinnerText.gameObject.SetActive(true);
            gm.Objective.gameObject.SetActive(false);
        }
    }
    public static void LoseGame()
    {
        if(gm.LoserText != null)
        {
            gm.LoserText.gameObject.SetActive(true);
            gm.Objective.gameObject.SetActive(false);
        }
    }

    public static void CanSpeak()
    {
        gm.Objective.SetText("Press F to speak");
    }

    public static void GotAllItems()
    {
        gm.Objective.SetText("Go Upstairs to Fuse Box");
    }
}