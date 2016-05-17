using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	GUIStyle gianttext = new GUIStyle();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		print (PlayerControl.currentLevel);
		Application.LoadLevel (PlayerControl.currentLevel);
	}
}
