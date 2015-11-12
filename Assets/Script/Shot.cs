using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(1, 0);
	private Rigidbody2D rb2D;
	private Vector2 movement;
	
	void Start () {
		movement = new Vector2(speed.x * direction.x,speed.y * direction.y);
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate(){
		rb2D.velocity = movement;
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.tag == "Player"){
			ScoreManager.score -= 5;
			Destroy(gameObject);
		}else if (col.tag == "Wall"){
			Destroy(gameObject);
		}
	}
}
