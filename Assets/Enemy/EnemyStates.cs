using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{


    void AfterAttack(){
        StartCoroutine("aftert");
        Enemy.currentState = Enemy.idleState;
        
    }

    IEnumerator aftert(){
        yield return new WaitForSeconds(5f);
        IdleState.canAttack = true;
    }
}

public class IdleState: IState
{
    public static bool canAttack = true;
    public void Enter(){
        Debug.Log("Idling");
        IState.anim.CrossFade("Idle", 0.1f);
    }

    public IState Update(){

        if (Vector3.Distance(IState.player.position, IState.enemy.position) <= 1.5f && canAttack){
            return Enemy.attackState;
        }

        if (Vector3.Distance(IState.player.position, IState.enemy.position) <= 1.5f && !canAttack){
            return null;
        }

        // Transition to walk
        if (Vector3.Distance(IState.player.position, IState.enemy.position) <= 8f){
            return Enemy.walkState;
        }
        return null;
    }
}

public class WalkState: IState
{
    public void Enter(){
        Debug.Log("Walking");
        IState.anim.CrossFade("walk", 0.1f);
    }

    public IState Update(){
        IState.enemy.LookAt(IState.player);
        if (Vector3.Distance(IState.player.position, IState.enemy.position) >= 15f){
            return Enemy.idleState;
        }
        
        if (Vector3.Distance(IState.player.position, IState.enemy.position) <= 1.5f && IdleState.canAttack){
            return Enemy.attackState;
        }

        if (Vector3.Distance(IState.player.position, IState.enemy.position) <= 1.5f && !IdleState.canAttack){
            return Enemy.idleState;
        }
        return null;
    }
}

public class AttackState: IState
{
    readonly string[] attacks = {"SimpleCombo", "RunCombo", "Slash"};
    public void Enter(){
            IdleState.canAttack = false;
            var i = Random.Range(0, 3);
            Debug.Log("Attack: " + i.ToString());
            var attack = attacks[i];
            IState.anim.CrossFade(attack, 0.1f);
    }

    public IState Update(){
        return null;
    }
    public void OnAttack(){
        Debug.Log("DoneAttack");
    }

}
