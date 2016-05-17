using UnityEngine;
using System.Collections;

public class DestroyTrigger : MonoBehaviour {

	int triggercounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (triggercounter > 3) {
			Destroy (gameObject);
		}	
	}

	public void DestroyMe () {
		triggercounter += 1;
	}
}
