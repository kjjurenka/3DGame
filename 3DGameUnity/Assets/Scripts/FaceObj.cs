/***
 * Created by: Kami Jurenka
 * Date Created: 9/20/2021
 * 
 * Last Edited: 11/8/2021
 * 
 * Description: define which object the game object will face towards
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObj : MonoBehaviour
{
    /***Variables***/
    public Transform ObjToFace = null;
    public bool FacePlayer;
    public Collider AnimationTrigger;


    private void Awake()
    {
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");


        if (PlayerObj != null)
        {
            ObjToFace = PlayerObj.transform;
        }
    }//End Awake

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (FacePlayer == true)
        {
            if (ObjToFace == null) { return; }

            Vector3 DirToObj = ObjToFace.position - transform.position;

            if (DirToObj != Vector3.zero)
            {
                transform.localRotation = Quaternion.LookRotation(DirToObj.normalized, Vector3.up);
            }
        }
    }//End Update
}

