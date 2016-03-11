using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour 
{
	private float angle = 0f;
	private void Update()
	{
		var horizontal	= Input.GetAxis( "Horizontal" );
		var vertical	= Input.GetAxis( "Vertical" );

		var h = horizontal * 30f * Time.deltaTime;
		var v = vertical * 30f * Time.deltaTime;

		var pitch	= Quaternion.AngleAxis( h, Vector3.right );
		var yaw		= Quaternion.AngleAxis( v, Vector3.up );

		transform.rotation = pitch * transform.rotation;
		transform.rotation = yaw * transform.rotation;


		if( true == Input.GetKeyUp( KeyCode.Escape ) )
		{
			transform.rotation = Quaternion.identity;
		}
		else if( true == Input.GetKeyUp( KeyCode.Space ) )
		{
			transform.localRotation = Quaternion.identity;
		}
	}
}
