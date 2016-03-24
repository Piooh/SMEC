using UnityEngine;
using System.Collections;


public class PlayerMove : MonoBehaviour
{
	private float speed				= 5f;
	private float verticalVelocity	= 0.0f;
	private bool isJump				= false;

	public delegate void OnJump( bool isJump );
	public System.Action<float> onMove = null;
	public OnJump onJump = null;
	
	private void FixedUpdate()
	{
		Move();
		Jump();
	}

	private void Move()
	{
		var vertical		= Input.GetAxis( "Vertical" );
		var horizontal		= Input.GetAxis( "Horizontal" );

		var direction		= (Vector3.forward * vertical) + (Vector3.right * horizontal);
		direction.Normalize();

		if( Vector3.zero != direction )
		{
			transform.rotation = Quaternion.LookRotation( direction, Vector3.up );
		}

		var moveScale		= (direction * speed * Time.fixedDeltaTime);

		transform.position	= transform.position + moveScale;

		if( null != onMove )
		{
			onMove( moveScale.sqrMagnitude );
		}
	}

	private void Jump()
	{
		if( true == Input.GetKeyDown( KeyCode.Space ) && false == isJump )
		{
			isJump = true;
			verticalVelocity = 2f;
		}

		if( true == isJump )
		{
			var pos = transform.position;
			pos.y	= pos.y + (verticalVelocity * Time.deltaTime);
			transform.position = pos;

			MyDebug.Log.Normal( string.Format("pos : {0}, velocity : {1}", pos, verticalVelocity ) );

			verticalVelocity -= 3.5f * Time.deltaTime;

			if( transform.position.y <= 0.0f )
			{
				pos.y = 0.0f;
				transform.position = pos;
				isJump = false;
			}
		}

		if( null != onJump ) { onJump(isJump); }
	}
}
