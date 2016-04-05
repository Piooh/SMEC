using UnityEngine;
using System.Collections;

public class CollisionActor : MonoBehaviour 
{
	private void OnCollisionEnter( Collision colliderInfo )
	{
		Debug.LogError( "OnCollisionEnter Call !!" );
	}

	private void OnCollisionStay( Collision colliderInfo )
	{
		Debug.LogError( "OnCollisionStay Call !!" );
	}

	private void OnCollisionExit( Collision colliderInfo )
	{
		Debug.LogError( "OnCollisionExit Call !!" );
	}


	private void OnTriggerEnter( Collider triggerInfo )
	{
		Debug.LogError( "OnTriggerEnter Call !!" );
	}

	private void OnTriggerStay( Collider triggerInfo )
	{
		Debug.LogError( "OnTriggerStay Call !!" );
	}

	private void OnTriggerExit( Collider triggerInfo )
	{
		Debug.LogError( "OnTriggerExit Call !!" );
	}

}
