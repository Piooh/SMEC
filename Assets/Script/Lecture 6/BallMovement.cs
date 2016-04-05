using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 
{
	private Rigidbody ballRigid	= null;
	private Vector3 direction		= Vector3.zero;

	private void Awake()
	{
		ballRigid		= GetComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		direction		= new Vector3( Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f) );
	}

	private void FixedUpdate()
	{
		ballRigid.AddForce( direction * 10f, ForceMode.Force );

		var distance = Vector3.zero - transform.position;
		if( 200 <= distance.sqrMagnitude )
		{
			BallFactory.Inst.Release( gameObject );
		}
	}
}
