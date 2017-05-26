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

    private NodeMaster nodeMaster;
    private WallMaster wallMaster;
    private Collider _nodeCollider;    
    private Transform[] nodes;
    private Transform[] walls;

    void Start()
    {
        nodeMaster = FindObjectOfType<NodeMaster>();
        wallMaster = FindObjectOfType<WallMaster>();

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

    public void BuildTower()
    {
        _building = false;
        _nodeCollider = _currentNode.GetComponent<Collider>();
        OnTriggerEnter(_nodeCollider);
    }

    void OnTriggerEnter(Collider other)
    {
        bool occupied;
        occupied = _currentNode.GetComponent<Node>().occupied;

        if (occupied)
        {
            Debug.Log("Current node is already occupied!");
        }
        else if (!occupied)
        {
            Debug.Log("Detected Node");
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
       GameObject _tower = (GameObject) GameObject.Instantiate (_selectedTower, _towerPos, Quaternion.identity) as GameObject;
    }
}
