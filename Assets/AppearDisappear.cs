using UnityEngine;
using System.Collections;

public class AppearDisappear : MonoBehaviour {

	public GameObject pointA;
	public GameObject pointB;
	public GameObject patrol;
	public GameObject nyla;
	bool dir = true;
	float timer = 0;
	float waithowlong = 999;

	bool triggered = false;
	float UItimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		UItimer += Time.deltaTime;
		if (dir) {
			patrol.transform.position = Vector3.Lerp (patrol.transform.position, pointA.transform.position, 0.5f * Time.deltaTime);
			patrol.transform.LookAt (pointA.transform);
		}
		if (dir && timer >= 10) {
			timer = 0;
			dir = false;
			waithowlong = 10 + Random.Range (10, 20);
		}
		if (!dir) {
			patrol.transform.position = Vector3.Lerp (patrol.transform.position, pointB.transform.position, 0.5f * Time.deltaTime);
			patrol.transform.LookAt (pointB.transform);
		}
		if (!dir && timer >= 5 && timer < waithowlong) {
			patrol.SetActive (false);
		}
		if (timer >= waithowlong - 5) {
			triggered = true;
			UItimer = 0;
		}
		if (!dir && timer >= waithowlong) {
			patrol.SetActive (true);
			dir = true;
			timer = 0;
			triggered = false;
		}
	}

	void OnGUI() {
		if (triggered) {
			GUI.Box (new Rect (0 + Screen.width / 4, Screen.height / 8, Screen.width / 2, Screen.height / 5), "The A Crew is coming! Lay in the bed!");
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject == nyla && dir) {
			Application.LoadLevel("GameOver");
		}
	}
}
