using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcsZone : MonoBehaviour {
	public float patrolDistance;
	public float speed;
	private Rigidbody2D myBody;

	private Vector3 pointA;
	private Vector3 pointB;

	public enum Mode {
		GoToA,
		GoToB,
		Attack
		//...
	}
	Mode mode = Mode.GoToB;

	private bool isArrived(){
		float precision = 0.08f;
		if (mode == Mode.GoToA) {
			return Mathf.Abs(pointA.x - transform.position.x) < precision;
		} else if (mode == Mode.GoToB) {
			return Mathf.Abs(pointB.x - transform.position.x) < precision;
		} else
			return false;
	}

	void FixedUpdate(){
		float value = getDirection ();

/*		Animator animator = GetComponent<Animator> ();
		if(Mathf.Abs(value) > 0) {
			animator.SetBool ("Run", true);
		} else {
			animator.SetBool ("Run", false);
		} */

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if(value < 0) {
			sr.flipX = false;
		} else if(value > 0) {
			sr.flipX = true;
		}

		if (isArrived()) {
			if (mode == Mode.GoToA) {
				mode = Mode.GoToB;
			} else
				mode = Mode.GoToA;
		}
	}

	void Start(){
		myBody = this.GetComponent<Rigidbody2D> ();
		pointA = transform.position;
		pointB = new Vector3(pointA.x + patrolDistance, pointA.y, pointA.z);
	}

	float getDirection() {
		if(mode == Mode.GoToA) {
			return -1; //Move left
		} else if(mode == Mode.GoToB) {
			return 1; //Move right
		}
		return 0; //No movement
	}
}
