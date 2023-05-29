using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : StateMachineBehaviour
{
    public List<Vector3>  checkPoints;
    private Rigidbody2D rb;
    private Transform player;
    private int currentCheckpoint;
    public float speed = 60;
    public float minDistance = 1;
    private Transform enemy;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        checkPoints = GetCheckpoint(animator);

        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        enemy  = animator.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private List<Vector3> GetCheckpoint(Animator animator){
      
        return animator.gameObject.GetComponent<checkpointHolder>().checkPoints.ConvertAll(x => x.position);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var enemyPos = enemy.position;
        var target = checkPoints[currentCheckpoint];
        var direction = (target - enemyPos).normalized;
        enemyMovement.MoveEnemy(rb, target, enemyPos, speed);

        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.SetRotation(rotation_z - 90);

         if(Vector3.Distance(enemyPos, target) < minDistance)
         {
            currentCheckpoint = (currentCheckpoint + 1) % checkPoints.Count;
         }

        var right = enemy.right *2;
        var forward = enemy.up * 4;
        var triPointRight = enemyPos + forward + right;
        var triPointLeft = enemyPos + forward - right;

        Debug.DrawLine(enemyPos, triPointLeft);
        Debug.DrawLine(enemyPos, triPointRight);

        if(IsPointInTriangle(enemyPos, triPointLeft, triPointRight, player.position)){
            animator.SetBool("IsChasing", true);
        }


    }

        bool IsPointInTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
        {
        Vector3 d, e;
        float w1, w2;
        d = b - a;
        e = c - a;
        w1 = (e.x * (a.y - p.y) + e.y * (p.x - a.x)) / (d.x * e.y - d.y * e.x);
        w2 = (p.y - a.y - w1 * d.y) / e.y;
        return (w1 >= 0.0) && (w2 >= 0.0) && ((w1 + w2) <= 1.0);
        }
}
