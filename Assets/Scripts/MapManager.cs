using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public Tilemap map;
    public Transform player;
    public int maxHealth;
    private int currentHealth;
    private int currentPoints;
    private bool isDead;

    private Vector3Int lastPointTaken;
    private Vector3Int lastBlankSteppedOn;

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI healthDisplay;
    public GameObject deathOverlay;
    public AudioSource hurt, heal, getPoint, losePoint;

    public TileBase blankTile;
    public TileBase healthTile;

    public List<BlockTile> tileDatas;

    private Dictionary<TileBase, BlockTile> dataFromTiles;

    private void Awake()
    {
        lastPointTaken = Vector3Int.zero;

        dataFromTiles = new Dictionary<TileBase, BlockTile>();

        foreach (var tileData in tileDatas)
        {
            dataFromTiles.Add(tileData.tile, tileData);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isDead)
        {
            if (Input.touchCount < 0 || Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        TileBase currentTile = map.GetTile(new Vector3Int(Mathf.RoundToInt(player.position.x - 0.5f), Mathf.RoundToInt(player.position.y - 0.5f)));
        Vector3Int currentTilePos = new Vector3Int(Mathf.RoundToInt(player.position.x - 0.5f), Mathf.RoundToInt(player.position.y - 0.5f));

        if (currentTile)
        {
            if (currentTile == blankTile && lastBlankSteppedOn != currentTilePos)
            {
                hurt.Play();
                currentHealth -= 1;
            }
            lastBlankSteppedOn = currentTilePos;

            if(currentTile == healthTile)
            {
                heal.Play();
                currentHealth++;
            }

            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            int points = dataFromTiles[currentTile].points;

            if(!(lastPointTaken == currentTilePos))
            {
                currentPoints += points;
                if(points > 0)
                {
                    getPoint.Play();
                }
                else
                {
                    losePoint.Play();
                }
            }

            lastPointTaken = currentTilePos;
        }

        if (currentTile != blankTile)
        {
            map.SetTile(currentTilePos, blankTile);
        }

        if(currentHealth <= 0)
        {
            Die();
        }

        scoreDisplay.text = currentPoints.ToString();
        healthDisplay.text = currentHealth.ToString();
    }

    void Die()
    {
        deathOverlay.SetActive(true);
        player.GetComponent<GridMovement>().canMove = false;
        isDead = true;
    }
}
