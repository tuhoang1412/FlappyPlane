using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public float moveSpeed;
    private int leftLimit;
    private ScoreCounter score;
    // Start is called before the first frame update
    // private Vector3 XU, XD;
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<ScoreCounter>();
        moveSpeed = 5f;
        leftLimit = -12;
    }

    // Update is called once per frame
    void Update()
    {
        if (score.score >= 20)
        {
            moveSpeed = 7f;
        }
        else if (score.score >= 10)
        {
            moveSpeed = 6f;
        }
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
    void FixedUpdate()
    {
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
