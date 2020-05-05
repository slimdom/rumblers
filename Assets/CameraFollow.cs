using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Vector3 starting_position_;
	public Transform follow_target_;
	private Vector3 target_pos_;
	public float move_speed_;
	
	void Start()
	{
		starting_position_ = transform.position;
	}

	void Update () 
	{
		if (follow_target_ != null)
		{
			target_pos_ = new Vector3(follow_target_.position.x, follow_target_.position.y, transform.position.z);
			Vector3 velocity = (target_pos_ - transform.position) * move_speed_;
			transform.position = Vector3.SmoothDamp (transform.position, target_pos_, ref velocity, 1.0f, Time.deltaTime);
		}
	}
}
