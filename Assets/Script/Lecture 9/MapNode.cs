using UnityEngine;
using System.Collections.Generic;

public class MapNode
{
	public Rect rect;
	public MapNode left	= null;
	public MapNode right	= null;

	public MapNode( Rect rectAngle )
	{
		rect		= rectAngle;
	}

	public void Draw()
	{
		Vector3 lt = new Vector3( rect.xMin, 0f, rect.yMin );
		Vector3 rt = new Vector3( rect.xMax, 0f, rect.yMin );
		Vector3 lb = new Vector3( rect.xMin, 0f, rect.yMax );
		Vector3 rb = new Vector3( rect.xMax, 0f, rect.yMax );


		MyDebug.Draw2D.Line(lt, rt, Color.red, float.MaxValue );
		MyDebug.Draw2D.Line(lb, rb, Color.red, float.MaxValue );
		MyDebug.Draw2D.Line(rt, rb, Color.red, float.MaxValue );
		MyDebug.Draw2D.Line(lt, lb, Color.red, float.MaxValue );
	}

	public void DrawRoom()
	{
		Vector4 room = Vector4.zero;

		room.x = rect.xMin + Random.Range( 0, Mathf.Floor(rect.width/3) );
		room.y = rect.yMin + Random.Range( 0, Mathf.Floor(rect.height/3) );
		room.z = rect.width - (room.x - rect.xMin);
		room.w = rect.height - (room.y - rect.yMin);
		room.z -= Random.Range( 0, room.z/3);
		room.w -= Random.Range( 0, room.z/3);

		Vector3 lt = new Vector3( room.x, 0f, room.y );
		Vector3 rt = new Vector3( room.x + room.z, 0f, room.y );
		Vector3 lb = new Vector3( room.x, 0f, room.y + room.w );
		Vector3 rb = new Vector3( room.x + room.z, 0f, room.y + room.w );

			
		MyDebug.Draw2D.Line(lt, rt, Color.green, float.MaxValue );
		MyDebug.Draw2D.Line(lb, rb, Color.green, float.MaxValue );
		MyDebug.Draw2D.Line(rt, rb, Color.green, float.MaxValue );
		MyDebug.Draw2D.Line(lt, lb, Color.green, float.MaxValue );
	}

	public void DrawAll()
	{
		Draw();
		if( null != left )		{ left.DrawAll(); }
		if( null != right )		{ right.DrawAll(); }
	}

	public void CollectLeaf( ref List<MapNode> list )
	{
		if( null == left && null == right )
		{
			list.Add( this );
		}
		else
		{
			if( null != left ) { left.CollectLeaf( ref list ); } 
			if( null != right ) { right.CollectLeaf( ref list ); }
		}
	}
}