using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//place on character controller

public class ShipBlockList : MonoBehaviour
{
    private static ShipBlockList instance = null;
    public Dictionary<int,GameObject> listOfShipParts = new Dictionary<int, GameObject>();

    private void Awake()
    {
          CommonAccessibles.stateChangeHandler += CreateChildren;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {


        //DontDestroyOnLoad(gameObject);

        CommonAccessibles.CurrentGameState = CommonAccessibles.GameState.BUILDMODE;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            foreach (GameObject item in listOfShipParts.Values)
            {
                Destroy(item);
            }
            listOfShipParts.Clear();
        }
        if (SceneManager.GetActiveScene().name == "CoreScene")
        {
            transform.position = new Vector3(11, 0, 5);
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x,0.25f,0.9f);
        pos.y = Mathf.Clamp(pos.y,0.25f,0.75f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    void CreateChildren()
    {
        foreach (GameObject item in listOfShipParts.Values)
        {
            item.transform.parent = gameObject.transform;
        }
    }

}
