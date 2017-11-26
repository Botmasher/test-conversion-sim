using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public int playerTurn = 0; 		// cycles from 0 (world) to n players

	public List<Color> playerColors = new List<Color> ();
	public Transform player;
	public Text playersText;
	public GameObject builtsMenu;

	List<Player> players = new List<Player> ();
	RaycastHit hit;

	void Start () {
		for (int x=0; x < playerColors.Count; x++) {
			Player newPlayer = Instantiate (player).GetComponent<Player> ();
			newPlayer.transform.SetParent (this.transform);
			newPlayer.id = x;
			newPlayer.color = playerColors[x];
			newPlayer.enabled = false;
			newPlayer.builtsMenu = builtsMenu;
			players.Add (newPlayer);
		}
		players [0].enabled = true;

		playersText.text = string.Format ("player: {0}\nRETURN to end turn", playerTurn);
	}

	public void EndTurn (int cycle) {
		playerTurn = cycle >= playerColors.Count-1 ? 0 : cycle+1;
		players [cycle].enabled = false;
		players [playerTurn].enabled = true;

		playersText.text = string.Format ("player: {0}\nRETURN to end turn", playerTurn);
	}
	public void SetPlayers (List<Color> newPlayersList) {
		playerColors = newPlayersList;
	}
}
