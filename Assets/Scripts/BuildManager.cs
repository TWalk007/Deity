using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Altar altar;
    public NodeMaster nodeMaster;
    public WallMaster wallMaster;

    public float altarNodeTolerance = 2f;
    public float wallNodeTolerance = 0.25f;

    public bool isNodeClearOfWall = true;

    private bool canBuild = false;
    private bool _building = false;

    public GameObject _currentNode;
    public GameObject _selectedTower;
    public Vector3 _towerPos;

    private Transform[] nodes;
    private Transform[] walls;

    private Collider _nodeCollider;

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
            OnTriggerEnter(_nodeCollider);
        }

    }

    public void BuildTower()
    {
        _nodeCollider = _currentNode.GetComponent<Collider>();
        _building = true;
    }

    void OnTriggerEnter(Collider other)
    {
        canBuild = other.transform.gameObject.GetComponent<Node>().occupied;
        //Debug.Log("Detected Node");
        if (other.transform.gameObject.tag == "Node")
        {
            
            if (canBuild)
            {
                Debug.Log("Detected Node");
                PlaceSelectedTower();
                BuildToggle();
            }
            else
            {
                Debug.Log("Node is already occupied!");
            }
        }
    }

    void BuildToggle()
    {
        canBuild = false;
        other.transform.gameObject.GetComponent<Node>().occupied = canBuild;
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
