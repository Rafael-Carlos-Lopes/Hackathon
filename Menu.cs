using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(NavMeshAgent))]
public class Menu : MonoBehaviour {

	public void Iniciar(){
		SceneManager.LoadScene ("game");
	}

	public void SaibaMais(){
		Application.OpenURL ("http://portal.fiocruz.br/pt-br/acessoaberto");
	}

	public void IrMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void PeriodicosFiocruz(){
		Application.OpenURL ("http://www.periodicos.fiocruz.br");
	}

	public void Sair(){
		Application.Quit ();
	}
}


