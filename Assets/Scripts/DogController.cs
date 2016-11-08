using UnityEngine;
using System.Collections;

public class DogController : MonoBehaviour {


    public float speed;
    public Transform target;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("FoodBowl").transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 distanceAway = target.position - transform.position;
        if (distanceAway.x >1 && distanceAway.z > 1) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Debug.Log("Current position : " + transform.position.ToString());
            Debug.Log("Distance away : " + distanceAway.ToString());
        }
        
        
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
         rb.AddForce(movement * speed);


    }
}
