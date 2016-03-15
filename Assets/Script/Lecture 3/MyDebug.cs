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
		public static void Line( Vector3 start, Vector3 end, Color color, float duration )
		{
			UnityEngine.Debug.DrawLine( start, end, color, duration, false );
		}

		// pos, radius, color
		public static void Circle( Vector3 position, float radius, Color color, float duration )
		{
			Vector3 point1			= Vector3.forward * radius;
			Vector3 point2;
			Quaternion rot			= Quaternion.AngleAxis( 360.0f / 50.0f, Vector3.up );
			for ( int i = 0; i < 50; i++ )
			{
				point2				= rot * point1;
				Line( position + point1, position + point2, color, duration );
				point1				= point2;
			}
		}
	}

	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert( UnityEngine.Object obj )
	{
		if( null == obj )
		{
			var stackTrace  = new System.Diagnostics.StackTrace();
			var frame		= stackTrace.GetFrame(1);

			string message	= "[!!]{Assert}[!!] : " + frame.GetMethod().Name + 
				"( " + frame.GetFileName() + " [Line : " + frame.GetFileLineNumber() + "] )";

			UnityEngine.Debug.LogError( message );
			UnityEngine.Debug.Break();
		}
	}

	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert( UnityEngine.Object obj, System.Object msg )
	{
		if( null == obj )
		{
			var stackTrace  = new System.Diagnostics.StackTrace();
			var frame		= stackTrace.GetFrame(1);
			
			string message	= "[!!]{Assert}[!!] : " + frame.GetMethod().Name + 
				"( " + frame.GetFileName() + " [Line : " + frame.GetFileLineNumber() + "] )";
			
			UnityEngine.Debug.LogError( message + msg );
			UnityEngine.Debug.Break();
		}
	}

	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert( bool boolean )
	{
		if( false == boolean )
		{
			var stackTrace  = new System.Diagnostics.StackTrace();
			var frame		= stackTrace.GetFrame(1);
			
			string message	= "[!!]{Assert}[!!] : " + frame.GetMethod().Name + 
				"( " + frame.GetFileName() + " [Line : " + frame.GetFileLineNumber() + "] )";
			
			UnityEngine.Debug.LogError( message );
			UnityEngine.Debug.Break();
		}
	}

	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert( bool boolean, System.Object msg )
	{
		if( false == boolean )
		{
			var stackTrace  = new System.Diagnostics.StackTrace();
			var frame		= stackTrace.GetFrame(1);
			
			string message	= "[!!]{Assert}[!!] : " + frame.GetMethod().Name + 
				"( " + frame.GetFileName() + " [Line : " + frame.GetFileLineNumber() + "] )";
			
			UnityEngine.Debug.LogError( message + msg );
			UnityEngine.Debug.Break();
		}
	}

	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert( System.Object obj )
	{
		if( null == obj )
		{
			var stackTrace  = new System.Diagnostics.StackTrace();
			var frame		= stackTrace.GetFrame(1);
			
			string message	= "[!!]{Assert}[!!] : " + frame.GetMethod().Name + 
				"( " + frame.GetFileName() + " [Line : " + frame.GetFileLineNumber() + "] )";
			
			UnityEngine.Debug.LogError( message );
			UnityEngine.Debug.Break();
		}
	}
	
	[System.Diagnostics.Conditional("DEBUG_DEV")]
	public static void Assert( System.Object obj, System.Object msg )
	{
		if( null == obj )
		{
			var stackTrace  = new System.Diagnostics.StackTrace();
			var frame		= stackTrace.GetFrame(1);
			
			string message	= "[!!]{Assert}[!!] : " + frame.GetMethod().Name + 
				"( " + frame.GetFileName() + " [Line : " + frame.GetFileLineNumber() + "] )";
			
			UnityEngine.Debug.LogError( message + msg );
			UnityEngine.Debug.Break();
		}
	}
}
