using UnityEngine;
using System.Collections;


public class LoadSceneButton : MonoBehaviour
{
	public void GoToLobby()
	{
		SceneDirector.LoadScene( SceneDirector.SceneType.Lobby );
	}

	public void GoToGame()
	{
		SceneDirector.AsycLoadScene( SceneDirector.SceneType.Game );
	}

	public void GoToResult()
	{
		SceneDirector.LoadScene( SceneDirector.SceneType.Result );
	}
}
