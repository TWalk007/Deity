using UnityEngine;

public class Altar : MonoBehaviour {

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    void Awake()
    {
        xMin = transform.position.x - transform.localScale.x / 2;
        xMax = transform.position.x + transform.localScale.x / 2;
        zMin = transform.position.z - transform.localScale.z / 2;
        zMax = transform.position.z + transform.localScale.z / 2;
    }        
}
