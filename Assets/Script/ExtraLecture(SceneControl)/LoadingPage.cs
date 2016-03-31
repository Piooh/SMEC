using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingPage : MonoBehaviour 
{
	public Slider progressBar = null;

	public static LoadingPage Inst = null;

	private void Awake()
	{
		if( null == Inst )
		{
			Inst = this;
		}
	}
}
