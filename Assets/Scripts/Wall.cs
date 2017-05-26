using UnityEngine;

public class Wall : MonoBehaviour {
    
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

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "Tower")
        {
            Debug.Log("You cannot place a tower in the wall!");
        }
    }
}
