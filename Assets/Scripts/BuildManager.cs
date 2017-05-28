using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject _currentNode;
    public GameObject _selectedTower;
    public Altar altar;
    public float altarNodeTolerance = 1.5f;
    public float wallNodeTolerance = 0.25f;
    public Vector3 _towerPos;
    public bool isNodeClearOfWall = true;
    public bool _building = false;

    private Collider _nodeCollider;    
    private Transform[] nodes;
    private Transform[] walls;

    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    private bool nodeOccupied = false;

    void Start()
    {
        nodes = NodeMaster.nodes;
        walls = WallMaster.walls;

        AltarNodeClear();
    }

    void Update()
    {
        if (_building)
        {
            BuildTower();
        }

    }

    void PrintArrayNames (Transform[] arr)
    {
        foreach (Transform item in arr)
        {
            print("Transform[] index name: " + item.gameObject.name);
        }
    }

    void WallCheck()
    {
        for (int i = 0; i < walls.Length; i++)
        {

        }
    }
    
    //Get the wall dimensions and store them in their variables for use later.
    void WallFootprint(Transform trans)
    {
        xMin = trans.position.x - trans.localScale.x / 2;
        xMax = trans.position.x + trans.localScale.x / 2;
        zMin = trans.position.z - trans.localScale.z / 2;
        zMax = trans.position.z + trans.localScale.z / 2;
    }

    void BuildTower()
    {
        _building = false;
        WallCheck(); //Make sure the tower will not interfere with a wall.
        _nodeCollider = _currentNode.GetComponent<Collider>();
        OnTriggerEnter(_nodeCollider); // check's to see if there is already something on the node.

        if (!nodeOccupied)
        {
            PlaceSelectedTower();
            BuildToggle();
        }
    }

    //Checks to see if the node is already occupied when clicking.
    void OnTriggerEnter(Collider col)
    {
        nodeOccupied = _currentNode.GetComponent<Node>().occupied;

        if (nodeOccupied)
        {
            Debug.Log("Current node is already occupied!");
            return;
        }
    }

    //Sets the current nodes occupied bool to true;
    void BuildToggle()
    {
        _currentNode.GetComponent<Node>().occupied = true;
    }

    //Clears the nodes around the altar before game start.
    void AltarNodeClear()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            if ((nodes[i].position.x > altar.xMin - altarNodeTolerance) && 
                (nodes[i].position.x < altar.xMax + altarNodeTolerance) && 
                (nodes[i].position.z > altar.zMin - altarNodeTolerance) && 
                (nodes[i].position.z < altar.zMax + altarNodeTolerance))
            {
                Destroy(nodes[i].gameObject);
            }
        }
    }

    void PlaceSelectedTower()
    {
       Instantiate (_selectedTower, _towerPos, Quaternion.identity);
    }
}
