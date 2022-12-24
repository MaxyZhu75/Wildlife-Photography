using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class goAttackBear : Node
{
    private Transform _lastTarget;
    private Animator animationController;
    
    public goAttackBear(Transform transform, Transform[] targets)
    {
        animationController = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
	{
        GameObject.Find("GamePlayControl").GetComponent<ChapterControl>().isAttacked = true;
        state = NodeState.RUNNING;
        return state;
    }
}