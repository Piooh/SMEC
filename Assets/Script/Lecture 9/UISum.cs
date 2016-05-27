using UnityEngine;
using UnityEngine.UI;

public class UISum : MonoBehaviour
{
	public InputField leftFiled = null;
	public InputField rightFiled = null;
	public Text resultFiled = null;
	
	public void Sum()
	{
		int leftValue		= string.Empty == leftFiled.text ? 0 : int.Parse( leftFiled.text );
		int rightValue	= string.Empty == rightFiled.text ? 0 : int.Parse( rightFiled.text );
		int result          = AndroidPluginManager.Inst.PluginSum( leftValue, rightValue );

		resultFiled.text = result.ToString();
	}
}
