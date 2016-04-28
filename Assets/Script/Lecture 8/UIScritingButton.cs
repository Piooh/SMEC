using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class UIScritingButton : UIBase, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData evt )
	{
		MyDebug.Log.Normal ("Hi");
	}
}
