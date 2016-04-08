using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 
{
	public bool MoveStop			{ get; set; }

	private Renderer render		= null;
	private Rigidbody ballRigid	= null;
	private Vector3 direction		= Vector3.zero;
	

	private void Awake()
	{
		ballRigid		= GetComponent<Rigidbody>();
		render			= GetComponent<MeshRenderer>();
		MoveStop		= false;
	}

	private void OnEnable()
	{
		direction		= new Vector3( Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f) );	
		switch( Random.Range( 0, 3 ) )
		{
			case 0:
				gameObject.layer = LayerMask.NameToLayer("Red");
				render.material.SetColor( ReadOnlys.DefaultMaterialColor, Color.red );
				break;

			case 1:
				gameObject.layer = LayerMask.NameToLayer("Yellow");
				render.material.SetColor( ReadOnlys.DefaultMaterialColor, Color.yellow );
				break;

			default:
				gameObject.layer = LayerMask.NameToLayer("Blue");
				render.material.SetColor( ReadOnlys.DefaultMaterialColor, Color.blue );
				break;

		}
	}

	private void FixedUpdate()
	{
		if( true == MoveStop )				
		{
			ballRigid.isKinematic	= true;
			ballRigid.velocity		= Vector3.zero;
		}
		else
		{
			ballRigid.isKinematic	= false;

			ballRigid.AddForce( direction * 10f, ForceMode.Force );

			var distance = Vector3.zero - transform.position;
			if( 400 <= distance.sqrMagnitude )
			{
				BallFactory.Inst.Release( gameObject );
			}
		}
	}

	private void OnCollisionEnter( Collision coll )
	{
		direction = Vector3.Reflect( direction, coll.contacts[0].normal );
		ballRigid.AddForce( direction * 10 );
	}
}
