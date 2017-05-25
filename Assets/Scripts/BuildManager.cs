﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Altar altar;
    public NodeMaster nodeMaster;
    public WallMaster wallMaster;

    public float altarNodeTolerance = 2f;
    public float wallNodeTolerance = 0.25f;

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
}