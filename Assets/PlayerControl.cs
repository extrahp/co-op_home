using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {
	public static string currentLevel;
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

		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

//        if (CrossPlatformInputManager.GetButtonUp("Running")) {
//        	print("run");
//        	if (!running) {
//        		running = true;
//        		runspeed = maxrunspeed;
//        	}
//        	else {
//        		running = false;
//        		runspeed = 0; 
//        	}
//        }
		//print (rb.velocity.y);
		if (rb.velocity.y != 0)
			anims.SetFloat ("vspeed", rb.velocity.y);
			
		
        if (Mathf.Abs(vertical) > Mathf.Abs(horizontal))
			movingspeed = Mathf.Abs(vertical);
        else
			movingspeed = Mathf.Abs(horizontal);

		anims.SetFloat("moveUp", movingspeed);
		anims.SetBool("Run", running);

		if (movingspeed != 0) {
			gameObject.transform.position += gameObject.transform.forward*(movingspeed+runspeed)*Time.deltaTime*speed;
			if (vertical > 0 && horizontal > 0)
				angle = 45;
			else if (vertical > 0 && horizontal < 0)
				angle = -45;
			else if (vertical < 0 && horizontal > 0)
				angle = 135;
			else if (vertical < 0 && horizontal < 0)
				angle = -135;
			else if (vertical > 0)
				angle = 0;
			else if (vertical < 0)
				angle = 180;
			else if (horizontal > 0)
				angle = 90f;
			else if (horizontal < 0)
				angle = -90f;
			newRotation = new Vector3 (camerathing.transform.eulerAngles.x, camerathing.transform.eulerAngles.y+angle, camerathing.transform.eulerAngles.z);
			gameObject.transform.eulerAngles = newRotation;
        }
	}


}
