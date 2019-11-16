using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMoveController : MonoBehaviour
{
	Rigidbody2D rig;
	float speedX, speedY;
	
	public float acceleration = 8f;
	public float rotation = 0f;
	public float maneuverability = 240f;
	public float maxrotation = 480f;
	public float autoManeuver = 1.5f;
	public float counterManeuver = 2f;
	
	bool onCruise = true;
	string onCruiseGUI = "Круизный";
	
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
	
	void OnGUI() 
	{
		GUI.Box(new Rect(0, 0, 150, 30), onCruiseGUI + " режим");
		GUI.Box(new Rect(0, 30, 150, 30), rig.velocity.x + " " + rig.velocity.y);
		GUI.Box(new Rect(0, 60, 150, 30), rig.rotation + "" + rotation);
	}
	
	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			if (onCruise == false) 
			{
				rig.velocity = rig.velocity + (Vector2)transform.up * acceleration * Time.deltaTime;
			}
			else 
			{
				
			}
		}
		else if (Input.GetKey(KeyCode.S))
		{
			if (onCruise == false) 
			{
				rig.velocity = rig.velocity - (Vector2)transform.up * acceleration * Time.deltaTime * 0.5f;
			}
			else 
			{
				
			}
		}
		else if (Input.GetKey(KeyCode.LeftShift))
		{
			if (onCruise == false) 
			{
				if ((rig.velocity.x != 0) && (rig.velocity.y != 0) && (rig.velocity.magnitude != 0f))
					rig.velocity = rig.velocity - rig.velocity * acceleration * Time.deltaTime / rig.velocity.magnitude;
			}
		}
		else if (onCruise == true) {
			
		}
				
		if (Input.GetKey(KeyCode.A))
		{
			if (rotation <= maxrotation) 
			{
				if (rotation < 0) 
				{
					rotation = rotation + maneuverability * counterManeuver * Time.deltaTime;
				}
				else 
				{
					rotation = rotation + maneuverability * Time.deltaTime;
				}
			}
		}
		else if (Input.GetKey(KeyCode.D))
		{
			if (rotation >= -maxrotation) 
			{
				if (rotation > 0) 
				{
					rotation = rotation - maneuverability * counterManeuver * Time.deltaTime;
				}
				else 
				{
					rotation = rotation - maneuverability * Time.deltaTime;
				}
			}
		}
		else 
		{
			if (rotation < 0) 
			{
				rotation = rotation + maneuverability * autoManeuver * Time.deltaTime;
			}
			else if (rotation > 0) 
			{
				rotation = rotation - maneuverability * autoManeuver * Time.deltaTime;
			}
		}
		rig.rotation = rig.rotation + rotation * Time.deltaTime;
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (onCruise == true) 
			{
				onCruiseGUI = "Иннерционный";
				onCruise = false;
			}
			else 
			{
				onCruiseGUI = "Круизный";
				onCruise = true;
			}
		}
	}
	
}
