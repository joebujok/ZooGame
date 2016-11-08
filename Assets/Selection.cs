using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

    public bool selected;
    private Renderer renderer;

// Use this for initialization
    void Start () {
        renderer =  GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void ToggleSelected() {
        if (!selected)
        {
            selected = true;
            renderer.material.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
        }
        else {
            selected = false;
            renderer.material.shader = Shader.Find("Standard");
        }

    }


}
