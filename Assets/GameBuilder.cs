using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
	Vector2 dimensions = new Vector2(5, 5);

	public List<Color> playerColors = new List<Color> ();
	public CameraManager cameraManager;
	public PlayerManager playerManager;
	public Transform gridSpace;

	List<Transform> grid = new List<Transform> ();

	/*
	 *  spaces   : { [x,y]: { status: { 1: n%, 2: n%, ...}, , builts: [id1, ...] }, ... }
	 *  Dictionary <GameObject, Dictionary<status: List<0.0f, 0.0f>, builts: List<id,...>, ... >>
	 * 
	 * 	builts   : { id: { player: player_id, active: true, }, ... }
	 *  Dictionary <GameObject, Dictionary>
	 * 
	 *  players  : { id: { name: '', : , faction: factions_id, }, ... }
	 *  Dictionary <int, Dictionary<key, string>>
	 * 
	 *  factions : { 'dataName': { name: 'Display Name', tree: [[], []], currentSlots:  }, ... }
	 *  tree 	 : [ [emphasis1] , [emphasis2] , [emphasis3] ]
	 */
	void Awake () {
		// instantiate board
		for (int i = 0; i < dimensions.x; i++) {
			for (int j = 0; j < dimensions.y; j++) {
				grid.Add(Instantiate(gridSpace) as Transform);
				grid[grid.Count-1].localScale = new Vector3 (1.9f, 0.1f, 1.9f);
				grid[grid.Count-1].position = new Vector3 (i * 2f, 0f, j * 2f);
			}
		}

		// init other scripts
		playerManager.SetPlayers (playerColors);
		cameraManager.SetDistance (Mathf.Sqrt(dimensions.x*dimensions.y));
		cameraManager.SetRotation (new Vector3(40f, 45f, 0f));
	}
}
