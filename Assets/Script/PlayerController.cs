using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 speed = new Vector2 (2, 2);
	public Vector2 direction = new Vector2(1, 0);
	private Rigidbody2D rb2D;
	private Vector2 movement;

	bool facingRight = true;
	bool facingUp = true;
	bool movingHorizontal = true;

	bool isFliping = false;

	void Start () {
		movement = new Vector2(speed.x * direction.x,speed.y * direction.y);
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		rb2D.velocity = movement;
	}

	void Update () {

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if (inputX > 0) {
			movingHorizontal = true;
			facingRight = true;
			direction = new Vector2(1, 0);
		} else if (inputX < 0) {
			movingHorizontal = true;
			facingRight = false;
			direction = new Vector2(-1, 0);
		}


		if (inputY > 0) {
			movingHorizontal = false;
			facingUp = true;
			direction = new Vector2(0, 1);
		} else if (inputY < 0) {
			movingHorizontal = false;
			facingUp = false;
			direction = new Vector2(0, -1);
		}

		movement = new Vector2(speed.x * direction.x,speed.y * direction.y);

	}

	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.tag == "Wall") {
			ScoreManager.score --;
			Flip();
		} else if (col.gameObject.tag == "Enemy") {
			ScoreManager.score -= 2;
			Flip();
		}
	}

	 void Flip(){
		if (movingHorizontal) {
			facingRight = !facingRight;
			if (facingRight) {
				direction = new Vector2 (1, 0);
			} else {
				direction = new Vector2 (-1, 0);
			}
		} else {
			facingUp = !facingUp;
			if (facingUp) {
				direction = new Vector2 (0, 1);
			} else {
				direction = new Vector2 (0, -1);
			}
		}

		movement = new Vector2(speed.x * direction.x,speed.y * direction.y);
	}
}
