using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject _currentNode;
    public GameObject _selectedTower;
    public Altar altar;
    public float altarNodeTolerance = 2f;
    public float wallNodeTolerance = 0.25f;
    public Vector3 _towerPos;
    public bool isNodeClearOfWall = true;
    public bool _building = false;

    private Collider _nodeCollider;    
    private Transform[] nodes;
    private Transform[] walls;

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
        //PrintArrayNames(walls);  // This DID print all of the wall GameObjects in the scene.
        Collider towerCol = _selectedTower.GetComponent<Collider>();
        for (int i = 0; i < walls.Length; i++)
        {
            //walls[i].GetComponent<Wall>().OnTriggerEnter(towerCol);
            //Wall _wallScript = walls[i].GetComponent<Wall>();
            //_wallScript.OnTriggerEnter(towerCol);
        }
    }

    void BuildTower()
    {
        _building = false;
        WallCheck();
        _nodeCollider = _currentNode.GetComponent<Collider>();
        OnTriggerEnter(_nodeCollider);
    }

    void OnTriggerEnter(Collider col)
    {
        bool occupied;
        occupied = _currentNode.GetComponent<Node>().occupied;

        if (occupied)
        {
            Debug.Log("Current node is already occupied!");
        }
        else if (!occupied)
        {
            //Debug.Log("Detected Node");
            PlaceSelectedTower();
            BuildToggle();
        }
    }

    void BuildToggle()
    {
        _currentNode.GetComponent<Node>().occupied = true;
    }

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
