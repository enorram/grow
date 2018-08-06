using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

    // singleton pattern allows this to be called from other scripts
    public static PlantManager instance;

    private static int BOARD_START_X = -6;

    private static int BOARD_START_Y = 4;

    private static int BOARD_MARKER_MARGIN = 3;

    public GameObject grid_marker_prefab;

    // create list of Buds
    public List<Bud> bud_list = new List<Bud>();

    // Potted plant starting position
    public GridMarker starting_position;

    // list of grid objects
    public GridMarker[,] grid_markers;

    // dimensions of grid
    public static int GRID_WIDTH = 5;

    public static int GRID_HEIGHT = 4;

    // Use this for initialization
    void Start () {
        instance = GetComponent<PlantManager>();

        starting_position.xGridPosition = 2;
        starting_position.yGridPosition = 3;
        GameObject gm = Instantiate(grid_marker_prefab, new Vector3(BOARD_START_X + (BOARD_MARKER_MARGIN * 2), BOARD_START_Y - (BOARD_MARKER_MARGIN * 3), 0), grid_marker_prefab.transform.rotation);
        starting_position.obj = gm;

        // instantiate all grid markers with their position and neighbor knowledge 
        CreateBoard();

        grid_markers[(GRID_WIDTH - 1) / 2, GRID_HEIGHT - 1] = starting_position;

        // create initial bud and set position
        GameObject original_bud_gm = new GameObject();
        Bud original_bud = original_bud_gm.AddComponent<Bud>();
        original_bud.current_position = starting_position;
        original_bud.growth = original_bud_gm;
        original_bud.InstantiateLineRenderer();
        bud_list.Add(original_bud);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            print("creating board as a test to see if this does anything!");
        }
    }

    void GrowAll()
    {
        foreach (Bud b in bud_list)
        {
            // call grow on bud
            b.Grow();
        }

    }

    /// <summary>
    /// Returns the GridMarker at gridXPosition, gridYPosition.
    /// If no GridMarker exists, returns null.
    /// First row is the Y coordinate 0
    /// </summary>
    /// <param name="gridXPosition"></param>
    /// <param name="gridYPosition"></param>
    /// <returns></returns>
    public GridMarker GetGridMarker(int gridXPosition, int gridYPosition)
    {
        return grid_markers[gridXPosition, gridYPosition];
    }

    /// <summary>
    /// For each grid in grid_markers, give it a grid position
    /// so it can find it's neighbors later
    /// </summary>
    private void CreateBoard()
    {
        grid_markers = new GridMarker[GRID_WIDTH, GRID_HEIGHT];
        for (int x = 0; x < GRID_WIDTH; x++)
        {
            for (int y = 0; y < GRID_HEIGHT - 1; y++)
            {

                GameObject gm = Instantiate(grid_marker_prefab, new Vector3(BOARD_START_X + (BOARD_MARKER_MARGIN * x), BOARD_START_Y - (BOARD_MARKER_MARGIN * y), 0), grid_marker_prefab.transform.rotation);
                GridMarker newGridMarker = gm.AddComponent<GridMarker>();
                newGridMarker.xGridPosition = x;
                newGridMarker.yGridPosition = y;
                newGridMarker.obj = gm;
                grid_markers[x, y] = newGridMarker;
            }
        }
    }
}
