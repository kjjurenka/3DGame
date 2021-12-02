/***
 * Created by: Kami Jurenka
 * Date Created: 11/29/2021
 * 
 * Last Edited:
 * 
 * Description: Checks the name of collected object and takes it off list
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCheck : MonoBehaviour
{
    public static void CollectableCheck(string CollectableName, string ObjTag)
    {
        if(ObjTag == "Tools")
        {
            switch (CollectableName)
            {
                case "Pliers":
                    Debug.Log("Pliers works!!!");
                    break;
                case "Drill":
                    Debug.Log("Drill works!!!");
                    break;
                case "Hammer":
                    Debug.Log("Hammer works!!!");
                    break;
                case "Wrench":
                    Debug.Log("Wrench works!!!");
                    break;
                case "Screwdriver":
                    Debug.Log("Screwdriver works!!!");
                    break;
            }
        } else if(ObjTag == "Health")
        {

        }
    }
}
