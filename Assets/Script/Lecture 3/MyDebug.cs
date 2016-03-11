#if UNITY_EDITOR

#define DEBUG_DEV

#endif


using System;
using UnityEngine;
using System.Collections;

public class MyDebug 
{
	public class Log
	{
		[System.Diagnostics.Conditional("DEBUG_DEV")]
		public static void Normal( System.Object message )
		{
			UnityEngine.Debug.Log( Frame() + message );
		}

		[System.Diagnostics.Conditional("DEBUG_DEV")]
		public static void Normal( System.Object message, UnityEngine.Object context )
		{
			UnityEngine.Debug.Log( Frame() + message, context );
		}

		[System.Diagnostics.Conditional("DEBUG_DEV")]
		public static void Warnnig( System.Object message )
		{
			UnityEngine.Debug.LogWarning( Frame() + message );
		}

		[System.Diagnostics.Conditional("DEBUG_DEV")]
		public static void Warnnig( System.Object message, UnityEngine.Object context )
		{
			UnityEngine.Debug.LogWarning( Frame() + message, context );
		}

		[System.Diagnostics.Conditional("DEBUG_DEV")]
		public static void Error( System.Object message )
		{
			UnityEngine.Debug.LogError( Frame() + message );
		}

		[System.Diagnostics.Conditional("DEBUG_DEV")]
		public static void Error( System.Object message, UnityEngine.Object context )
		{
			UnityEngine.Debug.LogError( Frame() + message, context );
		}


		private static string Frame()
		{
			return string.Format( "[{0}] : ", Time.frameCount );
		}
	}

	public class Draw2D
	{
		// start, end, duration, color
		public static void Line()
		{
		}

		// pos, radius, color
		public static void Circle()
		{
		}
	}

	public class Draw3D
	{
		public static GameObject Box()
		{
			return null;
		}

		public static GameObject Sphere()
		{
			return null;
		}
	}

	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert()
	{
	}
}
