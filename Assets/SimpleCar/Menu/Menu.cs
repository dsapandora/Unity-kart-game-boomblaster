using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	//private Ray ray;
	private RaycastHit hit;
	private bool selection;
	private string selectedSceneName;
	
	// Use this for initialization
	void Start () {
		GameObject.Find("Loading").renderer.enabled = false;
	}
	

	
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp(KeyCode.Escape))
		{
    	  Application.Quit();
		}
		
		// Only select a scene when the mouse is on the text at mouse down and up,
		// therefore giving the user the ability to move away from the link and cancel
		// the action.
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Input.GetMouseButtonDown(0))
		{
			// Change colour when GUI text intersects the raycast
			Color clr = new Color(0, 0, 1, 1);
			if(Physics.Raycast(ray,out hit))
			{
				if(hit.transform.name.Equals("SinglePlayer"))
				{
					selection = true;
					hit.collider.renderer.material.SetColor("_Color", clr);
					
					selectedSceneName = "SinglePlayer";
				}
				if(hit.transform.name.Equals("MultiPlayer"))
				{
					selection = true;
					hit.collider.renderer.material.SetColor("_Color", clr);
					
					selectedSceneName = "MultiPlayer";
				}
			}
		}
		
		if(Input.GetMouseButtonUp(0) && selection == true)
		{
			// Change colour when GUI text intersects the raycast
			if(Physics.Raycast(ray,out hit))
			{
				Color clr = new Color(0, 1, 1, 1);
				hit.collider.renderer.material.SetColor("_Color", clr);
				
				GameObject.Find("Loading").renderer.enabled = true;
				
				
				Application.LoadLevel(selectedSceneName);
				selection = false;
			}
			else
			{
				Color clr = new Color(1, 1, 1, 1);
				
				GameObject objSinglePlayer = GameObject.Find("SinglePlayer");
				GameObject objMultiPlayer = GameObject.Find("MultiPlayer");
				
				objSinglePlayer.collider.renderer.material.SetColor("_Color", clr);
				objMultiPlayer.collider.renderer.material.SetColor("_Color", clr);
				
				selection = false;
			}
		}
	}
}
