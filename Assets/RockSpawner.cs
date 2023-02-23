using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject rockIcePrefab;
    private float offsetY;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("Spawn", 0.3f);
    }
    Vector3 GetYOffset()
    {
        offsetY = Random.Range(0.5f, 1.8f);
        if (Random.value > 0.5)
        {
            return new Vector3(transform.position.x, transform.position.y + offsetY, transform.position.z);
        }
        else
        {
            return new Vector3(transform.position.x, transform.position.y - offsetY, transform.position.z);
        }
    }

    void Spawn()
    {
        // SetXOffset();
        // Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + GetOffset(0.5f, 1.8f), transform.position.z);
        GameObject rock = Random.value < 0.9 ? Instantiate<GameObject>(rockPrefab, GetYOffset(), transform.rotation) : Instantiate<GameObject>(rockIcePrefab, GetYOffset(), transform.rotation);
        // Vector3 shiftPosition = new Vector3(GetOffset(0.3f, 0.6f), 0, 0);
        // down.transform.position -= shiftPosition;
        Invoke("Spawn", Random.Range(1.4f, 1.9f));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
