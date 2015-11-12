using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score = 10;
	public GUISkin mySkin;
	
	void OnGUI(){
		GUI.skin = mySkin;
		GUI.Label (new Rect((Screen.width / 2) - 100, 0, 200, 40),"score :" + score );
	}
}
