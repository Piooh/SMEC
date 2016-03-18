using UnityEngine;
using System.Collections;

public class Errors : MonoBehaviour 
{
	private void Awake()
	{
		// 컴파일 에러
		//int value = 1
		//Debug.Log( value );

		// 런타임 에러
		//var type = Input.GetAxis( "Horizonttal" ).GetType();
		//Debug.Log( data );
	
		// 논리 에러
		//int from	= 0;
		//int to		= 100000000;

		//for( float factor = 0f; factor <= 1f; factor += 0.1f  )
		//{
		//	int interpolation = (int)(from * (1f - factor) + to * factor);

		//	Debug.LogError(interpolation);
		//}

		//double doubleFrom = System.Convert.ToDouble( from );
		//double doubleTo = System.Convert.ToDouble( to );

		//for( double factor = 0.0; factor <= 1.0; factor += 0.1 )
		//{
		//	int interpolation = System.Convert.ToInt32(doubleFrom * (1.0 - factor) + doubleTo * factor);

		//	Debug.LogError(interpolation);
		//}
	}
}
