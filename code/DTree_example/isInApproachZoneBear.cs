using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class isInApproachZoneBear : Node
{
    private Transform NPC;
    private Transform PLAYER;
    private Animator animationController;
    private Vector3 v;
    private float magnitude;
    
    public isInApproachZoneBear(Transform transform, Transform[] targets)
	{
        NPC = transform;
		PLAYER = targets[0];
        animationController = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
	{
        v = PLAYER.transform.position - NPC.position;
		magnitude = v.magnitude;
		if (magnitude < DTreeBear.approachRadius) {
            animationController.SetBool("WalkForward", true);
			parent.parent.setAggresiveMode(true);
			state = NodeState.COMPLETED;
            return state;
		}

        state = NodeState.FAILURE;
        return state;
    }
}