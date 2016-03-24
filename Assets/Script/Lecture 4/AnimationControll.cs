using UnityEngine;
using System.Collections;

public enum AnimationState : int
{
	Idle	= 0,
	Move	= 1,
	Lose	= 99,
	Win		= 100,
}

public class AnimationControll : MonoBehaviour 
{
	private Animator animator		= null;
	private PlayerMove playerMove	= null;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		playerMove = GetComponent<PlayerMove>();

		MyDebug.Assert( animator, "Can not find Animator Component" );
		MyDebug.Assert( playerMove, "Can not find PlayerMove Component" );

		playerMove.onMove += OnMove;
		playerMove.onJump += OnJump;
	}

	private void OnMove( float moveScale )
	{
		animator.SetBool( "Move", 0f != moveScale );
	}

	private void OnJump( bool isJump )
	{
		animator.SetBool( "Jump", isJump );
	}

}

