using UnityEngine;
using System.Collections;

public class buildLevel : MonoBehaviour {
	public ladder add_ladder;
	public float ladder_width;
	public Vector2 ladder_location;
	public GameObject e_key;
	public bool action_key_showing, player_over_ladder;

	// Use this for initialization
	void Start () {
		//Set action key and player ladder collision
		player_over_ladder = false;
		action_key_showing = false;

		//Set ladder width and location
		ladder_width = add_ladder.transform.localScale.x;
		Vector3 ladderLocation = new Vector3(-66f,-.3726127f,-.8f);
		add_ladder.transform.position = ladderLocation;

		//Set vector used for collision detection
		ladder_location = new Vector2(ladderLocation.x - (ladder_width / 2), ladderLocation.x + (ladder_width / 2));
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(player_over_ladder);
	}

	//**NEEDS WORK***Set array of location info vectors for collision detection
	void setArray(Vector2 check_for_hit) {
		ladder_location = ladder_location;
	}
	    
	//Get vector contaning x location of both sides of ladder
	public Vector2 getLadderPointArray() {
		return ladder_location;
	}

	//Check if player is over a ladder
	public bool check_player_over_ladder(float player_x_location) {
		if(player_x_location > ladder_location.x && player_x_location < ladder_location.y) {
			if(action_key_showing == false){
				//Set bool to stop clones from duplicating and player on ladder
				action_key_showing = true;
				player_over_ladder = true;

				//Generate Action Key
				Instantiate(e_key);
			}
			return true;
		} else {
			if(action_key_showing == true) {
				//Send kill signal to action key

				//Reset action key and player bools
				player_over_ladder = false;
				action_key_showing = false;

			}
			return false;
		}
	}

	/*public void dropLadder() {
		ladder ladders = (ladder)Instantiate(Resources.Load("ladderfab"));
	}*/
}
