using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	Vector3 camPos;
	Vector3 camRot;
	float camSpeed = 1.4f;

	void Start () {
		Camera.main.orthographic = true;
		Camera.main.nearClipPlane = 0f;
	}

	void Update () {
		// lerp to view
		if (Camera.main.transform.position != camPos) {
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, camPos, camSpeed*Time.deltaTime);
		}
		if (Camera.main.transform.rotation.eulerAngles != camRot) {
			Camera.main.transform.rotation = Quaternion.Euler(Vector3.Lerp (Camera.main.transform.rotation.eulerAngles, camRot, camSpeed*Time.deltaTime));
		}
	}

	public void SetDistance (float newY) {
		this.SetPosition (camPos.x, newY, camPos.z);
	}
	public void SetPosition (float x, float y, float z) {
		camPos = new Vector3 (x, y, z);
	}
	public void SetRotation(Vector3 rot) {
		camRot = new Vector3 (rot.x, rot.y, rot.z);
	}
}
