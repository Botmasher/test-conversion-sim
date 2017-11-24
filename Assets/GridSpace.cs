using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour {

	int owner = 0;
	bool isOwned = false;
	public int price = 10;

	public void SetOwner (int newOwner, Color newColor) {
		if (newOwner > 0 && !isOwned) {
			owner = newOwner;
			isOwned = true;
			GetComponent<MeshRenderer> ().material.color = newColor;
		}
	}
}
