using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveToTargetBehaviour : StateMachineBehaviour {

    GameObject gameObject;

    AI aiController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        gameObject = animator.gameObject;
        aiController = animator.gameObject.GetComponent<AI>();

        aiController.OnTarget = false;
        //aiController.SetColor(Color.blue);
        aiController.MoveToTarget();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //check Patrol Target
        if (Vector3.Distance(gameObject.transform.position, aiController.PatrolTarget.position) <= 1f) animator.SetBool("onTarget", true);

        //check player visibility
        if (aiController.IsPlayerVisible()) animator.SetBool("isPlayerVisible", true);
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