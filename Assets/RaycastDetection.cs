using UnityEngine;
using System.Collections;

public class RaycastDetection : MonoBehaviour
{
    public Camera camera;
    public GameObject dog;
    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        dog = GameObject.Find("Dog");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                string hitItem = hit.transform.name;
                Debug.Log("You selected the " + hitItem + " Position : " ); // ensure you picked right object
                switch (hitItem)
                {
                    case "Ground":
                        dog.GetComponent<StatePatternDog>().currentState.HandleRoomClick(hit);
                        break;
                    case "Dog":
                        dog.GetComponent<Selection>().ToggleSelected();
                        
                        break;
                    default:
                        break;
                }

                //dog.getComponent<StatePatternDog>()

                
            }
        }
    }
}
