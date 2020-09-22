﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    bool driving=false;
    bool LookingBack=false;
    bool LookingPC=true;
    bool LookingBehind=false;
    Animator m_Animator;
    bool animate;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   

        //Look at pc
        if (Input.GetKeyUp(KeyCode.LeftShift) && animate && !LookingBehind && !LookingBack)
        {
            //Press the up arrow button to reset the trigger and set another one
            if (!LookingPC && driving)
            {
                //Send the message to the Animator to activate the trigger parameter named "LookBackTrigger"
                m_Animator.SetTrigger("LookPCTrigger");
                LookingPC=!LookingPC;
                driving=true;
            }

            else if(LookingPC)
            {
                //Send the message to the Animator to activate the trigger parameter named "LookBackTrigger"
                m_Animator.SetTrigger("LookPCTrigger");
                LookingPC=!LookingPC;
                driving=true;
            }
        }


        //Look behind
        if (Input.GetKeyUp(KeyCode.E) && animate && !LookingPC && !LookingBehind)
        {
            if (!LookingBack && driving)
            {
                //Send the message to the Animator to activate the trigger parameter named "LookBackTrigger"
                m_Animator.SetTrigger("LookBackTrigger");
                LookingBack=!LookingBack;
                driving=false;
            }

            else if(LookingBack)
            {
                //Send the message to the Animator to activate the trigger parameter named "LookBackTrigger"
                m_Animator.SetTrigger("LookBackTrigger");
                LookingBack=!LookingBack;
                driving=true;
            }
        }

        //Look back
        if (Input.GetKeyUp(KeyCode.Q) && animate && !LookingPC && !LookingBack)
        {
            //Press the up arrow button to reset the trigger and set another one
            if (!LookingBehind && driving)
            {
                //Send the message to the Animator to activate the trigger parameter named "LookBackTrigger"
                m_Animator.SetTrigger("LookBehindTrigger");
                LookingBehind=!LookingBehind;
                driving=false;
            }

            else if(LookingBehind)
            {
                //Send the message to the Animator to activate the trigger parameter named "LookBackTrigger"
                m_Animator.SetTrigger("LookBehindTrigger");
                LookingBehind=!LookingBehind;
                driving=true;
            }
        }
    }

    public void AnimManagerActivate()
    {
        animate=true;
    }

    public void AnimManagerDeactivate()
    {
        animate=false;
    }
}