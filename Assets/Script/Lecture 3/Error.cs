using UnityEngine;
using System.Collections;

public class Error : MonoBehaviour 
{
	public GameObject target = null;

	private void Awake()
	{
		//컴파일 오류
//		int a = 1

		// 런타임 오류
//		Debug.Log (target.name);


		// 논리 오류.
		int from = 0;
		int to = 100000000;

		var doubleFrom = System.Convert.ToDouble (from);
		var doubleTo = System.Convert.ToDouble (to);


		for (double factor = 0.1f; factor <= 1.0; factor += 0.1 ) 
		{
			int interpolation = (int)System.Convert.ToDouble( (from * (1.0f - factor) + to * factor) );

			Debug.LogError (interpolation);

		}
	}
}
