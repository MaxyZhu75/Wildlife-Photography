using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BehaviorTree;

public class hangAroundBear : Node
{
    private Transform NPC;
	private Animator animationController;
    private Rigidbody rigid;
    public float velocity;
    public float time;
    public Vector3 direction;
	public int status;
	public int rotate;
    public Boundary boundary;
	public class Boundary {
        public float xMin;
        public float xMax;
        public float zMin;
        public float zMax;
    }

    public hangAroundBear(Transform transform)
	{
		NPC = transform;
        animationController = NPC.GetComponent<Animator>();
		rigid = NPC.GetComponent<Rigidbody>();
		velocity = 0.0f;
		time = 0.0f;
        direction = new Vector3(0.0f, 0.0f, 0.0f);
		status = Random.Range(0, 5);
        boundary = new Boundary(){xMin=0, xMax=299, zMin=0, zMax=299};
    }

    public override NodeState Evaluate()
	{
		time += Time.deltaTime;
		if (status == 0) {
			animationController.SetBool("Sleep", true);
			if (time > 8) {
				time = 0;
				status = Random.Range(0, 5);
				animationController.SetBool("Sleep", false);
			}
		} else if (status == 1) {
			animationController.SetBool("Sit", true);
			if (time > 8) {
				time = 0;
				status = Random.Range(0, 5);
				animationController.SetBool("Sit", false);
			}
		} else if (status == 2) {
			animationController.SetBool("Eat", true);
			if (time > 8) {
				time = 0;
				status = Random.Range(0, 5);
				animationController.SetBool("Eat", false);
			}
		} else if (status == 3) {
			animationController.SetBool("WalkForward", true);
			velocity = 1.0f;
			if (time == Time.deltaTime) rotate = Random.Range(0, 2);
			if (time>6.0f && time<6.1f) rotate = Random.Range(0, 2);
			if (rotate == 0) {
				if (time>3 && time<9) {
					direction = new Vector3(0.0f, 0.5f, 0.0f);
					NPC.Rotate(direction, Space.Self);
				}
			} else {
				if (time>3 && time<9) {
					direction = new Vector3(0.0f, -0.5f, 0.0f);
					NPC.Rotate(direction, Space.Self);
				}
			}
			NPC.position += NPC.forward * velocity * Time.deltaTime;
			if (time > 12) {
				time = 0;
				status = Random.Range(0, 5);
				animationController.SetBool("WalkForward", false);
			}
		} else {
			animationController.SetBool("Idle", true);
			if (time > 3) {
				time = 0;
				status = Random.Range(0, 5);
				animationController.SetBool("Idle", false);
			}
		}
		
		if (rigid != null) { 
            float tempX = Mathf.Clamp(NPC.position.x, boundary.xMin, boundary.xMax);
            float tempZ = Mathf.Clamp(NPC.position.z, boundary.zMin, boundary.zMax);
            NPC.position = new Vector3(tempX, NPC.position.y, tempZ);
        }
		
        state = NodeState.RUNNING;
        return state;
    }
}