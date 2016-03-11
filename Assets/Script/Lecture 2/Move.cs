using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	//private void Awake()
	//{
	//	var position	= transform.position;
	//	var direction	= Vector3.forward;
	//	var speed		= 2f;

	//	transform.position = position + ( direction * speed );
	//}


	private void Update()
	{
		var virtical	= Input.GetAxis( "Vertical" );
		var horizontal	= Input.GetAxis( "Horizontal" );


		var postion		= transform.position;
		var direction	= (Vector3.forward * virtical) + (Vector3.right * horizontal);
		var speed		= 2f;

		//transform.position = postion + ( direction * speed * Time.deltaTime);
		transform.Translate( direction * speed * Time.deltaTime, Space.World );
	}
}
