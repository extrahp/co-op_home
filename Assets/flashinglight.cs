using UnityEngine;
using System.Collections;

public class flashinglight : MonoBehaviour {
	Light lights;
	float time = 0;

	// Use this for initialization
	void Start () {
		Light lights = gameObject.GetComponent<Light> ();
		lights.range = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * 2;
		Light lights = gameObject.GetComponent<Light> ();
		lights.range = 100 + Mathf.Sin (time) * 100;
	}
}
