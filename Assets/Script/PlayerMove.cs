using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	private void Awake()
	{
		transform.position = Vector3.right * 5;
		//		transform.localPosition = Vector3.right * 5;
	}
}
