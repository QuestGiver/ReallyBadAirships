using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//place on character controller

public class ShipBlockList : MonoBehaviour
{
    bool destroyOnLoad;
    public Dictionary<int,GameObject> listOfShipParts = new Dictionary<int, GameObject>();

    private void Awake()
    {
          CommonAccessibles.stateChangeHandler += CreateChildren;      
    }

    // Use this for initialization
    void Start()
    {


        DontDestroyOnLoad(gameObject);

        CommonAccessibles.CurrentGameState = CommonAccessibles.GameState.BUILDMODE;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Destroy(gameObject);
        }
    }

    void CreateChildren()
    {
        foreach (GameObject item in listOfShipParts.Values)
        {
            item.transform.parent = gameObject.transform;
        }
    }

}
