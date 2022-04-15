using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockGenerator : MonoBehaviour
{
    public Tilemap map;
    public TileBase[] blocks;
    public int XScale = 22;
    public int YScale = 11;
    public int healthRarity;
    public int healthKey;

    private Transform playerTransform;
    [HideInInspector]public int SpawnX = 0;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        GenerateTerrain();
    }

    private void Update()
    {
        if (playerTransform.gameObject.GetComponent<GridMovement>().isMoving)
        {
            GenerateTerrain();
        }
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < XScale; x++)
        {
            for (int y = 0; y < YScale; y++)
            {
                Vector3Int spawnPos = new Vector3Int(x + (int)playerTransform.position.x, y + (int)playerTransform.position.y);

                if (!map.GetTile(spawnPos))
                {
                    int blockId = Random.Range(0, blocks.Length - 2);
                    int isHealth = Random.Range(0, healthRarity);
                    if (isHealth == healthKey)
                    {
                        map.SetTile(spawnPos, blocks[blocks.Length - 1]);
                    }
                    else
                    {
                        map.SetTile(spawnPos, blocks[blockId]);
                    }
                }
            }
        }
        for (int x = -XScale; x < 0; x++)
        {
            for (int y = -YScale; y < 0; y++)
            {
                Vector3Int spawnPos = new Vector3Int(x + (int)playerTransform.position.x, y + (int)playerTransform.position.y);

                if (!map.GetTile(spawnPos))
                {
                    int blockId = Random.Range(0, blocks.Length - 2);
                    int isHealth = Random.Range(0, healthRarity);
                    if (isHealth == healthKey)
                    {
                        map.SetTile(spawnPos, blocks[blocks.Length - 1]);
                    }
                    else
                    {
                        map.SetTile(spawnPos, blocks[blockId]);
                    }
                }
            }
        }
        for (int x = -XScale; x < 0; x++)
        {
            for (int y = 0; y < YScale; y++)
            {
                Vector3Int spawnPos = new Vector3Int(x + (int)playerTransform.position.x, y + (int)playerTransform.position.y);

                if (!map.GetTile(spawnPos))
                {
                    int blockId = Random.Range(0, blocks.Length - 2);
                    int isHealth = Random.Range(0, healthRarity);
                    if (isHealth == healthKey)
                    {
                        map.SetTile(spawnPos, blocks[blocks.Length - 1]);
                    }
                    else
                    {
                        map.SetTile(spawnPos, blocks[blockId]);
                    }
                }
            }
        }
        for (int x = 0; x < XScale; x++)
        {
            for (int y = -YScale; y < 0; y++)
            {
                Vector3Int spawnPos = new Vector3Int(x + (int)playerTransform.position.x, y + (int)playerTransform.position.y);

                if (!map.GetTile(spawnPos))
                {
                    int blockId = Random.Range(0, blocks.Length - 2);
                    int isHealth = Random.Range(0, healthRarity);
                    if (isHealth == healthKey)
                    {
                        map.SetTile(spawnPos, blocks[blocks.Length - 1]);
                    }
                    else
                    {
                        map.SetTile(spawnPos, blocks[blockId]);
                    }
                }
            }
        }
    }
}
