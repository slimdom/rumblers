using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 1f;
	
    PlayerInputActions input_action_;
    Vector2 movement_input_;
	Rigidbody2D rbody_;
	PlayerRenderer renderer_;
	
    void Awake()
    {
		rbody_ = GetComponent<Rigidbody2D>();
		renderer_ = GetComponentInChildren<PlayerRenderer>();
        input_action_ = new PlayerInputActions();
		input_action_.PlayerControls.Move.performed += ctx => movement_input_ = ctx.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
		Vector2 current_pos = rbody_.position;
        float horz_move = movement_input_.x;
		float vert_move = movement_input_.y;
		
        Vector2 input_vector = new Vector2(horz_move, vert_move);
        input_vector = Vector2.ClampMagnitude(input_vector, 1);
		
        Vector2 movement = input_vector * movementSpeed;
		
        Vector2 new_pos = current_pos + movement * Time.fixedDeltaTime;
		
        renderer_.SetDirection(movement);
        rbody_.MovePosition(new_pos);
    }
	
	private void OnEnable()
	{
		input_action_.Enable();
	}
	
	private void OnDisable()
	{
		input_action_.Disable();
	}
}
