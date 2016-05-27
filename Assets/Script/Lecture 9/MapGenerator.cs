using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoSingleton<MapGenerator>
{
	public MapNode root				= null;
	private List<MapNode> leafs	= new List<MapNode>();

	public void Create()
	{
		root					= null;
		Random.seed	= Time.realtimeSinceStartup.ToString().GetHashCode();

		var mapRect		= new Rect( 0, 0, 500f, 500f );
		root					= Generator( mapRect, 4 );

		//root.DrawAll();
		//DrawPath( root );
		leafs.Clear();
		root.CollectLeaf( ref leafs );
		for( int i = 0; i<leafs.Count; i++ )	{ leafs[i].DrawRoom(); }
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
		if( null == node.left || null == node.right )	{ return; }

		Vector3 start = new Vector3( node.left.rect.center.x, 0f, node.left.rect.center.y );
		Vector3 end = new Vector3( node.right.rect.center.x, 0f, node.right.rect.center.y );

		MyDebug.Draw2D.Line( start,end, Color.blue, float.MaxValue );

		DrawPath( node.left );
		DrawPath( node.right );
	}
}
