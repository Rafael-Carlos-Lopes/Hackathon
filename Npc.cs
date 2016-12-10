using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Npc : MonoBehaviour {
	Image dialogoIMG;
	GameObject instanciar, seta, van;
	bool controleDialo;
	[SerializeField] Sprite[] dialogo1, dialogo2, dialogo3;
	int contadorDialogo = 0;
	float delay;

	// Use this for initialization
	void Start () 
	{
		dialogoIMG = GameObject.Find ("DialogoIMG").GetComponent<Image>();
		dialogoIMG.enabled = false;
		van = GameObject.FindGameObjectWithTag ("Van");
		seta = GameObject.FindGameObjectWithTag ("Seta");
		instanciar = GameObject.FindGameObjectWithTag ("Instantiator");
		seta.GetComponent<Seta> ().setAlvo (transform);
		seta.GetComponent<Seta> ().setAtivarSeta (true);
		van.GetComponent<Van> ().setAlvo (transform.position);
		van.GetComponent<Van> ().setAlvoExiste (true);

	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag.Equals ("Player")) 
		{
			dialogoIMG.enabled = true;
			van.GetComponent<Van>().setAlvoExiste (false);
			if (tag == "NPC1") {
				seta.GetComponent<Seta> ().setAtivarSeta (false);
				if (contadorDialogo < dialogo1.Length)
					dialogoIMG.sprite = dialogo1 [contadorDialogo];
				if (Input.GetButtonUp ("Jump") && !controleDialo/*Input.GetButtonDown ("Jump")*/) {
					contadorDialogo += 1;
				controleDialo = true;
					Invoke ("MudarTexto", 1);
				}
				if (contadorDialogo > dialogo1.Length) {
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().SetArtigos ();
					dialogoIMG.enabled = false;
					contadorDialogo = 0;
					instanciar.GetComponent<Instanciar> ().SetExisteNpc (false);
					Destroy (gameObject);
				}
			} else if (tag == "NPC2") {
				seta.GetComponent<Seta> ().setAtivarSeta (false);
				if (contadorDialogo < dialogo2.Length)
					dialogoIMG.sprite = dialogo2 [contadorDialogo];
				if (Input.GetButtonUp ("Jump") && !controleDialo/*Input.GetButtonDown ("Jump")*/) {
					contadorDialogo += 1;
				controleDialo = true;
					Invoke ("MudarTexto", 1);
				}
				if (contadorDialogo > dialogo2.Length) {
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().SetArtigos ();
					dialogoIMG.enabled = false;
					contadorDialogo = 0;
					instanciar.GetComponent<Instanciar> ().SetExisteNpc (false);
					Destroy (gameObject);
				}
			} else if (tag == "NPC3") {
				if (contadorDialogo < dialogo3.Length)
					dialogoIMG.sprite = dialogo3 [contadorDialogo];
				if (Input.GetButtonUp ("Jump") && !controleDialo/*Input.GetButtonDown ("Jump")*/){
					contadorDialogo += 1;
				controleDialo = true;
					Invoke ("MudarTexto", 1);
			}
				if (contadorDialogo > dialogo3.Length){
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().SetArtigos ();
					dialogoIMG.enabled = false;
					contadorDialogo = 0;
					instanciar.GetComponent<Instanciar> ().SetExisteNpc (false);
					Destroy (gameObject);
				}

			}
		}
	}

	void MudarTexto(){
		controleDialo = false;
	}
}


