using UnityEngine;
using System.Collections;

public class EnemyContoller : MonoBehaviour {

	public GameObject FirePrefabRight;
	public GameObject FirePrefabLeft;
	public GameObject FirePrefabUp;
	public GameObject FirePrefabDown;

	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", 0.2f, 2f);
	}

	void Fire () {

		int rand = Random.Range (1, 5);

		GameObject firePrefab = FirePrefabRight;

		switch (rand) {
			case 1:
				firePrefab = FirePrefabRight;
				break;
			case 2:
				firePrefab = FirePrefabLeft;
				break;
			case 3:
				firePrefab = FirePrefabUp;
				break;
			case 4:
				firePrefab = FirePrefabDown;
				break;
		}

		animator.SetTrigger ("Shot");
		Instantiate (firePrefab, transform.position, Quaternion.identity);
	}

//	void OnCollisionEnter2D (Collision2D col){
//		if (col.gameObject.tag == "Player") {
//			ScoreManager.score -= 2;
//		}
//	}
}
