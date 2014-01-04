using UnityEngine;
using System.Collections;

public class cam : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
		//Set camera position to player position
		Vector3 camPos = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);

		transform.position = camPos;

	}
}
