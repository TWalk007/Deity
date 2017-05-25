using UnityEngine;

public class CameraTracking : MonoBehaviour {

    public Transform player;
    public Vector3 posOffset;

    void Update()
    {
        transform.position = player.position + posOffset;
    }
}
