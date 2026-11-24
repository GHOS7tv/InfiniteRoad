using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] float Speed;
    static DoorController Vicina;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -4) * Speed * Time.deltaTime;

        if (Vicina == null || transform.position.z < Vicina.transform.position.z)
            Vicina = this;

        if (Vicina != this) return;

        if (gameObject.name.Contains("Yellow") && Input.GetKeyDown(KeyCode.Y)) Destroy(gameObject);
        if (gameObject.name.Contains("Red") && Input.GetKeyDown(KeyCode.R)) Destroy(gameObject);
        if (gameObject.name.Contains("Blue") && Input.GetKeyDown(KeyCode.B)) Destroy(gameObject);
        if (gameObject.name.Contains("Green") && Input.GetKeyDown(KeyCode.G)) Destroy(gameObject);
    }

         private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
