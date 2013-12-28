using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {
	public Transform spawnThis;   
	
	public int x = 5;
	public int z = 5;

	public int mapWidth = 25;
	public int mapLength = 25;

	public float radius = 0.5f;
	public bool useAsInnerCircleRadius = true;
	
	private float offsetX, offsetZ;

	public Transform [] tile; // tile types
	
	//Inn, road, grass, forest, dungeon

	private int[][] mapMaking = 
	{
		new int[]{ 3, 3, 3, 3, 3, 3, 3 },
		new int[]{ 3, 0, 2, 2, 2, 2, 3 },
		new int[]{ 3, 2, 1, 1, 2, 2, 3 },
		new int[]{ 3, 2, 2, 2, 1, 2, 3 }
		new int[]{ 3, 2, 2, 2, 2, 4, 3 },
		new int[]{ 3, 3, 3, 3, 3, 3, 3 },
		
	};

	void Start() {
		float unitLength = ( useAsInnerCircleRadius )? (radius / (Mathf.Sqrt(3)/2)) : radius;
		
		offsetX = unitLength * Mathf.Sqrt(3);
		offsetZ = unitLength * 1.5f;
		

		for( int i = 0; i < 6; i++ ) {
			for( int j = 0; j < 7; j++ ) {
				Vector3 hexpos = HexOffset( i, j );
				Vector3 pos = new Vector3( hexpos.x, 0, hexpos.z);
				Instantiate(tile[ mapMaking[i][j] ], pos, transform.rotation );
			}
		}
	}
	
	Vector3 HexOffset( int x, int z ) {
		Vector3 position = Vector3.zero;
		
		if( z % 2 == 0 ) {
			position.x = x * offsetX;
			position.z = z * offsetZ;
		}
		else {
			position.x = ( x + 0.5f ) * offsetX;
			position.z = z * offsetZ;
		}
		
		return position;
	}
}