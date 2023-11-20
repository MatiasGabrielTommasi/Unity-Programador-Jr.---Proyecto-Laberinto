using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField] GameObject player;
    public float rotationSpeed;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update() 
    {
        transform.position = player.transform.position - offset;
        //transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime); Input.GetAxis ("Mouse X")
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime);
    }
    private void OnMouseDrag()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime);
    }
}