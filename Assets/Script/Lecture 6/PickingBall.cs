using UnityEngine;
using System.Collections;

public class PickingBall : MonoBehaviour
{
	public Camera mainCam = null;

	private void Update()
	{
		MousePick();
	}

	private void MousePick()
	{
		if( null == mainCam ) { return; }

		if( true == Input.GetMouseButtonDown(0) )
		{
			var pos = Input.mousePosition;
			var ray = mainCam.ScreenPointToRay( pos );

			RaycastHit hitInfo;
			if( true == Physics.Raycast( ray, out hitInfo ) )
			{
				var move = hitInfo.transform.GetComponent<BallMovement>();
				if( null == move )
				{
					MyDebug.Log.Error( "Pick Target : " + hitInfo.transform.name );
				}
				else
				{
					move.MoveStop = !move.MoveStop;
					MyDebug.Log.Normal( "Pick Target : " + hitInfo.transform.name );
				}
			}
		}
	}
}
