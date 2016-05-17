using UnityEngine;
using System.Collections;

public class PillarPrompt : MonoBehaviour {

	bool displaytext; 
	public GameObject triggerer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == triggerer) {
			displaytext = true;

		}

	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == triggerer) {
			displaytext = false;
		}

	}

	void OnGUI() {
		if (displaytext) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 20), "Walk Forward to Push Pillar");
		}
	}
}
