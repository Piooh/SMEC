using UnityEngine;
using System.Collections;


public class Coroutine : MonoBehaviour
{
	private void Awake()
	{
		StartCoroutine( FrameChecker() );

		StartCoroutine( TimeChecker() );
	}

	private IEnumerator FrameChecker()
	{
		MyDebug.Log.Normal( "Frame count : " + Time.frameCount );
		
		yield return null;

		MyDebug.Log.Normal( "Frame count : " + Time.frameCount );
	}

	private IEnumerator TimeChecker()
	{
		MyDebug.Log.Warnnig( "Time : " + Time.time );

		yield return new WaitForSeconds( 1f );

		MyDebug.Log.Warnnig( "Time : " + Time.time );
	}


	private IEnumerator MyRoutine()
	{
		yield return null;

		yield return new WaitForSeconds( 1f );

		yield return new WaitForFixedUpdate();

		yield return new WaitForEndOfFrame();
	}


	//private Texture2D downloadImage = null;

	//private IEnumerator Start()
	//{
	//	using( WWW www = new WWW("http://www.3dgep.com/wp-content/uploads/2012/07/Unity-Logo.png") )
	//	{
	//		while( false ==  www.isDone )
	//		{
	//			MyDebug.Log.Normal( "Image Download... ");
	//			yield return null;
	//		}

	//		if( false == string.IsNullOrEmpty( www.error ) )
	//		{
	//			MyDebug.Log.Error( "Iamge Download Fail!! : " + www.error );
	//		}
	//		else
	//		{
	//			downloadImage		= new Texture2D( 128, 128 );
	//			www.LoadImageIntoTexture( downloadImage );

	//			var cubePrefab	= Resources.Load<GameObject>( "Cube" );
	//			var cube		= Instantiate( cubePrefab, Vector3.zero, Quaternion.identity ) as GameObject;

	//			var cubeRender = cube.GetComponent<Renderer>();
	//			cubeRender.material.mainTexture = downloadImage;

	//			cube.transform.parent = transform;
	//		}
	//	}
	//}

	//private void OnDestroy()
	//{
	//	Destroy( downloadImage );
	//}
}
