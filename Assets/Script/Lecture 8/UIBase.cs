using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class UIBase : UIBehaviour
{
	public static void UIActive<T>( T ui, bool active ) where T : MonoBehaviour
	{
		if (null == ui || null == ui.gameObject)	{ return; }
		if( active != ui.gameObject.activeSelf )	{ ui.gameObject.SetActive(active); }
	}
		
	public virtual RectTransform RectTrans
	{
		get 
		{
			if (null == rectTrans) { rectTrans = GetComponent<RectTransform> (); }
			MyDebug.Assert(rectTrans);
			return rectTrans;
		}
	}

	private RectTransform rectTrans			= null;
}
	
