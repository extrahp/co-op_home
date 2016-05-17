using UnityEngine;
using System.Collections;

public class getPowerUp : MonoBehaviour {

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
			if (other.gameObject.GetComponent<Rigidbody> ().drag < 0.4f)
				other.gameObject.GetComponent<Rigidbody> ().drag += 0.025f;
			if (lightsScript.powerLevel <= 87.5f)
				lightsScript.Addmore (12.5f);
			else {
				float howmuch = 100 - lightsScript.powerLevel;
				lightsScript.Addmore (howmuch);
			}
			Destroy (gameObject);
		}
	}
}
