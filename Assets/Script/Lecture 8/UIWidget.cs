using UnityEngine;
using System.Collections;

public class UIWidget : UIBase
{
	public virtual void Show( bool isActive )
	{
		gameObject.SetActive (isActive);

		if (true == isActive) { UpdateUI(); }
	}

	public virtual void UpdateUI()
	{
		// do update
	}

	protected virtual void Awake()		{}
	protected virtual void OnEnable()	{}
	protected virtual void Start()		{}
	protected virtual void Update()		{}
	protected virtual void OnDisable()	{}
	protected virtual void OnDestroy()	{}
}
