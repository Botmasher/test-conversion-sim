using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public int playerTurn = 0; 		// cycles from 0 (world) to n players

	public List<Color> playerColors = new List<Color> ();
	public Transform player;
	List<Player> players = new List<Player> ();
	RaycastHit hit;

	void Start () {
		for (int x=0; x < playerColors.Count; x++) {
			Player newPlayer = Instantiate (player).GetComponent<Player> ();
			newPlayer.transform.SetParent (this.transform);
			newPlayer.index = x;
			newPlayer.color = playerColors[x];
			newPlayer.enabled = false;
			players.Add (newPlayer);
		}
		players [0].enabled = true;
	}

	public void EndTurn (int cycle) {
		playerTurn = cycle >= playerColors.Count-1 ? 0 : cycle+1;
		Debug.Log (playerTurn);
		players [cycle].enabled = false;
		players [playerTurn].enabled = true;
	}
	public void SetPlayers (List<Color> newPlayersList) {
		playerColors = newPlayersList;
	}
}
