using UnityEngine;
using System.Collections;

public class pushanim : MonoBehaviour {
	Animator nylaanim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
	
		if (other.gameObject.name == "Nyla1") {
			nylaanim = other.gameObject.GetComponent<Animator> ();
			nylaanim.SetTrigger ("pushnow");
		}
	}
}
