using System.Collections.Generic;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence() : base(){}
        
		public Sequence(List<Node> children) : base(children){}

        public override NodeState Evaluate()
		{
            bool runningChild = false;
            foreach (Node node in children) {
                switch (node.Evaluate()) {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.COMPLETED:
                        continue;
                    case NodeState.RUNNING:
                        runningChild = true;
                        continue;
                    default:
                        state = NodeState.COMPLETED;
                        return state;
                }
            }
            state = runningChild ? NodeState.RUNNING : NodeState.COMPLETED;
            return state;
        }
    }
}