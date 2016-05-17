using UnityEngine;
using System.Collections;

public class LightLevel : MonoBehaviour {
	
	public float powerLevel;
	public GameObject lightObject;
	Light lightSettings;
	float maxRange = 5;

	float maxSize = 2.723255f;

	float addmore = 0;

	float submore = 0;
	// Use this for initialization
	void Start () {
		powerLevel = 0;
		lightSettings = lightObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((lightSettings.range/maxRange) * 100f != powerLevel) {
			lightSettings.range = (powerLevel * maxRange)/100f;
			transform.localScale = new Vector3 ((powerLevel * maxSize) / 100f, (powerLevel * maxSize) / 100f, (powerLevel * maxSize) / 100f);
		}

		if (addmore > 0) {
			addmore -= 1;
			powerLevel += 1;
		}

		if (submore > 0) {
			submore -= 1;
			powerLevel -= 1;
		}
	}

	public void Addmore(float num) {
		addmore = num;
	}

	public void Submore(float num) {
		submore = num;
	}
}
