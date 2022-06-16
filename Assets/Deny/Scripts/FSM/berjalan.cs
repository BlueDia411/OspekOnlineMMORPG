using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berjalan : StateMachineBehaviour
{
    private MainNPC mainNPC;
    private TriggerObject trigger;
    private DialogueManagerMahasiswa dialogueManagerMahasiswa;
    private GameObject obj;
    private GameObject objDialog;
    string tag = "Trigger";
    string tag2 = "Dialog Mahasiswa";
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         mainNPC= animator.GetComponent<MainNPC>();
         obj = GameObject.Find(tag);
         objDialog = GameObject.Find(tag2);
         trigger = obj.GetComponent<TriggerObject>();
         dialogueManagerMahasiswa = objDialog.GetComponent<DialogueManagerMahasiswa>();
        trigger.canInputBtn = true;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

        //Patroli
        if(trigger.point1 == false && trigger.point2 == false && trigger.bangku == false)
        {
            mainNPC.agent.SetDestination(trigger.transformPoint1.position);
        }
        else if (trigger.point1 == true && trigger.point2==false && trigger.bangku==false)
        {
            mainNPC.agent.SetDestination(trigger.transformBangku.position);
        }
        else if (trigger.bangku == true && trigger.point1 == true && trigger.point2 == false)
        {
            if (trigger.duduk==false)
            {
                animator.SetBool("Berjalan", false);
                animator.SetBool("Duduk", true);
                trigger.duduk = true;
            }
            else if(trigger.duduk==true)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Iddle") == true)
                {
                    mainNPC.agent.SetDestination(trigger.transformPoint2.position);
                }
                //else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Iddle") == false)
                //{
                //    mainNPC.agent.SetDestination(mainNPC.transformPoint2.position);
                //}
             
            }
            
        }
        else if((trigger.bangku == true && trigger.point1 == true && trigger.point2 == true) || (trigger.bangku == false && trigger.point1 == false && trigger.point2 == true))
        {
            trigger.point1 = false;
            trigger.point2 = false;
            trigger.bangku = false;
            trigger.duduk = false;
        }



        //Salam
        if (dialogueManagerMahasiswa.inSalam == true)
        {
            animator.SetBool("Salam", true);
        }

        //dialog
        if (dialogueManagerMahasiswa.inDialogue == true)
        {
            mainNPC.agent.isStopped = true;
            animator.SetBool("Iddle", true);
            animator.SetBool("Berjalan", false);
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
