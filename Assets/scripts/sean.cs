using UnityEngine;
using System.Collections;

public class sean : entity {
	public float xVelocity, yVelocity, height, speed, gravity;
	public GameObject floor;

	//Status and variable for if player is colliding with his feet
	private bool grounded, jumping;
	private float jumpStartY, jumpHeight;
	public string status;

	//TESTING
	public buildLevel level;
	public Vector2 ladder_locations;

	//Rays for collision detection
	Ray bottomCollider, rightCollider, leftCollider;
	RaycastHit bottomColliderHit = new RaycastHit();
	RaycastHit rightColliderHit = new RaycastHit();
	RaycastHit leftColliderHit = new RaycastHit();

	// Use this for initialization
	void Start () {


		//Set speed, velocity, height, location and gravity
		speed = .3f;
		gravity = 1f;
		xVelocity = 0;
		yVelocity = 0;

		//Jump Setup
		jumping = false;
		jumpHeight = 10f;
		jumpStartY = transform.position.y;

		//Vector 3 to hold location data
		location = new Vector3(transform.position.x, transform.position.y, -1);

		//Height and width set
		height = transform.localScale.y;
		width = transform.localScale.x;

		//Set status
		status = "start";
		grounded = false;

		//Set x and y REMOVE for vector3
		x = transform.position.x;
		y = transform.position.y;


	}
	
	// Update is called once per frame
	void Update () {
		//*****Testing*****
		ladder_locations = level.getLadderPointArray();

		if(level.check_player_over_ladder(this.location.x)) {
			level.player_over_ladder = true;
		}

		//*****End Testing*****


		//Reset Status and velocities
		xVelocity = 0;
		//status = "still";

		//Setup Rays for collision detection
		bottomCollider.origin = new Vector3(location.x, location.y, location.z);
		bottomCollider.direction = new Vector3(0, -1, 0);
		Debug.DrawRay(bottomCollider.origin, bottomCollider.direction * (height / 2), Color.blue);

		rightCollider.origin = new Vector3(location.x, location.y, location.z);
		rightCollider.direction = new Vector3(1,0,0);
		Debug.DrawRay(rightCollider.origin, rightCollider.direction * (width / 2), Color.yellow);

		leftCollider.origin = new Vector3(location.x, location.y, location.z);
		leftCollider.direction = new Vector3(-1,0,0);
		Debug.DrawRay(leftCollider.origin, leftCollider.direction * (width / 2), Color.green);

		//Testing
		/*if(Physics.Raycast(rightCollider.origin, rightCollider.direction, out rightColliderHit, width / 2)) {
			Debug.Log(rightColliderHit.collider.tag);
		}
		else if(Physics.Raycast(leftCollider.origin, leftCollider.direction, out leftColliderHit, width / 2)) {
			Debug.Log(leftColliderHit.collider.tag);
		}*/

		//Keyboard Inputs
		//Run
		if(Input.GetKey(KeyCode.D)) {
			xVelocity = speed;
			status = "run";
		}
		if(Input.GetKey(KeyCode.A)) {
			xVelocity = -speed;
			status = "run";
		}
		//Jump
		if(Input.GetKey(KeyCode.W) && !jumping && grounded){
			jumping = true;
			grounded = false;
			jumpStartY = location.y;
		}

		//Status Handlers
		if(status == "still"){
			xVelocity = 0;
			yVelocity = 0;
		}

		if(jumping){
			if(location.y >= jumpStartY + jumpHeight) {
				status = "falling";
				jumping = false;
			}
			else {
				yVelocity = gravity;
			}
		}

		//Collision Detection
		//If nothing is colliding with bottom ray apply gravity else stay in place
		if(!jumping){
			if(Physics.Raycast(bottomCollider.origin, bottomCollider.direction, out bottomColliderHit, height / 2)) {
				yVelocity = 0;
				grounded = true;
				status = "still";

				//Debug.Log(bottomColliderHit.collider.tag);

			}
			else {
				this.yVelocity = -(this.gravity);
				status = "falling";
				grounded = false;
			}
		}

		location.x += xVelocity;
		location.y += yVelocity;

		transform.position = location;
	}


	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.tag);
	}
}

//}
