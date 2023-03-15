using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject rockIcePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 0.3f);
    }
    float GetYOffset()
    {
        return Random.Range(-1.7f, 1.7f);
    }
    void Spawn()
    {
        if (Random.value < 0.9)
        {
            Instantiate<GameObject>(rockPrefab, new Vector3(transform.position.x, transform.position.y + GetYOffset(), transform.position.z), transform.rotation);
        }
        else
        {
            Instantiate<GameObject>(rockIcePrefab, new Vector3(transform.position.x, transform.position.y + GetYOffset(), transform.position.z), transform.rotation);
        }

        Invoke("Spawn", Random.Range(1.2f, 1.6f));
    }

}
