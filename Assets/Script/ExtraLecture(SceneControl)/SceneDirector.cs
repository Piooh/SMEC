using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoSingleton<SceneDirector> 
{

	//public class LoadingContents
	//{

	//	public float progress = 0f;
	//	public System.Action DoStart;
	//	public System.Action OnDone;
	//}


	public enum SceneType : int
	{
		Lobby		= 0,
		Game		= 1,
		Result		= 2,
		Loading		= 3,
	}

	public static void LoadScene( SceneType scene )
	{
		SceneManager.LoadScene( (int)scene );
	}

	public static void AsycLoadScene( SceneType scene )
	{
		// 1. 페이드 아웃 하고
		// 2. 로딩 씬 불러 오고
		// 3. 비동기 씬 로딩.

		Inst.AsycLoad( scene );
	}

	private AsyncOperation progress = null;


	public void AsycLoad( SceneType scene )
	{
		StartCoroutine( AsycLoading( scene ) );
	}

	private IEnumerator AsycLoading( SceneType scene )
	{
		SceneManager.LoadScene( (int)SceneType.Loading );

		yield return null;

		progress = SceneManager.LoadSceneAsync( (int)scene );

		while( false == progress.isDone )
		{
			LoadingPage.Inst.progressBar.value = progress.progress;

			yield return null;
		}

		progress = null;

		SceneManager.UnloadScene( (int)SceneType.Loading );
	}
}
