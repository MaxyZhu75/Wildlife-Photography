using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class DTreeBear : BehaviorTree.Tree
{
	public UnityEngine.Transform[] targets;
	public static float approachRadius = 15.0f;
    public static float attackRadius = 2.0f;

    protected override Node SetupTree() {
        Node root = new Selector(new List<Node> {
			new Sequence(new List<Node> {
                new isInAttackZoneBear(transform, targets),
                new goAttackBear(transform, targets),
            }),
            new Sequence(new List<Node> {
                new isInApproachZoneBear(transform, targets),
                new goApproachBear(transform, targets),
            }),
            new hangAroundBear(transform),
        });
		return root;
	}
}