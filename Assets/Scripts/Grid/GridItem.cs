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
    public float defaultOpacity = 0.25f;




    public bool isPartOfShip;
    // Use this for initialization
    void Awake()
    {

        //var color = gameObject.GetComponent<Renderer>().material.color;
        //var newColor = new Color(color.r, color.g, color.b, 0.5f);
        //gameObject.GetComponent<Renderer>().material.color = newColor;

        if (grid == null)
        {
            grid = FindObjectOfType<GridSys>();
        }
        if (playerShip == null)
        {
            playerShip = FindObjectOfType<ShipBlockList>();
        }

        myMesh = gameObject.GetComponent<MeshRenderer>();
        //myMesh.enabled = false;
        myMesh.material.color = new Color(myMesh.material.color.r, myMesh.material.color.g, myMesh.material.color.b, defaultOpacity);
        //isPartOfShip = false;
        hashCode = GetHashCode();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (CommonAccessibles.CurrentGameState == CommonAccessibles.GameState.BUILDMODE)
        {
            if (!isPartOfShip)
            {
                myMesh.material.color = new Color(myMesh.material.color.r, myMesh.material.color.g, myMesh.material.color.b, 1f);
                //myMesh.enabled = true;
            }

        }


    }
    private void OnMouseExit()
    {
        if (CommonAccessibles.CurrentGameState == CommonAccessibles.GameState.BUILDMODE)
        {
            if (isPartOfShip)
            {
                //myMesh.enabled = true;
                myMesh.material.color = new Color(myMesh.material.color.r, myMesh.material.color.g, myMesh.material.color.b, 1f);
            }
            else
            {
                myMesh.material.color = new Color(myMesh.material.color.r, myMesh.material.color.g, myMesh.material.color.b, defaultOpacity);
                //myMesh.enabled = false;
            }
        }
    }
    private void OnMouseDown()
    {
        if (CommonAccessibles.CurrentGameState == CommonAccessibles.GameState.BUILDMODE)
        {
            if (!isPartOfShip)
            {
                playerShip.listOfShipParts.Add(hashCode, gameObject);
                //gameObject.transform.parent = playerShip.transform;
                isPartOfShip = true;
                //transform.position += Vector3.up;
                //myMesh.enabled = true;
                myMesh.material.color = new Color(myMesh.material.color.r, myMesh.material.color.g, myMesh.material.color.b, 1f);

            }
            else
            {
                playerShip.listOfShipParts.Remove(hashCode);
                gameObject.transform.parent = null;
                isPartOfShip = false;
            }
        }

    }

    public void OnBulletCollision()
    {
        if (CommonAccessibles.CurrentGameState == CommonAccessibles.GameState.FIGHTMODE)
        {
            playerShip.listOfShipParts.Remove(hashCode);
            gameObject.transform.parent = null;
            isPartOfShip = false;
        }

    }



}
