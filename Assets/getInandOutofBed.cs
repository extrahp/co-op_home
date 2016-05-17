using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class getInandOutofBed : MonoBehaviour {
	public GameObject standing;
	public GameObject laying;

	bool displaytext1 = false;
	bool displaytext2 = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			if (other.gameObject == standing) {
				laying.transform.parent.gameObject.SetActive (true);

				standing.transform.parent.gameObject.SetActive (false);
			} else if (other.gameObject == laying) {
				laying.transform.parent.gameObject.SetActive (false);
				standing.transform.parent.gameObject.SetActive (true);
			}
		}

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == standing) {
			displaytext1 = true;
			displaytext2 = false;

		}
		if (other.gameObject == laying) {
			displaytext1 = false;
			displaytext2 = true;

		}

	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == standing || other.gameObject == laying) {
			if (other.gameObject == standing) {
				displaytext1 = false;
				displaytext2 = false;

			}
			if (other.gameObject == laying) {
				displaytext1 = false;
				displaytext2 = false;

			}
		}

	}

	void OnGUI() {
		if (displaytext1) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 25), "Click to lay in the bed");
		}
		if (displaytext2) {
			GUI.Label (new Rect (Screen.width/2-100, Screen.height/2, 200, 25), "Click to get out of the bed");
		}
	}
}
