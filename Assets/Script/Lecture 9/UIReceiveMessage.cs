using UnityEngine;
using UnityEngine.UI;

public class UIReceiveMessage : MonoBehaviour
{
	public Text showMessage = null;

	public void ShowReceiveMessage()
	{
		AndroidPluginManager.Inst.PluginMessage( Callback );
	}

	private void Callback( string str )
	{
		showMessage.text = str;
	}
}
