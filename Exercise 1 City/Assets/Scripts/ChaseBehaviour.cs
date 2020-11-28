using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour {

    GameObject gameObject;

    AI aiController;

    int navTimer = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        gameObject = animator.gameObject;
        aiController = animator.gameObject.GetComponent<AI>();
        navTimer = 0;
        aiController.SetColor(Color.yellow);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (navTimer > 10) {
            navTimer = 0;
            aiController.Chase();
        }
        navTimer++;

        if (aiController.InAttackRange())
            animator.SetBool("inAttackRange", true);

        if (!aiController.IsPlayerVisible()) {
            Debug.Log("lost track of player");
            aiController.GetNextPatrolTarget();
            animator.SetBool("isPlayerVisible", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        aiController.ClearNav();
    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

}