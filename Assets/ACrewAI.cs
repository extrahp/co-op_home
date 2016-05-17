using UnityEngine;
using System.Collections;

public class ACrewAI : MonoBehaviour {

	float floatingypos;
	float timefloat;
	float defaulty;

	public GameObject target;

	public float speed;
	public bool shouldmove;
	public bool lockedon;
	float changedirectiontime;

	int direction = 1;

	RaycastHit hitted;

	Vector3 fwd;
	Vector3 left;
	Vector3 right;
	// Use this for initialization
	void Start () {
		defaulty = transform.position.y;
		shouldmove = true;
		lockedon = false;

		fwd = transform.TransformDirection(Vector3.forward);
		left = transform.TransformDirection(Vector3.left);
		right = transform.TransformDirection(Vector3.right);
	}
	
	// Update is called once per frame
	void Update () {
		timefloat += Time.deltaTime;
		changedirectiontime += Time.deltaTime;
		floatingypos = Mathf.Sin (timefloat*2);
		transform.position = new Vector3 (transform.position.x, defaulty + floatingypos, transform.position.z);

		if (shouldmove && !lockedon)
			gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
	}

	void correctRotation () {
		if ((transform.rotation.y > 0 && transform.rotation.y < 45) || transform.rotation.y > 315)
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		else if (transform.rotation.y > 45 && transform.rotation.y < 135)
			transform.localEulerAngles = new Vector3 (0, 90, 0);
		else if (transform.rotation.y > 135 && transform.rotation.y < 225)
			transform.localEulerAngles = new Vector3 (0, 180, 0);
		else {
			transform.localEulerAngles = new Vector3 (0, 270, 0);
		}
	}
	void FixedUpdate() 
	{
		fwd = transform.TransformDirection(Vector3.forward);
		left = transform.TransformDirection(Vector3.left);
		right = transform.TransformDirection(Vector3.right);

		int wallLayer = 1 << 9;

		if (!lockedon) {
			if (changedirectiontime > 1f) {
				int rando = Random.Range (0, 3);
				if (rando == 0) {
					if (!Physics.Raycast (transform.position, left, 6, wallLayer)) {
						gameObject.transform.rotation *= Quaternion.Euler (0f, -90f, 0f);
						changedirectiontime = 0;
					}
				} else if (rando == 1) {
					if (!Physics.Raycast (transform.position, right, 6, wallLayer)) {
						gameObject.transform.rotation *= Quaternion.Euler (0f, 90f, 0f);
						changedirectiontime = 0;
					}
				} else {
					changedirectiontime = 0;
				}
			}
			if (Physics.Raycast (transform.position, fwd, 3, wallLayer)) {
				shouldmove = false;
				if (changedirectiontime > 1f) {
					direction = Random.Range (0, 2);
					if (direction == 0)
						direction = -1;
					else
						direction = 1;
					changedirectiontime = 0;


				}
				gameObject.transform.rotation *= Quaternion.Euler (0f, direction * 90f, 0f);
			} 
			else {
				shouldmove = true;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, 4 * speed * Time.deltaTime);
			transform.LookAt (target.transform);
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		}

		if (lockedon && Vector3.Distance (transform.position, target.transform.position) < 5.5f) {
			Application.LoadLevel ("new_level2b_investigation");
		}
	}

	void OnTriggerStay(Collider other) {
		Vector3 dir = (target.transform.position - transform.position).normalized;
		if (other.gameObject == target) {
			if (Physics.Raycast (transform.position, dir, out hitted, 15f)) {
				if (hitted.collider.gameObject.name == "Nyla1")
					lockedon = true;
				else {
					if (lockedon) {
						lockedon = false;

						if (transform.rotation.y % 90 != 0 && !lockedon)
							correctRotation ();
					}
				}
			}
		}
	}
		
}
