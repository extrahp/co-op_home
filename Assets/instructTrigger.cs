using UnityEngine;
using System.Collections;

public class instructTrigger : MonoBehaviour {

	public GameObject triggerObject;
	public GameObject cam;
	public string instruct;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == triggerObject) {
			cam.GetComponent<InstructionsDialogue> ().triggered (instruct);
			gameObject.SetActive (false);
		}
	}
		
}
