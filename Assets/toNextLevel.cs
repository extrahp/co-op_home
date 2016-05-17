using UnityEngine;
using System.Collections;

public class toNextLevel : MonoBehaviour {

	public GameObject triggerObject;
	public string levelname;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == triggerObject) {
			Application.LoadLevel (levelname);
		}
	}
}
