using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int TilePosition
    {
        get { return Vector2Int.FloorToInt(transform.position / 32); }
    }

    public void SetTilePosition(Vector2Int pos)
    {
        transform.position = new Vector3(pos.x * 32, pos.y * 32, 0);
    }

}
