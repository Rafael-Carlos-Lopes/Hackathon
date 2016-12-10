using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Instanciar : MonoBehaviour {
	[SerializeField] GameObject[] npc, posInstanciar;
	bool existeNpc;
	float contador;
	int numerosInstan = 0;

	void Start(){

	}

	void Update(){
		Instanciando ();
	}

	void Instanciando(){
		if (!existeNpc)
			contador += Time.deltaTime;

		if (numerosInstan <= 2) {
			if (contador >= 4) {
			
				GameObject g = (GameObject)Instantiate (npc [numerosInstan], posInstanciar [numerosInstan].transform.position, Quaternion.identity);
				numerosInstan++;
				contador = 0;
				existeNpc = true;
			}
		}
	}

	public void SetExisteNpc(bool controle){
		existeNpc = controle;
	}
}


