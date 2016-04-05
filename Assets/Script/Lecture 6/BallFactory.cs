using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallFactory : MonoSingleton<BallFactory>
{
	public int capacity = 20;

	private GameObject prefabBall			= null;
	private Queue<GameObject> cachedballs	= new Queue<GameObject>();

	private int activeBallCount				= 0;
	public int ActiveBallCount			{ get{ return activeBallCount; } }
	public bool CanICreate				{ get{ return (capacity > activeBallCount); } }


	protected override void DoAwake()
	{
		if( null == prefabBall )
		{
			prefabBall			= Resources.Load<GameObject>( "Prefab/Ball" );
		}
	}

	public GameObject Create()
	{
		GameObject ball		= null;
		if( 0 == cachedballs.Count )
		{
			ball = Instantiate( prefabBall, Vector3.zero, Quaternion.identity ) as GameObject;
			ball.transform.parent = transform;
		}
		else
		{
			ball = cachedballs.Dequeue();
		}

		activeBallCount++;

		ball.SetActive( true );
		return ball;
	}

	public void Release( GameObject ball )
	{
		ball.SetActive( false );
		activeBallCount--;

		if( capacity >= cachedballs.Count )
		{
			ball.transform.position = Vector3.zero;
			ball.transform.rotation = Quaternion.identity;	
			cachedballs.Enqueue( ball );
		}
		else
		{
			Destroy( ball );
		}
	}
}
