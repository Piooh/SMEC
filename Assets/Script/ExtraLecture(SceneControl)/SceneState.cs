using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneState : MonoBehaviour
{
	public static void NextScene( SceneState nextScene )
	{
		if( null != Current ) { Current.OnClose(); }
		Current = nextScene;
		Current.OnStart();
	}
	
	public static SceneState Current = null;


	public virtual void OnStart()
	{
	}

	public virtual void OnClose()
	{
	}
}
