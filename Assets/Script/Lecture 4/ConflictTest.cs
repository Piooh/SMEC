using UnityEngine;
using System.Collections;

public class ConflictTest : MonoBehaviour 
{
	private void Awake()
	{
		MyDebug.Log.Warnnig( "Force Conflict" );
		MyDebug.Assert( false );
	}
}
