using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class duduk : StateMachineBehaviour
{
    private MainNPC mainNPC;
    private TriggerObject trigger;
    private GameObject obj;
    string tag = "Trigger";
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainNPC = animator.GetComponent<MainNPC>();
        obj = GameObject.Find(tag);
        trigger = obj.GetComponent<TriggerObject>();

        trigger.canInputBtn = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        IEnumerator Mulai()
        {
            mainNPC.agent.isStopped = true;
            yield return new WaitForSeconds(3.5f);
            animator.SetBool("Iddle", true);
            mainNPC.agent.isStopped = false;
        }

        //posisi bangku
        float x = trigger.transformBangku.position.x;
        float y = trigger.transformBangku.position.y;
        float z = trigger.transformBangku.position.z;

        //angle bangku
        float rx = trigger.transformBangku.eulerAngles.x;
        float ry = trigger.transformBangku.eulerAngles.y;
        float rz = trigger.transformBangku.eulerAngles.z;
        Quaternion bangku = Quaternion.Euler(rx, ry, rz);

        


        mainNPC.transform.localPosition = Vector3.Lerp(mainNPC.transform.localPosition, new Vector3(x, y, z+1), Time.deltaTime * 2f);
        mainNPC.transform.rotation = Quaternion.Slerp(mainNPC.transform.rotation, bangku, Time.deltaTime * 2f);

        
       

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("duduk") == true)
        {
            mainNPC.DoCoroutine(Mulai());
        }
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Duduk", false);
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
