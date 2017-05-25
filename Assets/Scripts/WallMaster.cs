using UnityEngine;

public class WallMaster : MonoBehaviour {

    public static Transform[] walls;

    public bool checkWall = false;

    void Awake()
    {
        walls = new Transform[transform.childCount];
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        if (checkWall)
        {
            //RUN THE CAN BUILD CHECK.
            checkWall = false;
        }
        
    }

}
