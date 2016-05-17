using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	GUIStyle gianttext = new GUIStyle();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Application.LoadLevel ("new_level1_circle_room");
	}
}
