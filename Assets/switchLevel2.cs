using UnityEngine;
using System.Collections;

public class switchLevel2 : MonoBehaviour {
	public GameObject lvl1;
	public GameObject lvl2;
	public GameObject gen1;
	public GameObject gen2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.name == "Nyla1") {
			lvl1.SetActive (false);
			lvl2.SetActive (true);
			gen1.SetActive (true);
			gen2.SetActive (true);
		}
	}
}
