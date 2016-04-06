using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour 
{
	private IEnumerator Start()
	{
		while( true )
		{
			if( true == BallFactory.Inst.CanICreate ) { BallFactory.Inst.Create();}
			yield return new WaitForSeconds(0.1f);
		}
	}
}
