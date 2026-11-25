using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [Header("Impostazioni Velocità")]
    [SerializeField] private float baseSpeed = 8f;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float maxSpeed = 25f;
    static DoorController NearestDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calcola la velocità in base al tempo trascorso dall'inizio del livello
        float currentSpeed = baseSpeed + (Time.timeSinceLevelLoad * acceleration);

        //Limita la velocità massima
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        //Vector3.back è equivalente a new Vector3(0, 0, -1), quindi sposta l'oggetto indietro lungo l'asse Z
        transform.position += Vector3.back * currentSpeed * Time.deltaTime;

        if (NearestDoor == null || transform.position.z < NearestDoor.transform.position.z)
            NearestDoor = this;

        if (NearestDoor != this) return;

        if (gameObject.name.Contains("Yellow") && Input.GetKeyDown(KeyCode.Y)) Destroy(gameObject);
        if (gameObject.name.Contains("Red") && Input.GetKeyDown(KeyCode.R)) Destroy(gameObject);
        if (gameObject.name.Contains("Blue") && Input.GetKeyDown(KeyCode.B)) Destroy(gameObject);
        if (gameObject.name.Contains("Green") && Input.GetKeyDown(KeyCode.G)) Destroy(gameObject);
    }

         private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
