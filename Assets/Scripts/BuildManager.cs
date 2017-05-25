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

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public bool isNodeClearOfWall = true;

    private Transform[] nodes;
    private Transform[] walls;

    private void Start()
    {
        nodes = NodeMaster.nodes;
        walls = WallMaster.walls;

        AltarNodeClear();
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

    //public void NodeWallClearanceCheck()
    //{

    //    Debug.Log(walls[0].gameObject.name);
        //for (int i = 0; i < walls.Length; i++)
        //{
        //    Wall wall;
        //    wall = walls[i].GetComponent<Wall>();

        //    Debug.Log("wall.xMin = " + wall.xMin);
        //    float wallXMin = wall.xMin;
        //    float wallXMax = wall.xMax;
        //    float wallZMin = wall.zMin;
        //    float wallZMax = wall.zMax;

        //    if ((xMin > wallXMin) && (xMax < wallXMax) &&
        //        (zMin > wallZMin) && (zMax < wallZMax))
        //    {
        //        isNodeClearOfWall = false;
        //        Debug.Log("isNodeClearOfWall  = " + isNodeClearOfWall);
        //    }
        //}   
    //}
}
