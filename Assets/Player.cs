using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int index;
	public Color color;

	public int resourceX = 10;

	RaycastHit hit;
		
	void Update () {
		if (Input.GetButtonDown ("Select")) {
			// paint grid space and end turn
			Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
			if (hit.collider != null && hit.collider.gameObject.tag == "Space") {
				this.BuySpace (hit.collider.gameObject.GetComponent<GridSpace> ());
			}
		}
		// End turn
		if (Input.GetKeyDown (KeyCode.Return)) this.GetComponentInParent<PlayerManager> ().EndTurn (index);
	}

	void BuySpace (GridSpace space) {
		if (space.price <= resourceX) {
			space.SetOwner (index, color);
			resourceX -= space.price;
		}
	}
}
