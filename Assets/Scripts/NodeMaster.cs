using UnityEngine;

public class NodeMaster : MonoBehaviour {

    public static Transform[] nodes;

    void Awake()
    {
        var nodes = new Transform[transform.childCount];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = transform.GetChild(i);
        }
    }
}
