using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
    public enum NodeState {
        COMPLETED,
        FAILURE,
        RUNNING
    }

	public class Node {
		// Class variables for node
		protected NodeState state;
		public Node parent;
		protected List<Node> children = new List<Node>();
		private bool aggresiveMode = false;
		private bool fleeMode = false;
		
		// Constructor1
		public Node() {
			parent = null;
		}
		
		// Constructor2
		public Node(List<Node> children) {
			foreach (Node child in children) {
				link(child);
			}
		}
		
		// Record parent and children for node
		private void link(Node node) {
			node.parent = this;
			children.Add(node);
		}
		
		// Update the state for node
		public virtual NodeState Evaluate() => NodeState.FAILURE;
		
		// Set method for the signal kept at the root node
		public void setAggresiveMode(bool status) {
			aggresiveMode = status;
		}
		
		// Get method for the signal kept at the root node
		public bool getAggresiveMode() {
			return aggresiveMode;
		}

		// Set method for the signal kept at the root node
		public void setFleeMode(bool status) {
			fleeMode = status;
		}
		
		// Get method for the signal kept at the root node
		public bool getFleeMode() {
			return fleeMode;
		}
	}
}