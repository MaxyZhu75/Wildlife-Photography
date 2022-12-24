using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class goApproachBear : Node
{
    private Transform NPC;
    private Transform PLAYER;
    public float velocity;

    public goApproachBear(Transform transform, Transform[] targets)
	{
        NPC = transform;
		PLAYER = targets[0];
		velocity = 2.5f;
    }

    public override NodeState Evaluate()
	{
        if (Vector3.Distance(NPC.position, PLAYER.position) > DTreeBear.attackRadius) {
            NPC.position = Vector3.MoveTowards(NPC.position, PLAYER.position, velocity * Time.deltaTime);
            NPC.LookAt(PLAYER.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}