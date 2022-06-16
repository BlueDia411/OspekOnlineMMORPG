using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Iddle : StateMachineBehaviour
{
    private MainNPC mainNPC;
    private TriggerObject trigger;
    private DialogueManagerMahasiswa dialogueManagerMahasiswa;
    private GameObject objDialog;
    private GameObject obj;
    string tag = "Trigger";
    string tag2 = "Dialog Mahasiswa";
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         mainNPC = animator.GetComponent<MainNPC>();
        obj = GameObject.Find(tag);
        objDialog = GameObject.Find(tag2);
        trigger = obj.GetComponent<TriggerObject>();
        dialogueManagerMahasiswa = objDialog.GetComponent<DialogueManagerMahasiswa>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainNPC.agent.isStopped = true;
        if (dialogueManagerMahasiswa.inDialogue == true)
        {
            mainNPC.transform.LookAt(GameObject.Find("Player").transform);
            animator.SetBool("Iddle", true);
        }
        else
        {
            animator.SetBool("Iddle", false);
            animator.SetBool("Berjalan", true);
        }
       
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Iddle", false);
        mainNPC.agent.isStopped = false;

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
