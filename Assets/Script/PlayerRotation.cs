using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour 
{

	private void Update()
	{
		if (true == Input.GetKeyUp (KeyCode.Space)) 
		{
			transform.rotation = Quaternion.identity;
			Debug.Log ("Reset World");
		} 
		else if (true == Input.GetKeyUp (KeyCode.Escape)) 
		{
			transform.localRotation = Quaternion.identity;
			Debug.Log ("Reset Local");
		}
	}
}
