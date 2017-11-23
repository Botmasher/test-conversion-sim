using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int index;
	public Color color;

	RaycastHit hit;
		
	void Update () {
		if (Input.GetButtonDown ("Select")) {
			// paint grid space and end turn
			Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
			if (hit.collider != null && hit.collider.gameObject.tag == "Space") {
				hit.collider.gameObject.GetComponent<GridSpace> ().SetOwner (index, color);
			}
		}
		// End turn
		if (Input.GetKeyDown (KeyCode.Return)) this.GetComponentInParent<PlayerManager> ().EndTurn (index);
	}
}
