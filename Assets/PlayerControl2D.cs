using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl2D : MonoBehaviour {
	public GameObject camerathing;
	public float speed = 4f;
	float movingspeed;
	float angle;
	bool running = false;
	public float maxrunspeed;
	float runspeed;
	Rigidbody rb;

	Vector3 newRotation;
	Animator anims;
	// Use this for initialization
	void Start () {
		anims = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		
		float horizontalpress= CrossPlatformInputManager.GetAxis("Horizontal");

		int horizontal = 0;

		if (horizontalpress > 0)
			horizontal = 1;
		else if (horizontalpress < 0)
			horizontal = -1;
		else
			horizontal = 0;
		
		if (CrossPlatformInputManager.GetButtonUp("Running")) {
			print("run");
			if (!running) {
				running = true;
				runspeed = maxrunspeed;
			}
			else {
				running = false;
				runspeed = 0; 
			}
		}
		//print (rb.velocity.y);
		if (rb.velocity.y != 0)
			anims.SetFloat ("vspeed", rb.velocity.y);


		if (horizontal != 0) {
			gameObject.transform.position += gameObject.transform.forward*(Mathf.Abs(horizontalpress*speed))*Time.deltaTime*speed;
			if (horizontal > 0)
				angle = 90f;
			else if (horizontal < 0)
				angle = -90f;
			newRotation = new Vector3 (camerathing.transform.eulerAngles.x, camerathing.transform.eulerAngles.y+angle, camerathing.transform.eulerAngles.z);
			gameObject.transform.eulerAngles = newRotation;
		}
	}

	void OnGUI() {
		string safety;
		if (GetComponent<Rigidbody> ().drag >= 0.3f)
			safety = "Falling Speed: Safe";
		else
			safety = "Falling Speed: DANGER!";
		GUI.Box (new Rect (Screen.width / 3, 10, 300, 25), safety);
	}

}
