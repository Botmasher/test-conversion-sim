using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour {

	int owner = 0;
	bool isOwned = false;
	public int price = 10;

	List<string> builts = new List<string> ();

	public void SetOwner (int newOwner, Color newColor) {
		if (newOwner > 0 && !isOwned) {
			owner = newOwner;
			isOwned = true;
			GetComponent<MeshRenderer> ().material.color = newColor;
		}
	}

	public int CheckOwner () {
		return owner;
	}

	public void AddBuilt (string index) {
		builts.Add (index);
	}

	public void RemoveBuilt (string index) {
		builts.Remove (index);
	}
}
