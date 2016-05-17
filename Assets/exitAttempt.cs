using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class exitAttempt : MonoBehaviour {

	public bool isExit = true;
	public GameObject triggerer;
	bool display;
	bool inspecting = false;
	bool wrong = false;
	float inspectTime = 0;
	// Use this for initialization
	void Start () {
		isExit = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (inspecting) {
			inspectTime += Time.deltaTime;
		}

		if (inspectTime > 5) {
			if (isExit)
				Application.LoadLevel ("new_level3_trains");
			else {
				inspecting = false;
				wrong = true;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == triggerer)
			display = true;

	}

	void OnTriggerExit (Collider other) {
		if (inspecting) {
			inspecting = false;
			inspectTime = 0;
		}
		if (other.gameObject == triggerer)
			display = false;
	}

	void OnTriggerStay(Collider other) {
		if (CrossPlatformInputManager.GetButtonDown ("Fire1") && !wrong) {
			if (!inspecting) {
				inspecting = true;
				inspectTime = 0;
			}
		}

	}

	void OnGUI() {
		if (display && !inspecting && !wrong) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 20), "Click to inspect exit.");
		}

		if (display && inspecting && !wrong) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 20), "Inspecting...");
		}
		if (display && wrong) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 20), "This exit is blocked!");
		}
	}

}
