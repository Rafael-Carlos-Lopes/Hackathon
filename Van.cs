using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Van : MonoBehaviour {

	NavMeshAgent navAg;
	[SerializeField]
	GameObject[] pneus;
	[SerializeField]
	Transform alvo;
	Vector3 alvo2;
	[SerializeField] UnityEngine.UI.Text gameOverTXT;
	bool alvoExiste;

	// Use this for initialization
	void Start () 
	{
		navAg = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		if (alvoExiste) 
		{
			navAg.SetDestination(alvo2);
		}

		else
			navAg.SetDestination (alvo.position);

		for (int i = 0; i < pneus.Length; i++) 
		{
			pneus [i].transform.Rotate (100 * Time.deltaTime, 0, 0);
		}
	}

	void OnTriggerEnter(Collider outro){
		if (outro.gameObject.tag == "NPC1" || outro.gameObject.tag == "NPC2" || outro.gameObject.tag == "NPC3") {
			gameOverTXT.text = "GameOver - Você não coletou todos os artigos a tempo!";
			Invoke ("IrMenu", 4);
		}
	}

	void IrMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void setAlvoExiste(bool valor)
	{
		alvoExiste = valor;
	}

	public void setAlvo(Vector3 valor)
	{
		alvo2 = valor;
	}
}


