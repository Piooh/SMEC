using UnityEngine;

public class AndroidPluginManager : MonoSingleton<AndroidPluginManager>
{
	private AndroidJavaObject pluginActivity = null;

	public bool HasPluginActivity { get { return null != pluginActivity;  } }

	protected override void DoAwake()
	{
		AndroidJavaClass  androidJavaClass = new AndroidJavaClass( "com.unity3d.player.UnityPlayer");
		if( null != androidJavaClass )
		{
			pluginActivity = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			//androidJavaClass.Dispose();

			if( null == pluginActivity )
			{
				MyDebug.Log.Error("************************************************************** [ PluginActivity is Null.... ]");
				return;
			}
		}
	}

	public int PluginSum( int value1, int value2 )
	{
		if( false ==  HasPluginActivity ) { return 0;  }
		return pluginActivity.Call<int>("PluginSum", value1, value2 );
	}

	private System.Action<string> testCall;
	public void PluginMessage( System.Action<string> callback )
	{
		if( false ==  HasPluginActivity ) { return;  }
		pluginActivity.Call("PluginMessage");

		testCall = callback;
	}

	private void ReceiveMessage( string str )
	{
		if( null !=  testCall) { testCall(str); }
	}
}
