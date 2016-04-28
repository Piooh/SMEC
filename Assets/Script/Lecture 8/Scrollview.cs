using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scrollview : UIWidget 
{
	public RectTransform itemRef	= null;
	public ScrollRect scrollRect	= null;

	public int TotalItemcount		= 0;
	public bool isUsedBaseCount		= true;


	public int ViewItemCount		{ get; private set; }
	public int DragRectSize			{ get; private set; }


	protected override void Awake ()
	{
		MyDebug.Assert (itemRef);
		MyDebug.Assert (scrollRect);

		Initialize();
	}

	private void Initialize()
	{
		if (true == scrollRect.horizontal && false == scrollRect.vertical)
		{
			ViewItemCount	= Mathf.FloorToInt(scrollRect.viewport.rect.width / itemRef.rect.width) + 1;
			DragRectSize	= Mathf.FloorToInt(TotalItemcount * itemRef.rect.width);

			if (true == isUsedBaseCount)	{ TotalItemcount = ViewItemCount; }

			scrollRect.content.sizeDelta = new Vector2(DragRectSize, scrollRect.viewport.sizeDelta.y);
		}
		else if (false == scrollRect.horizontal && true == scrollRect.vertical)
		{
			ViewItemCount	= Mathf.FloorToInt(scrollRect.viewport.rect.height / itemRef.rect.height) + 1;
			DragRectSize	= Mathf.FloorToInt(TotalItemcount * itemRef.rect.height);

			if (true == isUsedBaseCount)	{ TotalItemcount = ViewItemCount; }

			scrollRect.content.sizeDelta = new Vector2(scrollRect.viewport.sizeDelta.x, DragRectSize);
		}
		else
		{
			MyDebug.Assert (false);
		}


		for (int i = 0; i < ViewItemCount; i++)
		{
			var item = Instantiate(itemRef, Vector3.zero, Quaternion.identity) as RectTransform;
			item.SetParent (scrollRect.content, false);
			item.localPosition	= new Vector3 (0f, -i * itemRef.rect.height, 0f);
		}
	}
}
