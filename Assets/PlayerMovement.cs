using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 1f;
	
    PlayerInputActions input_action_;
    Vector2 movement_input_;
	Rigidbody2D rbody_;
	
    void Awake()
    {
		rbody_ = GetComponent<Rigidbody2D>();
        input_action_ = new PlayerInputActions();
		input_action_.PlayerControls.Move.performed += ctx => movement_input_ = ctx.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
		Vector2 currentPos = rbody_.position;
        float horz_move = movement_input_.x;
		float vert_move = movement_input_.y;
		
        Vector2 inputVector = new Vector2(horz_move, vert_move);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
		
        Vector2 movement = inputVector * movementSpeed;
		
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
		
        //isoRenderer.SetDirection(movement);
        rbody_.MovePosition(newPos);
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
