using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int id;
	public Color color;

	public int resourceX = 10;

	RaycastHit hit;
	public GameObject builtsMenu;
	bool browsingBuilts;

	void Start () {
		builtsMenu.SetActive (false);
	}

	void Update () {
		if (Input.GetButtonDown ("Select")) {
			Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
			// paint grid space or open menu if painted
			if (hit.collider != null && hit.collider.gameObject.tag == "Space") {
				this.SelectSpace (hit.collider.gameObject.GetComponent<GridSpace> ());
			}
			// select built from open menu
			//if (hit.collider is a UI option) {
				// 	display all 
				//  add built to gridspace
				// 	tell gridspace to start building the built
				//  update gridspace to manage build time and instantiation
			//}
		}
		// End turn
		if (Input.GetKeyDown (KeyCode.Return)) {
			EndTurn ();
		}
	}

	void SelectSpace (GridSpace space) {
		// purchase space
		if (space.CheckOwner () != id && space.price <= resourceX) {
			space.SetOwner (id, color);
			resourceX -= space.price;
			// pop builts menu if already own space
		} else if (space.CheckOwner () == id && !builtsMenu.activeSelf) {
			LoadBuiltsMenu ();
		}
	}

	void EndTurn () {
		CloseBuiltsMenu ();
		this.GetComponentInParent<PlayerManager> ().EndTurn (id);
	}

	void LoadBuiltsMenu () {
		builtsMenu.SetActive (true);
	}

	void CloseBuiltsMenu () {
		builtsMenu.SetActive (false);
	}
}
