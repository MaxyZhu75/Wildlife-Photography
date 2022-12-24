using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class isInAttackZoneBear : Node
{
    private Transform NPC;
    private Transform PLAYER;
    private Animator animationController;

    public isInAttackZoneBear(Transform transform, Transform[] targets)
	{
        NPC = transform;
		PLAYER = targets[0];
        animationController = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
	{
        if (!parent.parent.getAggresiveMode()) {
            state = NodeState.FAILURE;
            return state;
        }

        if (Vector3.Distance(NPC.position, PLAYER.position) <= DTreeBear.attackRadius) {
            animationController.SetBool("Attack1", true);
            animationController.SetBool("WalkForward", false);
            state = NodeState.COMPLETED;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}