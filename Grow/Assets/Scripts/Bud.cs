using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bud : MonoBehaviour {

    public GridMarker current_position;

    private Shape assigned_shape = Shape.NONE;

    // each bud needs to have a game object to assign their plant 
    // LineRenderer to. A new bud means a branching path, which
    // means a new LineRenderer is needed

    public GameObject growth;

    public LineRenderer growthLine;

    public enum Direction
    {
        NORTH = 0,
        NORTH_EAST,
        EAST,
        SOUTH_EAST,
        SOUTH,
        SOUTH_WEST,
        WEST,
        NORTH_WEST
    }

    // TODO: will need to make this into some sort of object
    // which the user can assign, use enum for now
    enum Shape
    {
        NONE = 0,
        FORK,
        TRIANGLE,
        CIRCLE,
        SQUARE,
        PENTAGON
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grow()
    {
        switch(assigned_shape)
        {
            case Shape.NONE:
                // grow straight
                GridMarker north_neighbor = FindNeighboringGridMarker(Direction.NORTH);
                AdvanceGrowth(north_neighbor);
                break;
            default:
                break;
        }

    }

    /*
     * Given that this bud is at current_position, find
     * the neighboring GridMarker according to Direction
     **/
    private GridMarker FindNeighboringGridMarker(Direction dir)
    {
        return PlantManager.instance.GetGridMarker(current_position.xGridPosition, current_position.yGridPosition);
    }

    private void AdvanceGrowth(GridMarker position)
    {
        growthLine.positionCount += 1;
        growthLine.SetPosition(growthLine.positionCount - 1, position.obj.transform.position);
        current_position = position;
    }

    public void InstantiateLineRenderer()
    {
        growthLine = growth.AddComponent<LineRenderer>();
        growthLine.positionCount = 1;
        growthLine.SetPosition(0, current_position.obj.transform.position);
        growthLine.material = new Material(Shader.Find("Particles/Additive"));
        growthLine.startColor = Color.white;
        growthLine.endColor = Color.white;
        growthLine.startWidth = 0.2f;
        growthLine.endWidth = 0.2f;
        growthLine.useWorldSpace = true;
    }
}
