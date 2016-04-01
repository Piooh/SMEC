using UnityEngine;
using System.Collections;

public class SceneFader : MonoSingleton<SceneFader>
{
	public enum FadeMode
	{
		In,
		Out,
	}

	public Texture2D fadeTexture = null;

	public Color currentColor	= Color.clear;
	public Color beginColor		= Color.clear;
	public Color endColor		= Color.black;


	private float from			= 0f;
	private float to			= 1f;
	private float factor		= 0f;

	private bool isFading		= false;
	private Rect textureRect;
	public bool IsFading { get{ return isFading; } }

	public void BeginFader( FadeMode FadeMode )
	{
		isFading		= true;
	}



	protected override void DoAwake()
	{
		textureRect		= new Rect( -10, -10, Screen.width + 10, Screen.height + 10 );
		fadeTexture		= new Texture2D( 4, 4 );

		for( int x = 0; x<4; x++ )
		{
			for( int y = 0; y<4; y++ )
			{
				fadeTexture.SetPixel( x, y, Color.black );
			}
		}
	}

	private IEnumerator FadeIn()
	{
		currentColor.a = from * (1 - factor ) + to * factor;

		yield return null;
	}

	private IEnumerator FadeOut()
	{
		yield return null;
	}

	private void OnGUI()
	{
		if( true == isFading )
		{
			GUI.depth = 10000;
			GUI.color = currentColor;
			GUI.DrawTexture(textureRect, fadeTexture);
		}

	
	}
}
