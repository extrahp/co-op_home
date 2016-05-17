using UnityEngine;
using System.Collections;

public class getHurt : MonoBehaviour {

	public GameObject lightObject;
	LightLevel lightsScript;
	float addmore = 0;
	// Use this for initialization
	void Start () {
		if (lightObject == null)
			lightObject = GameObject.Find ("ProtectionBubble");
		lightsScript = lightObject.GetComponent<LightLevel> ();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Nyla") {
			if (other.gameObject.GetComponent<Rigidbody> ().drag > 0.2f)
				other.gameObject.GetComponent<Rigidbody> ().drag -= 0.05f;
			else
				other.gameObject.GetComponent<Rigidbody> ().drag = 0.2f;
			if (lightsScript.powerLevel >= 25)
				lightsScript.Submore (25);
			else {
				float howmuch = lightsScript.powerLevel;
				lightsScript.Submore (howmuch);
			}
			Destroy (gameObject);
		}
	}
}
