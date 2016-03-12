using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
	private void Awake()
	{
		Debug.Log ("Awake()");
	}

	private void Start()
	{
		Debug.Log ("Start()");
	}

	private void OnEnable()
	{
		Debug.Log ("OnEnable()");
	}

	private void FixedUpdate()
	{
		Debug.Log ("FixedUpdate()");
	}

	private void Update()
	{
		Debug.Log ("Update()");
	}

	private void OnDisable()
	{
		Debug.Log ("OnDisable()");
	}

	private void OnDestroy()
	{
		Debug.Log ("OnDisable()");
	}
}
