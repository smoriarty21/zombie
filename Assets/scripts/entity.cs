using UnityEngine;
using System.Collections;

public class entity : MonoBehaviour {
	public float x, y, height, width;
	public Vector3 location;

	// Use this for initialization
	void Start () {
		height = transform.localScale.y;
		width = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
