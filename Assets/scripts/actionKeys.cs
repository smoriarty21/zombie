using UnityEngine;
using System.Collections;

public class actionKeys : MonoBehaviour {
	GameObject player1;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("sean");
		transform.position = new Vector3(player1.transform.position.x, (player1.transform.position.y + 5), player1.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player1.transform.position.x, (player1.transform.position.y + 5), player1.transform.position.z);
		kill();
	}

	public void kill() {
		Destroy(gameObject, .3f);
	}
}
