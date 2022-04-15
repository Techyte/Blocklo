using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class BlockTile : ScriptableObject
{
    public int points;
    public bool isBlank;
    public TileBase tile;
}
