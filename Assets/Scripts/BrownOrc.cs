using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOrc : MonoBehaviour {
	private Rigidbody2D myBody;
	public float WalkSpeed;
	public float offset;
	private Vector3 pointA;
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	private Vector3 pointB;



	public enum Mode {
		GoToA,
		GoToB,
		Attack,
		Die
	}

	Mode mode = Mode.GoToA;

	void FixedUpdate()
	{
		if (mode == Mode.Attack)
			return;
		float value = this.getDirection ();

		if (value < 0)
		{
			spriteRenderer.flipX = false;
		}
		else if (value > 0)
		{
			spriteRenderer.flipX = true;
		}
		if (RabbitInsideZone ()) {
			mode = Mode.Attack;
		} else if (mode == Mode.Attack) {
			mode = Mode.GoToB;
		}

		Vector2 vel = myBody.velocity;

		SetAnimatorWalk ();
		vel.x = value * WalkSpeed;
		myBody.velocity = vel;

		if (IsArrived())
			mode = mode == Mode.GoToA ? Mode.GoToB : Mode.GoToA;

		ReturnToPatrolZone ();
	}

	public void Attack()
	{
		StartCoroutine (Attacking ());
	}

		private void ReturnToPatrolZone()
	{
		if (transform.position.x < pointA.x)
			mode = Mode.GoToB;
		else if (transform.position.x > pointB.x)
			mode = Mode.GoToA;
	}

	private IEnumerator Attacking()
	{
		mode = Mode.Attack;
		animator.SetBool ("Attack", true);
		yield return new WaitForSeconds (0.3f);
		Rabbit.current.RabbitDeath ();
		mode = Mode.GoToB;
	}

	private void KeepInBounds()
	{
		if (transform.position.x < pointA.x)
		{
			mode = Mode.GoToB;
		}
		else if (transform.position.x > pointB.x)
		{
			mode = Mode.GoToA;
		}
	}
	bool IsArrived()
	{
		if (mode == Mode.GoToA)
		{
			return Mathf.Abs (transform.position.x - pointA.x) < 0.1f;
		}
		else if (mode == Mode.GoToB)
		{
			return Mathf.Abs (transform.position.x - pointB.x) < 0.1f;
		}
		else return false;
	}

	private bool RabbitInsideZone()
	{
		Vector3 rabbit_vector = Rabbit.current.transform.position;
		return rabbit_vector.x >= pointA.x && rabbit_vector.x <= pointB.x;
	}



	float getDirection() {
		if(mode == Mode.GoToA) {
			return -1; 
		} else if(mode == Mode.GoToB) {
			return 1;
		}
		return 0;
	}

	void SetAnimatorWalk()
	{
		animator.SetBool ("Walk", true);
		animator.SetBool("Attack", false);
	}

	void Start()
	{
		myBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		pointA = transform.position;
		pointB = new Vector3(pointA.x + offset, pointA.y, pointA.z);

	}
}