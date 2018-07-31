using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour {

    // singleton pattern allows this to be called from other scripts
    public static PlantManager instance; 

    // create list of Buds
    public List<Bud> bud_list = new List<Bud>();

    // list of grid objects
    public List<GridMarker> gridMarkers = new List<GridMarker>();

    // Use this for initialization
    void Start () {
        instance = GetComponent<PlantManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GrowAll()
    {

    }

    void InitiateGridMarkers()
    {

    }
}
