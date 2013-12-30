using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {
	public Transform spawnThis;   
	
	public static int mapWidth = 25;
	public static int mapLength = 25;

	public int monsterCount = 6;
	private int ax, az;
	private string movesLeftSTR;

	private static float x = 25;
	private static float z = 25;

	public int innx, innz, dunx, dunz, reroll, savex, savez, davex, davez;
	public float radius = 0.5f;
	public bool useAsInnerCircleRadius = true;
	
	private float offsetX, offsetZ;

	public Transform [] tile; // tile types


	//Inn, road, grass, forest, dungeon, monster

	public int[,] mapMaking = new int[mapWidth, mapLength];
	public Transform[,] pieceInfo = new Transform[mapWidth, mapLength];
//	{
//		new int[]{ 3, 3, 3, 3, 3, 3, 3, 3 },
//		new int[]{ 3, 0, 2, 2, 2, 2, 2, 3 },
//		new int[]{ 3, 2, 1, 1, 2, 2, 2, 3 },
//		new int[]{ 3, 2, 2, 2, 1, 1, 2, 3 },
//		new int[]{ 3, 2, 2, 2, 2, 2, 4, 3 },
//		new int[]{ 3, 3, 3, 3, 3, 3, 3, 3 },
//	};
	private int tileType;


	void Awake() {
		float unitLength = ( useAsInnerCircleRadius )? (radius / (Mathf.Sqrt(3)/2)) : radius;
		
		offsetX = unitLength * Mathf.Sqrt(3);
		offsetZ = unitLength * 1.5f;
		

		for( int recount = 0; recount < 2; recount++) {
			for( int i = 0; i < x; i++ ) {
				for( int j = 0; j < z; j++ ) {
			
					tileType = 2;
					if (i < 2 || i > (x - 2) || j < 2 || j > (z - 2)) {tileType = 3;}; // borders are forest
					if (i > 1 && i < x-1 && j > 1 && j < z-1) 
					{
						if (i < x*.4 && Random.Range(0, 10) < 3 && (mapMaking[i-1,j] == 3)) {tileType = 3;};
						if (i < x*.4 && Random.Range(0, 10) < 3 && (mapMaking[i-1,j+1] == 3)) {tileType = 3;};
						if (i > (x - x*.4) && Random.Range(0, 10) < 3 && (mapMaking[i+1,j] == 3)) {tileType = 3;};
						if (i > (x - x*.4) && Random.Range(0, 10) < 3 && (mapMaking[i+1,j+1] == 3)) {tileType = 3;};
						if (j < z*.4 && Random.Range(0, 10) < 3 && (mapMaking[i+1,j-1] == 3)) {tileType = 3;};
						if (j < z*.4 && Random.Range(0, 10) < 3 && (mapMaking[i-1,j-1] == 3)) {tileType = 3;};
						if (j > (z - z*.4) && Random.Range(0, 10) < 3 && (mapMaking[i+1,j+1] == 3)) {tileType = 3;};
						if (j > (z - z*.4) && Random.Range(0, 10) < 3 && (mapMaking[i-1,j+1] == 3)) {tileType = 3;};
					}
					mapMaking[i,j] = tileType;
				}
			}
		}
		innx = Random.Range (4, 9); 
		innz = Random.Range (4, 9); 
		dunx = Random.Range (17, 23); 
		dunz = Random.Range (17, 23);

		savex = innx;
		savez = innz;
		davex = dunx;
		davez = dunz;

		mapMaking[dunx, dunz] = 4;
		mapMaking[innx, innz] = 0;

		for( int i = 0; i < x*2; i++){
			reroll = Random.Range (0, 80);
			if (dunx > innx || dunz > innz)
			{
				if (reroll < 40 && dunx != innx) 
				{
					innx++;
					mapMaking[innx, innz] = 1;

				}
				if (reroll > 39 && dunz != innz) 
				{
					innz++;
					mapMaking[innx, innz] = 1;
				}
			}
			if (dunz == innz && innx < dunx) {innx++; mapMaking[innx, innz] = 1;}
			if (dunx == innx && innz < dunz) {innz++; mapMaking[innx, innz] = 1;}
		}
		mapMaking[savex, savez] = 0;
		mapMaking[davex, davez] = 4;

		for( int i = 0; i < monsterCount; i++) {
			
		Reroll:
			ax = Random.Range (2, mapWidth-2);
			az = Random.Range (2, mapLength-2);
			if (mapMaking[ax,az] != 2) 
			{
				goto Reroll;
			}
			Vector3 hexpos = HexOffset( ax, az );
			Vector3 pos = new Vector3( hexpos.x, 0, hexpos.z);
			pieceInfo[ax,az] = Instantiate(tile[5], pos, transform.rotation ) as Transform;
			
		}
		for(int i = 0; i < 1; i++){
			
			Vector3 hexpos = HexOffset( savex, savez );
			Vector3 pos = new Vector3( hexpos.x, 0, hexpos.z);
			pieceInfo[savex,savez] = Instantiate(tile[6], pos, transform.rotation ) as Transform;
		}

		for( int i = 0; i < x; i++ ) {
			for( int j = 0; j < z; j++ ) {
			

				Vector3 hexpos = HexOffset( i, j );
				Vector3 pos = new Vector3( hexpos.x, 0, hexpos.z);
				//Instantiate(tile[ mapMaking[i,j] ], pos, transform.rotation );


				pieceInfo[i,j] = Instantiate(tile[mapMaking[i,j]], pos, transform.rotation ) as Transform;

				//Debug.Log(pieceInfo[i,j].transform.position);

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