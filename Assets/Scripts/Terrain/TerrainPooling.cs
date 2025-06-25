using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainPooling : MonoBehaviour
{
    List<GameObject> tiles = new List<GameObject>();
    public Transform player;
    public GameObject tilePrefab;

    public int tileSize;

    private Vector2Int previousCell;

    void Start()
    {
        previousCell = Vector2Int.FloorToInt(player.position / 16);

        for (int x = 0; x < tileSize * 3; x += tileSize)
        {
            for (int y = 0; y < tileSize * 3; y += tileSize)
            {
                tiles.Add(GameObject.Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity));
            }
        }
    }

    void Update()
    {
        Vector2Int currentCell = Vector2Int.FloorToInt(player.position / tileSize);

        if (previousCell != currentCell)
        {
            foreach (var tile in tiles)
            {
                Vector2Int dir = currentCell - previousCell;
                if (dir.x != 0)
                {
                    if ((previousCell - dir).x == tile.GetComponent<Tile>().TilePosition.x)
                    { 
                        Debug.Log("Se movio en el eje X");
                        Vector2Int pos = currentCell + dir;
                        pos.y = tile.GetComponent<Tile>().TilePosition.y;
                        tile.GetComponent<Tile>().SetTilePosition(pos);
                    } 
                }
                else
                {
                    if ((previousCell - dir).y == tile.GetComponent<Tile>().TilePosition.y)
                    {
                        Debug.Log("Se movio en el eje Y");
                        Vector2Int pos = currentCell + dir;
                        pos.x = tile.GetComponent<Tile>().TilePosition.x;
                        tile.GetComponent<Tile>().SetTilePosition(pos);
                    }
                }

            }

            previousCell = currentCell;
        }
    }


}
