using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform torget;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - torget.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 newposition = new Vector3(offset.x + torget.position.x, offset.y + torget.position.y, offset.z + torget.position.z);
        transform.position = newposition;
    }
}
