using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {
	public static Rabbit current;
	public float speed = 1;
	Rigidbody2D myBody = null;
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	private bool growthOfRabbit = false;
	private bool dead = false;
	private float respawnDelay= 1f;
	private float respawnTimeLeft = 0f;

	public void makeBigger(){
		if (!growthOfRabbit) {
			transform.localScale = new Vector3 (1.2f, 1.2f, 0);
			growthOfRabbit = true;
		}
	}

	public void makeLower(){
		if (growthOfRabbit) {
			transform.localScale = new Vector3 (1f, 1f, 0);
			growthOfRabbit = false;
		} else {
			RabbitDeath ();

		}
	}

	public void RabbitDeath () {
		if (dead)
			return;
		GetComponent<Animator> ().SetBool ("Die", true);
		dead = true;
		respawnTimeLeft = respawnDelay;
	}

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
			LevelController.current.setStartPosition (transform.position);
		current = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(dead){
			if (respawnTimeLeft <= 0) {
				LevelController.current.onRabitDeath (GetComponent<Rabbit> ());
				GetComponent<Animator> ().SetBool ("Die", false);
				dead = false;
			} else {
				respawnTimeLeft -= Time.deltaTime;
			}
		}
	}



	void FixedUpdate () {
		if (dead)
			return;
		//[-1, 1]
		float value = Input.GetAxis ("Horizontal");

		Animator animator = GetComponent<Animator> ();
		if(Mathf.Abs(value) > 0) {
			animator.SetBool ("Run", true);
		} else {
			animator.SetBool ("Run", false);
		}

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if(value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}

		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			if(hit.transform != null
				&& hit.transform.GetComponent<MovingPlatform>() != null){
				//Приліпаємо до платформи
				transform.SetParent(hit.transform);
			}
			isGrounded = true;
		} else {
			transform.SetParent(null);
		}
		//Намалювати лінію (для розробника)
		Debug.DrawLine (from, to, Color.red);

		if(Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true;
		}
		if(this.JumpActive) {
			//Якщо кнопку ще тримають
			if(Input.GetButton("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}

		if(this.isGrounded) {
			animator.SetBool ("Jump", false);
		} else {
			animator.SetBool ("Jump", true);
		}
	}

}
