using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	private static int totalCoin = 5;

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player") {
			totalCoin --;

			if (totalCoin <= 0 ){
				LoadNextLevel();
			}else{
				Destroy(gameObject);
			}
		}
	}
	
	void LoadNextLevel () {
		Application.LoadLevel (1);
	}
}
