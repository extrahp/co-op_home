using UnityEngine;
using System.Collections;

public class InstructionsDialogue : MonoBehaviour {

	GUIStyle boxstyle = new GUIStyle();
	string instructions;
	bool trigger;
	int timeout = 5;
	float timer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger) {
			timer += Time.deltaTime;
		}
		if (timer >= timeout) {
			timer = 0;
			trigger = false;
		}
	}
		
	public void triggered(string ins){ 
		timer = 0;
		trigger = true;
		instructions = ins;
	}
	void OnGUI() {
		if (trigger) {
			GUI.Box (new Rect (0 + Screen.width / 4, Screen.height / 8, Screen.width / 2, Screen.height / 5), instructions);
		}
	}
}
