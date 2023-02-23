using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public float moveSpeed;
    private int leftLimit;
    // Start is called before the first frame update
    // private Vector3 XU, XD;
    private float offsetX;
    void Start()
    {
        SetXOffset();
        moveSpeed = 5f;
        leftLimit = -14;
    }
    void SetXOffset()
    {
        offsetX = Random.Range(0.4f, 0.7f);
        Vector3 horizontalShift = new Vector3(offsetX, 0, 0);
        if (Random.value > 0.5)
        {
            transform.GetChild(0).gameObject.transform.position += horizontalShift;
            transform.GetChild(1).gameObject.transform.position -= horizontalShift;
        }
        else
        {
            transform.GetChild(0).gameObject.transform.position -= horizontalShift;
            transform.GetChild(1).gameObject.transform.position += horizontalShift;
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
