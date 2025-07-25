using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainPooling : MonoBehaviour
{
    List<GameObject> tiles = new List<GameObject>();
    public Transform player;
    public GameObject tilePrefab;

    private Vector3Int previousCell;

    private void OnEnable()
    {
        EventManager.PlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        EventManager.PlayerDeath -= OnPlayerDeath;
    }

    void Start()
    {
        previousCell = Vector3Int.FloorToInt(player.position / 16);

        for (int x = 0; x < Tile.TILE_SIZE * 3; x += Tile.TILE_SIZE)
        {
            for (int z = 0; z < Tile.TILE_SIZE * 3; z += Tile.TILE_SIZE)
            {
                tiles.Add(Instantiate(tilePrefab, new Vector3(x, 0, z), tilePrefab.transform.rotation));
            }
        }
    }

    void Update()
    {
        Vector3Int currentCell = Vector3Int.FloorToInt(player.position / Tile.TILE_SIZE);

        if (previousCell != currentCell)
        {

            foreach (var tile in tiles)
            {
                Vector3Int dir = currentCell - previousCell;
                if (dir.x != 0)
                {
                    if ((previousCell - dir).x == tile.GetComponent<Tile>().TilePosition.x)
                    { 
                        Vector3Int pos = currentCell + dir;
                        pos.z = tile.GetComponent<Tile>().TilePosition.z;
                        tile.GetComponent<Tile>().SetTilePosition(pos);
                    } 
                }
                else
                {
                    if ((previousCell - dir).z == tile.GetComponent<Tile>().TilePosition.z)
                    {
                        Vector3Int pos = currentCell + dir;
                        pos.x = tile.GetComponent<Tile>().TilePosition.x;
                        tile.GetComponent<Tile>().SetTilePosition(pos);
                    }
                }

            }

            previousCell = currentCell;
        }
    }

    private void OnPlayerDeath()
    {
        Destroy(gameObject);
    }


}
