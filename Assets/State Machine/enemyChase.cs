using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChase : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private Transform enemy;
    private Transform player;
    public float speed = 60;

    private float startTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        enemy  = animator.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startTime = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      enemyMovement.MoveEnemy(rb, player.position, enemy.position, speed);
      if(Time.time - startTime > 5){
        animator.SetBool("IsChasing", false);
      }

    }

}
