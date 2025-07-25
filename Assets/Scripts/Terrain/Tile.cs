using UnityEngine;

public class Tile : MonoBehaviour
{
    public const int TILE_SIZE = 32;


    public Vector3Int TilePosition
    {
        get { return Vector3Int.FloorToInt(transform.position / TILE_SIZE); }
    }

    public void SetTilePosition(Vector3Int pos)
    {
        transform.position = new Vector3(pos.x * TILE_SIZE, 0, pos.z * TILE_SIZE);
    }

}
