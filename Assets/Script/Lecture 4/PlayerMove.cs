using UnityEngine;
using System.Collections;


public class PlayerMove : MonoBehaviour
{
	private float speed = 5f;

	public System.Action<float> onMove = null;
	
	private void FixedUpdate()
	{
		Move();
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
}
