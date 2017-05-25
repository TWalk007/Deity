using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;
    private Transform[] wallArray;

    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;


     void Start()
    {
        buildManager = GameObject.FindObjectOfType<BuildManager>();

        xMin = transform.position.x - transform.localScale.x / 2;
        xMax = transform.position.x + transform.localScale.x / 2;
        zMin = transform.position.z - transform.localScale.z / 2;
        zMax = transform.position.z + transform.localScale.z / 2;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        CanBuildOnNode();
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void CanBuildOnNode()
    {

        
    }
}
