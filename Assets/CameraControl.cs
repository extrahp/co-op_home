using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControl : MonoBehaviour {
	public GameObject character_object;
	public GameObject character_object2;
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
	private Quaternion m_CameraTargetRot;
	private Quaternion m_characterRot;
    public bool clampVerticalRotation = false;
	public bool smooth;
    public float smoothTime = 5f;
	public bool lockCursor = true;
    public float MinimumX = -90F;
	public float MaximumX = 90F;
    private bool m_cursorIsLocked = true;

	// Use this for initialization
	void Start () {
		m_CameraTargetRot = transform.rotation;
		m_characterRot = character_object.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		LookRotation(character_object.transform, character_object2.transform);
	}

	public void LookRotation(Transform character, Transform character2)
        {
            float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
            m_characterRot *= Quaternion.Euler(0f, yRot, 0f);

            Transform camera = gameObject.transform;
            if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            if(smooth)
            {
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character2.localRotation = m_CameraTargetRot;
                character_object.transform.localRotation = m_characterRot;
				float z = camera.transform.eulerAngles.z;
				camera.Rotate(0,0,-z);
            }

            UpdateCursorLock();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if(!lockCursor)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate();
        }

        private void InternalLockUpdate()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
}
