using UnityEngine;
using System.Collections;

public class UIPanel : UIWidget 
{
	protected static UIPanel current = null;
	public static UIPanel Current { get{ return current; }  }

	public override void Show (bool isActive)
	{
		base.Show (isActive);

		if (true == isActive)
		{
			if (null != current) { current.Show(false); }
			current = this;
		}
	}
}
