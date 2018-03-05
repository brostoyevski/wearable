using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {

	GameObject btn_go;
	Button btn;
	Text btn_txt;

	// Use this for initialization
	void Start () {
		btn_go = GameObject.Find("btn_cube");
		btn = btn_go.GetComponentInChildren<Button>();
		btn.onClick.AddListener(btnselect);
	}

	void btnselect (){print("change");ChangeView();}

	void Update () {
		
	}

	int VIEW_MAIN = 0;
	int VIEW_CUBE = 1;

	void ChangeView ()
	{
		print("new");
		SceneManager.LoadScene("view_cube");
	}
}
