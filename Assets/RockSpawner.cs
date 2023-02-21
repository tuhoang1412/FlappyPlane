using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject rockIcePrefab;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 0.3f);
    }
    float GetOffset(float lower, float upper)
    {
        offset = Random.Range(lower, upper);
        offset = Random.Range(lower, upper);
        return Random.value > 0.5 ? offset : -offset;
    }
    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + GetOffset(0.5f, 1.8f), transform.position.z);
        GameObject rock = Random.value < 0.9 ? Instantiate<GameObject>(rockPrefab, spawnPosition, transform.rotation) : Instantiate<GameObject>(rockIcePrefab, spawnPosition, transform.rotation);
        Vector3 shiftPosition = new Vector3(GetOffset(0.3f, 0.6f), 0, 0);
        GameObject up = rock.transform.GetChild(0).gameObject;
        up.transform.position += shiftPosition;
        GameObject down = rock.transform.GetChild(1).gameObject;
        down.transform.position -= shiftPosition;
        Invoke("Spawn", Random.Range(1.4f, 1.9f));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
