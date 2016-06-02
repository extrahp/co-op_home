using UnityEngine;
using System.Collections;

public class clickNextLevel : MonoBehaviour {
	public GameObject triggerObject;
	public string levelname;
	bool enableExit = false;
	bool displaytext;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == triggerObject) {
			displaytext = true;
			enableExit = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == triggerObject) {
			displaytext = false;
			enableExit = false;
		}
	}

	void OnMouseDown() {
		if (enableExit) {
			Application.LoadLevel ("new_level4_white_mountain");
		}
	}

	void OnGUI() {
		if (displaytext) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 20), "Click to enter the train.");
		}
	}
}
