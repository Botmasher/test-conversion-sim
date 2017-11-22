using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour {

	int owner = 0;

	public void SetOwner (int newOwner, Color newColor) {
		if (newOwner > 0) {
			owner = newOwner;
			GetComponent<MeshRenderer> ().material.color = newColor;
		}
	}
}
