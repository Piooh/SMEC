using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	private float speed = 5f;

	private void Awake()
	{
		//MyDebug.Log.Normal( InputController.Inst.name );
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		var vertical	= Input.GetAxis( "Vertical" );
		var horizontal	= Input.GetAxis( "Horizontal" );

		var direction	= (Vector3.forward * vertical) + (Vector3.right * horizontal);

		transform.position = transform.position + (direction * speed * Time.deltaTime);
	}
}
