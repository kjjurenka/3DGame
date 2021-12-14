/*****
 * Created by Kami Jurenka
 * Date Sept 8, 2021
 * 
 * Last edited: 11/17/2021
 * Last updated: Sept 8, 2021
 * 
 * Description: Behavior for all in game collectables
 *****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{

    /****Variables****/
    public static int Collectables = 0; //keeps track of total collectable count in scene
    public static bool CollectingHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Game Started");
        ++Collectables;//Object create, increment coin count
        //Debug.Log("Items Collected in game: " + Collectables);
    } //End Start()

    // Update is called once per frame
    void Update()
    {

    }//End Update()

    //TriggerEnter is called when GameObject enters the collider
    private void OnTriggerEnter(Collider other)
    {
        //if player collected coin then destroy object
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Health") && CollectingHealth)
            {
                GameManager.CollectableCheck(gameObject.name, gameObject.tag);
                Destroy(gameObject);//destroy self
            }
            else if (gameObject.CompareTag("Tools") && CollectingHealth == false)
            {
                GameManager.CollectableCheck(gameObject.name, gameObject.tag);
                Debug.Log("Got Tool");
                //Collectables = 7; // delete later
                Destroy(gameObject);//destroy self
            }
            else if (gameObject.CompareTag("Health") && CollectingHealth == false)
            {
                Debug.Log("We got problems");
            }
        }//End if other.CompareTag(Player)
        Debug.Log("Enter Collider");
    }

    //Called when object is destroyed
    private void OnDestroy()
    {
        --Collectables;//subtract collectables on destroy
        Debug.Log("Items Left in game: " + Collectables);

        if (Collectables <= 0 && CollectingHealth == true)
        {
            
        }
        else if(Collectables <= 6 && CollectingHealth == false)
        {
            //CollectItems.Collectables = 6;
            GameManager.GotAllItems();
        }

    }//End OnDestroy()
}

