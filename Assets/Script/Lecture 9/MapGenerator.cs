using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoSingleton<MapGenerator>
{
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


			MyDebug.Draw2D.Line(lt, rt, Color.red, 999999999999f );
			MyDebug.Draw2D.Line(lb, rb, Color.red, 999999999999f );
			MyDebug.Draw2D.Line(rt, rb, Color.red, 999999999999f );
			MyDebug.Draw2D.Line(lt, lb, Color.red, 999999999999f );
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

			
			MyDebug.Draw2D.Line(lt, rt, Color.green, 999999999999f );
			MyDebug.Draw2D.Line(lb, rb, Color.green, 999999999999f );
			MyDebug.Draw2D.Line(rt, rb, Color.green, 999999999999f );
			MyDebug.Draw2D.Line(lt, lb, Color.green, 999999999999f );
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

	public MapNode root = null;

	protected override void DoAwake ()
	{
		Random.seed	= Time.realtimeSinceStartup.ToString().GetHashCode();

		var mapRect		= new Rect( 0, 0, 500f, 500f );
		root			= Generator( mapRect, 4 );

		root.DrawAll();
		
		DrawPath( root );

		List<MapNode> list = new List<MapNode>();
		root.CollectLeaf( ref list );

		for( int i = 0; i<list.Count; i++ )
		{
			list[i].DrawRoom();
		}
	}


	private MapNode Generator( Rect rect, int iterCount )
	{
		var node = new MapNode( rect );
		
		if( 0 != iterCount )
		{
			Rect r1, r2;
			RandomSplit( rect, out r1, out r2 );

			node.left = Generator( r1, iterCount - 1 );
			node.right = Generator( r2, iterCount - 1 );
		}

		return node;
	}

	private void RandomSplit(Rect rect, out Rect split1, out Rect split2 )
	{
		split1	= new Rect();
		split2	= new Rect();
		if( 0 == Random.Range(0, 2) )		// vertical
		{
			split1.min	= rect.min;
			split1.size = new Vector2( Random.Range(1, rect.size.x), rect.size.y );
			//split1.center = split1.max * 0.5f;

			split2.min	= new Vector2( rect.xMin + split1.size.x, rect.yMin );
			split2.size = new Vector2( rect.size.x - split1.size.x, rect.size.y );
			//split2.center = split2.max * 0.5f;

			float split1_ratio = split1.width / split1.height;
			float split2_ratio = split2.width / split2.height;
			if( 0.45f > split1_ratio || 0.45f > split2_ratio )
			{
				RandomSplit( rect, out split1, out split2 );
			}
		}
		else								// horizontal
		{
			split1.min	= rect.min;
			split1.size = new Vector2( rect.size.x, Random.Range(1, rect.size.y) );
			//split1.center = split1.max * 0.5f;

			split2.min	= new Vector2( rect.xMin, rect.yMin + split1.size.y );
			split2.size = new Vector2( rect.size.x, rect.size.y - split1.size.y );
			//split2.center = split2.max * 0.5f;

			float split1_ratio = split1.height / split1.width;
			float split2_ratio = split2.height / split2.width;
			if( 0.45f > split1_ratio || 0.45f > split2_ratio )
			{
				RandomSplit( rect, out split1, out split2 );
			}
		}
	}

	private void DrawPath( MapNode node )
	{
		if( null == node.left || null == node.right )
		{
			return;
		}

		Vector3 start = new Vector3( node.left.rect.center.x, 0f, node.left.rect.center.y );
		Vector3 end = new Vector3( node.right.rect.center.x, 0f, node.right.rect.center.y );

		MyDebug.Draw2D.Line( start,end, Color.blue, 999999999999f );

		DrawPath( node.left );
		DrawPath( node.right );
	}
}
