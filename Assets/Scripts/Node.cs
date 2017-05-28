using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    public bool occupied = false;

    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;
    private Transform[] wallArray;

     void Start()
    {
        buildManager = GameObject.FindObjectOfType<BuildManager>();

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseOver()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseUp()
    {
        //TODO: Add code to check if there is enough money to build here.
        buildManager._currentNode = this.gameObject;

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        buildManager._towerPos = newPos;

        buildManager._building = true;
    }
}
