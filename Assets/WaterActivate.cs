using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class WaterActivate : MonoBehaviour {


	public GameObject triggerer;
	public GameObject water;
	public GameObject platform;
	bool displaytext;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonUp ("Interact") && displaytext) {
			if (!water.active) {
				water.SetActive (true);
				platform.GetComponent<DestroyTrigger> ().DestroyMe ();
			}
			print ("pressed E");
		}
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
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 20), "Press E to Activate");
		}
	}
}
