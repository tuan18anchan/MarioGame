using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class bossrun : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rd;
    float attackrange = 3f;
    boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rd=animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.Lookat();
        Vector2 target=new Vector2(player.position.x,rd.position.y);
        Vector2 newPos = Vector2.MoveTowards(rd.position, target, speed * Time.fixedDeltaTime);
        rd.MovePosition(newPos);
        if(Mathf.Abs(rd.position.x-player.position.x) <= attackrange && player.localPosition.y < -2.1)
        {
            boss.attack = true;
            animator.SetTrigger("danh");
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("danh");
        boss.attack = false;
    }

    
}
