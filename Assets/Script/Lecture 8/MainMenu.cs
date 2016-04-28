using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : UIPanel
{
	public UIPanel buttonNSprite	= null;
	public UIPanel scrollview		= null;
	public UIPanel dragNDrop		= null;

	public Button btnOpenButton 	= null;

	protected override void Awake ()
	{
		Show(true);

		MyDebug.Assert (buttonNSprite);
		MyDebug.Assert (scrollview);
		MyDebug.Assert (dragNDrop);

		btnOpenButton.onClick.AddListener ( delegate{ buttonNSprite.Show(true); } );
	}

	public void OpenScrollPanel()
	{
		scrollview.Show (true);
	}

	public void OpenDragPanel()
	{
		dragNDrop.Show (true);
	}
}
