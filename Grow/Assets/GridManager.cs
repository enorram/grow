using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static GridManager instance; // singleton pattern allows this to be called from other scripts

    public List<Sprite> characters = new List<Sprite>(); // sprites to use for tile peices 
    public GameObject tile; // prefab instantiated when board created
    public int xSize, ySize; // dimensions of board
    public Vector3 screenPosition = new Vector3(0, 0, 20);
    public Vector3 bufferSpace = new Vector3(0.00f, 0.00f, 0.00f);

    private GameObject[,] tiles; // used to store tiles in board

    // Use this for initialization
    void Start () {
        instance = GetComponent<GridManager>();
        transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
        GameObject debugWidth = Instantiate(tile, new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight), tile.transform.rotation);
        debugWidth.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)); // this puts an 'x' on the top right corner of the screen as expected


        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];

        float startX = transform.position.x + 0.5f;
        float startY = transform.position.y + 0.5f;

        for (int x = 0; x < xSize; x++)
        {      // 11
            for (int y = 0; y < ySize; y++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
                tiles[x, y] = newTile;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
