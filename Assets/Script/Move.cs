using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Move : MonoBehaviour
{
    [Header("Impostazioni Velocità")]
    [SerializeField] private float baseSpeed = 8f;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private float maxSpeed = 25f;

    void Update()
    {
        //Calcola la velocità in base al tempo trascorso dall'inizio del livello
        float currentSpeed = baseSpeed + (Time.timeSinceLevelLoad * acceleration);

        //Limita la velocità massima
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        //Vector3.back è equivalente a new Vector3(0, 0, -1), quindi sposta l'oggetto indietro lungo l'asse Z
        transform.position += Vector3.back * currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}

/*questo sotto è il vecchio script che ho modificato, lo lascio per sicurezza
 * 
 * public class Move : MonoBehaviour
{
    [SerializeField] float Speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -4) * Speed * Time.deltaTime;
    }

         private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}*/
