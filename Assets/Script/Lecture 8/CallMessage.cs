using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public interface IFrameMessage : IEventSystemHandler
{
	void OnMessage();
	void GetFrameCount (int count);
}


public class CallMessage : MonoBehaviour 
{	
	public List<GameObject> targets = new List<GameObject>();

	private IEnumerator Start() 
	{
		while (true)
		{
			if (0 != targets.Count)
			{
				for (int i = 0; i < targets.Count; i++)
				{
					ExecuteEvents.Execute<IFrameMessage>(targets[i], null, (x, y) => x.OnMessage());
					ExecuteEvents.Execute<IFrameMessage>(targets[i], null, (x, y) => x.GetFrameCount(Time.frameCount));
				}
			}
			yield return null;
		}
	}
}
