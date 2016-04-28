using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderControl : UIWidget
{
	public Slider slider	= null;
	public Image progress	= null;
	public Text valueLabel	= null;

	protected override void Awake ()
	{
		MyDebug.Assert(slider);
		MyDebug.Assert(progress);
		MyDebug.Assert(valueLabel);

		slider.onValueChanged.AddListener(ChangeValue);
		valueLabel.text			= slider.value.ToString();
	}

	private void ChangeValue( float value )
	{
		progress.fillAmount		= value;
		valueLabel.text			= value.ToString();
	}
}
