using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlaneScript : MonoBehaviour
{
    public GameObject mainCamera;
    public Rigidbody2D planeBody;

    private float pushStrength;
    private bool alive;
    private LogicHandler logicHandler;
    [SerializeField]
    private AudioSource fly;
    [SerializeField]
    private AudioSource collect;
    // Start is called before the first frame update
    void Start()
    {
        logicHandler = mainCamera.GetComponent<LogicHandler>();
        pushStrength = 5.7f;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Debug.Log("Push");
            fly.Play();
            planeBody.velocity = Vector2.up * pushStrength;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (alive)
        {
            collect.Play();
            if (other.gameObject.CompareTag("Star"))
            {
                logicHandler.UpdateScore(1);
            }
            else if (other.gameObject.CompareTag("StarIce"))
            {
                logicHandler.UpdateScore(5);
            }
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (alive && other.gameObject.CompareTag("Rock"))
        {
            alive = false;
            Invoke("DisplayGameOver", 0.2f);
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            Invoke("DisplayGameOver", 0.2f);
        }
    }
    void DisplayGameOver()
    {
        logicHandler.GameOver();
    }
}
