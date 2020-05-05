using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{

    public static readonly string[] static_directions_ = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public static readonly string[] run_directions_ = {"Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE"};

    Animator animator_;
    int prev_direction_;

    private void Awake()
    {
        animator_ = GetComponent<Animator>();
    }


    public void SetDirection(Vector2 direction)
	{
        string[] direction_array = null;
		
		//check if actually moving
        if (direction.magnitude < .01f)
        {
            direction_array = static_directions_;
        }
        else
        {
            direction_array = run_directions_;
            prev_direction_ = DirectionToIndex(direction, 8);
        }

        animator_.Play(direction_array[prev_direction_]);
    }

    public static int DirectionToIndex(Vector2 dir, int slice_count)
	{
        Vector2 norm_dir = dir.normalized;
		
        float step = 360f / slice_count;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, norm_dir);
		
        angle += halfstep;
        if (angle < 0)
		{
            angle += 360;
        }
		
        float step_count = angle / step;
		
        return Mathf.FloorToInt(step_count);
    }
}
