using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class SectionTrigger : MonoBehaviour
{
    public GameObject RoadSection;
    public GameObject[] Doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {

            Instantiate(RoadSection, new Vector3(0, 0, 45), Quaternion.identity);

            int i = Random.Range(0, Doors.Length);
            Instantiate(Doors[i], new Vector3(1, 0, 50), Quaternion.identity);
        }
    }
}
