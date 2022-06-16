using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salam : StateMachineBehaviour
{
    private MainNPC mainNPC;
    private DialogueManagerMahasiswa dialogueManagerMahasiswa;
    private GameObject obj;
    string tag = "Dialog Mahasiswa";

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainNPC = animator.GetComponent<MainNPC>();
        obj = GameObject.Find(tag);
        dialogueManagerMahasiswa = obj.GetComponent<DialogueManagerMahasiswa>();
        mainNPC.agent.isStopped = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        mainNPC.transform.LookAt(GameObject.Find("Player").transform);
        animator.SetBool("Salam", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        dialogueManagerMahasiswa.inSalam = false;
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
