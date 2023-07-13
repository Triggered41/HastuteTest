using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    static Animator anim;
    static Transform player;
    static Transform enemy;
    void Enter();
    IState Update();
}
