using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSys : MonoBehaviour
{
    [HideInInspector]
    public delegate void GridSizeChange();
    [HideInInspector]
    public GridSizeChange onGridSizeChange;

    [SerializeField]
    private GameObject gridParent;

    public GameObject GridItem;

    public Vector2 _gridSize;
    public Vector2 GridSize
    {
        get
        {
            return _gridSize;
        }
        set
        {
            _gridSize = value;
            onGridSizeChange();
        }
    }

    public float cellGap;
    public float cellSize;

    Dictionary<Vector2, Vector3> gridDictionary = new Dictionary<Vector2, Vector3>();//<Gridposition,WorldPosition>

    // Use this for initialization
    void Start()
    {
        if (GridItem == null)
        {
            GridItem = new GameObject();
        }
        for (int i = 0; i < GridSize.x; i++)
        {        
            for (int j = 0; j < GridSize.y; j++)
            {
                Vector3 spawnpos = gridParent.transform.position;
                spawnpos.x += cellGap * i;
                spawnpos.x += cellSize * i;
                spawnpos.z += cellSize * j;
                spawnpos.z += cellGap * j;

                GameObject newNode = Instantiate(GridItem);

                newNode.transform.position = spawnpos;
                gridDictionary.Add(new Vector2(i, j), newNode.transform.position);
            }

        }

        

        //for testing anf fun

    }




    public Vector2 GetNearestPointOnGrid(Vector3 worldPosition)
    {

        int roundWorldY = 0;
        int roundWorldX = 0;

        if (worldPosition.x > GridSize.x * (cellGap + cellSize))
        {
            roundWorldY = Mathf.RoundToInt(worldPosition.z);
            return new Vector2(GridSize.x, roundWorldY / (cellGap + cellSize));
        }

        if (worldPosition.z > GridSize.y * (cellGap + cellSize))
        {
            roundWorldX = Mathf.RoundToInt(worldPosition.x);
            return new Vector2(GridSize.y, roundWorldX / (cellGap + cellSize));
        }

        if (worldPosition.x < GridSize.x * (cellGap + cellSize))
        {
            roundWorldY = Mathf.RoundToInt(worldPosition.z);
            return new Vector2(0, roundWorldY / (cellGap + cellSize));
        }

        if (worldPosition.z < GridSize.y * (cellGap + cellSize))
        {
            roundWorldX = Mathf.RoundToInt(worldPosition.x);
            return new Vector2(0, roundWorldX / (cellGap + cellSize));
        }


        roundWorldX = Mathf.RoundToInt(worldPosition.x / (cellGap + cellSize));
        roundWorldY = Mathf.RoundToInt(worldPosition.z / (cellGap + cellSize));
        return new Vector2(roundWorldX, roundWorldY);

    }

    public Vector3 GridToWorldPosition(Vector2 gridPosition)
    {
        return gridDictionary[gridPosition];
    }

}
