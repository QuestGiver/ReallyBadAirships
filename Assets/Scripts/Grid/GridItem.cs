using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridItem : MonoBehaviour
{
    [SerializeField]
    private GridSys grid;
    private MeshRenderer myMesh;
    [SerializeField]
    private ShipBlockList playerShip;

    public int hashCode;

    bool isPartOfShip;
    // Use this for initialization
    void Awake()
    {
        if (grid == null)
        {
            grid = FindObjectOfType<GridSys>();
        }
        if (playerShip == null)
        {
            playerShip = FindObjectOfType<ShipBlockList>();
        }

        myMesh = gameObject.GetComponent<MeshRenderer>();
        myMesh.enabled = false;
        isPartOfShip = false;
        hashCode = GetHashCode();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (!isPartOfShip)
        {
            myMesh.enabled = true;
        }

    }
    private void OnMouseExit()
    {
        if (isPartOfShip)
        {
            myMesh.enabled = true;
        }
        else
        {
            myMesh.enabled = false;
        }

    }
    private void OnMouseDown()
    {
        if (!isPartOfShip)
        {
            playerShip.listOfShipParts.Add(hashCode,this.gameObject);
            gameObject.transform.parent = playerShip.transform;
            isPartOfShip = true;
            myMesh.enabled = true;
        }
        else
        {
            playerShip.listOfShipParts.Remove(hashCode);
            gameObject.transform.parent = playerShip.transform;
            isPartOfShip = false;
        }
    }

}
