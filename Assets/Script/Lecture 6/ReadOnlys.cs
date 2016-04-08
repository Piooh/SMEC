using UnityEngine;
using System.Collections;

public class ReadOnlys
{
	public static readonly int DefaultMaterialColor = Shader.PropertyToID("_Color");

	public class Layers
	{
		public static readonly int Wall		= LayerMask.NameToLayer("Wall");
		public static readonly int Red		= LayerMask.NameToLayer("Red");
		public static readonly int Yellow	= LayerMask.NameToLayer("Yellow");
		public static readonly int Blue		= LayerMask.NameToLayer("Blue");
		public static readonly int Ball		= Red | Yellow | Blue;
	}
}
