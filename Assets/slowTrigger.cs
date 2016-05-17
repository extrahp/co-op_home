using UnityEngine;
using System.Collections;

public class slowTrigger : MonoBehaviour {

	GameObject [] gameObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.name == "Nyla") {
			if (other.gameObject.GetComponent<Rigidbody> ().drag >= 0.3) {
				other.gameObject.GetComponent<Rigidbody> ().drag = 1.5f;

				gameObjects = GameObject.FindGameObjectsWithTag ("lvl2");

				for (var i = 0; i < gameObjects.Length; i++) {
					Destroy (gameObjects [i]);
				}

				GameObject.Find ("Green Orb Generator").SetActive (false);
				GameObject.Find ("Danger Bamboo Generator").SetActive (false);
			} 
			else {
				Application.LoadLevel ("GameOver");
			}
		}
	}

}
