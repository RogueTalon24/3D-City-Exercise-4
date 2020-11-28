using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : StateMachineBehaviour {

    GameObject gameObject;

    AI aiController;

    float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        gameObject = animator.gameObject;
        aiController = animator.gameObject.GetComponent<AI>();
        timer = aiController.GetFireTimer();
        //aiController.SetColor(Color.red);
        animator.SetBool("reloaded", false);

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            aiController.Fire();
            animator.SetInteger("ammo", animator.GetInteger("ammo") - 1);
            timer = aiController.GetFireTimer();
        }
        if (aiController.InAttackRange()) {
            gameObject.transform.LookAt(aiController.player.transform);
        }
        else {
            animator.SetBool("inAttackRange", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

}