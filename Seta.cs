using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Seta : MonoBehaviour {

	MeshRenderer mr;
	Transform alvo;
	[SerializeField] Transform faculdade;

	bool ativarSeta;

	// Use this for initialization
	void Start () 
	{
		mr = GetComponent<MeshRenderer> ();
	}

	void Update()
	{
		if (ativarSeta == true) {
			mr.enabled = true;
			transform.LookAt (alvo.position);
		}
		else
			mr.enabled = false;
	}

	public void setAtivarSeta(bool valor)
	{
		ativarSeta = valor;
	}

	public void setAlvo(Transform valor)
	{
		alvo = valor;
	}
}


