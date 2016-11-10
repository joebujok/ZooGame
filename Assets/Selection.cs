using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

    public bool selected;
    private Renderer renderer;
    private Slider energyBar;
    public Energy energy;
    private Canvas canvas;

    // Use this for initialization
    void Start () {
        renderer =  GetComponent<Renderer>();
        energy = GetComponent<Energy>();
        energyBar = GameObject.Find("SelectedObjectCanvas/Panel/EnergyBar").GetComponent<Slider>();
        canvas = GameObject.Find("SelectedObjectCanvas").GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
        if (selected) {
            this.energyBar.value = energy.EnergyLevel;
        }
	    
	}

    public void ToggleSelected() {
        if (!selected)
        {
            selected = true;
            renderer.material.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
            canvas.gameObject.SetActive(selected);
        }
        else {
            selected = false;
            renderer.material.shader = Shader.Find("Standard");
            canvas.gameObject.SetActive(selected);
        }

    }


}
