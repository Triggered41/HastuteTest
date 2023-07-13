using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static IdleState idleState = new IdleState();
    public static WalkState walkState = new WalkState();
    public static AttackState attackState = new AttackState();
    public static IState currentState = idleState;
    public Transform player;
    public Animator anim;
    void Start()
    {
        IState.player = player;
        IState.enemy = transform;
        IState.anim = anim;
        
        currentState = idleState;
        currentState.Enter();
        StartCoroutine("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.Update() != null){
            currentState = currentState.Update();
            currentState.Enter();
        }
    }

    IEnumerator a(){
        yield return new WaitForSeconds(1f);
        print("COOL");
    }
}
