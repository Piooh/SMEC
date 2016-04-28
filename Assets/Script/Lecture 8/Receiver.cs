using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Receiver : MonoBehaviour, IFrameMessage
{
	public void OnMessage()
	{
		MyDebug.Log.Normal ("Call message");
	}

	public void GetFrameCount( int frame )
	{
		MyDebug.Log.Warnnig ("frmae : " + frame);
	}
}
