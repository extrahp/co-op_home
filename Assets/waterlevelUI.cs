using UnityEngine;
using System.Collections;

public class waterlevelUI : MonoBehaviour {

	float waterlevel;
	public GameObject water;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float waterlevel = water.transform.position.y;
		if (waterlevel > 12f) {
			Application.LoadLevel ("GameOver");
		}
	}

//	void OnGUI() {
//		float waterlevel = water.transform.position.y;
//		string status = "Normal";
//		if (waterlevel > 13)
//			status = "Why are you still even here there is no hope for you";
//		else if (waterlevel > 12)
//			status = "Stop playing you're long dead";
//		else if (waterlevel > 11.5)
//			status = "You're basically already dead";
//		else if (waterlevel > 11)
//			status = "You feel death start filling inside of you";
//		else if (waterlevel > 10.5)
//			status = "Oh god there's water everywhere";
//		else if (waterlevel > 10)
//			status = "Danger";
//		GUI.Label (new Rect (10, 10, 100, 20), "Water Level:");
//		GUI.Label (new Rect (100, 10, 100, 20), waterlevel.ToString());
//		GUI.Label (new Rect (10, 30, 100, 20), "Status:");
//		//GUI.Label (new Rect (100, 30, 300, 20), status);
//	}
}

	