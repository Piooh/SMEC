using UnityEngine;
using System.Collections;

public class ConflictTest : MonoBehaviour 
{
	private void Awake()
	{
		MyDebug.Log.Error( "Force Conflict" );
	}
}
