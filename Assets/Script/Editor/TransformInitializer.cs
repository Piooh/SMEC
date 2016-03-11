﻿using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class TransformInitializer : Editor
{	
	private SerializedProperty mPos;
	private SerializedProperty mRot;
	private SerializedProperty mScale;

	private void OnEnable ()
	{
		mPos = serializedObject.FindProperty("m_LocalPosition");
		mRot = serializedObject.FindProperty("m_LocalRotation");
		mScale = serializedObject.FindProperty("m_LocalScale");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		
		EditorGUIUtility.labelWidth = 15f;

		DrawPosition();
		DrawScale();
		DrawRotation();

		serializedObject.ApplyModifiedProperties();
	}

	private void DrawPosition()
	{
		GUILayout.BeginHorizontal();
		{
			EditorGUILayout.LabelField( "Position" ); 
			bool reset = GUILayout.Button( "P", GUILayout.Width(30f) );
			
			EditorGUILayout.PropertyField( mPos.FindPropertyRelative("x") );
			EditorGUILayout.PropertyField( mPos.FindPropertyRelative("y") );
			EditorGUILayout.PropertyField( mPos.FindPropertyRelative("z") );

			if(true == reset) { mPos.vector3Value = Vector3.zero; } 
		}
		GUILayout.EndHorizontal();
	}

	private void DrawScale()
	{
		GUILayout.BeginHorizontal();
		{
			EditorGUILayout.LabelField( "Scale" ); 
			bool reset = GUILayout.Button( "S", GUILayout.Width(30f) );
			
			EditorGUILayout.PropertyField( mScale.FindPropertyRelative("x") );
			EditorGUILayout.PropertyField( mScale.FindPropertyRelative("y") );
			EditorGUILayout.PropertyField( mScale.FindPropertyRelative("z") );

			if(true == reset) { mScale.vector3Value = Vector3.one; } 
		}
		GUILayout.EndHorizontal();
	}


	//
	private enum Axes : int
	{
		None = 0,
		X = 1,
		Y = 2,
		Z = 4,
		All = 7,
	}

	private static bool Differs (float a, float b) { return Mathf.Abs(a - b) > 0.0001f; }

	private Axes CheckDifference (Transform t, Vector3 original)
	{
		Vector3 next = t.localEulerAngles;

		Axes axes = Axes.None;

		if (Differs(next.x, original.x)) axes |= Axes.X;
		if (Differs(next.y, original.y)) axes |= Axes.Y;
		if (Differs(next.z, original.z)) axes |= Axes.Z;

		return axes;
	}

	private Axes CheckDifference (SerializedProperty property)
	{
		Axes axes = Axes.None;

		if (property.hasMultipleDifferentValues)
		{
			Vector3 original = property.quaternionValue.eulerAngles;

			foreach (Object obj in serializedObject.targetObjects)
			{
				axes |= CheckDifference(obj as Transform, original);
				if (axes == Axes.All) break;
			}
		}
		return axes;
	}

	private float Fixed180Angle( float angle )
	{
		while( 180f < angle ) { angle -= 360f; }
		while( -180 > angle ) { angle += 360f; }
		return angle;
	}

	private static bool FloatField (string name, ref float value, bool hidden, GUILayoutOption opt)
	{
		float newValue = value;
		GUI.changed = false;

		if (!hidden)
		{
			newValue = EditorGUILayout.FloatField(name, newValue, opt);
		}
		else
		{
			float.TryParse(EditorGUILayout.TextField(name, "--", opt), out newValue);
		}

		if (GUI.changed && Differs(newValue, value))
		{
			value = newValue;
			return true;
		}
		return false;
	}


	private void DrawRotation()
	{
		GUILayout.BeginHorizontal();
		{
			EditorGUILayout.LabelField( "Rotation" ); 
			bool reset		= GUILayout.Button( "R", GUILayout.Width(30f) );

			Vector3 visible = (serializedObject.targetObject as Transform).localEulerAngles;
			visible.x		= Fixed180Angle( visible.x );
			visible.y		= Fixed180Angle( visible.y );
			visible.z		= Fixed180Angle( visible.z );

			Axes changed	= CheckDifference(mRot);
			Axes altered	= Axes.None;

			GUILayoutOption opt = GUILayout.MinWidth(30f);

			if (FloatField("X", ref visible.x, (changed & Axes.X) != 0, opt)) altered |= Axes.X;
			if (FloatField("Y", ref visible.y, (changed & Axes.Y) != 0, opt)) altered |= Axes.Y;
			if (FloatField("Z", ref visible.z, (changed & Axes.Z) != 0, opt)) altered |= Axes.Z;

			if(true == reset) { mRot.quaternionValue = Quaternion.identity; } 
			else if(altered != Axes.None)
			{
				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;
					Vector3 v = t.localEulerAngles;

					if ((altered & Axes.X) != 0) v.x = visible.x;
					if ((altered & Axes.Y) != 0) v.y = visible.y;
					if ((altered & Axes.Z) != 0) v.z = visible.z;

					t.localEulerAngles = v;
				}
			}
		}
		GUILayout.EndHorizontal();
	}
}
