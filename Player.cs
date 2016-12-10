using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	[SerializeField]
	GameObject seta, areaFaculdade;
	[SerializeField] Transform faculdade;
	[SerializeField]
	Animator anim;
	[SerializeField]
	UnityEngine.UI.Text artigosColetadosTXT, artigosEnviadosTXT, parabensTXT, instrucoesTXT,avancarTextoTXT;
	[SerializeField]
	UnityEngine.UI.Image cadeadoIMG;
	Rigidbody rb;
	MeshRenderer areaFaculMesh;
	bool controleEnvio;

	float direcao;

	int sortear, artigosColetados, artigosEnviados;

	// Use this for initialization
	void Start () 
	{
		artigosEnviados = 0;
		artigosColetados = 0;
		rb = GetComponent<Rigidbody> ();
		areaFaculMesh = areaFaculdade.GetComponent<MeshRenderer> ();
		areaFaculMesh.enabled = false;

		Time.timeScale = 0;
		instrucoesTXT.enabled = true;
		avancarTextoTXT.enabled = true;
	}

	void Update()
	{
		if (Time.timeScale == 0) {
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space)) {
				instrucoesTXT.enabled = false;
				avancarTextoTXT.enabled = false;
				Time.timeScale = 1;
			}
		}

		areaFaculdade.transform.eulerAngles += Vector3.up * 2;
		artigosColetadosTXT.text = "Artigos coletados: " + artigosColetados.ToString();
		artigosEnviadosTXT.text = "Artigos enviados: " + artigosEnviados.ToString (); 
		if (rb.velocity.magnitude < 2) {
			anim.speed = 0;
		} else {
			anim.speed = rb.velocity.magnitude / 30;
		}

		if (artigosColetados == 3) {
			areaFaculMesh.enabled = true;
			seta.GetComponent<Seta> ().setAlvo (faculdade);
			seta.GetComponent<Seta> ().setAtivarSeta (true);
		}

		if (artigosEnviados >= 3) {
			Invoke ("IrJornal", 4);
			cadeadoIMG.fillAmount += Mathf.MoveTowards (0, 1, 0.1f);
			parabensTXT.text = "Parabéns, você concluiu todos os objetivos!";
		}
		direcao = Input.GetAxisRaw ("Vertical");

		transform.eulerAngles += new Vector3 (transform.eulerAngles.x, Input.GetAxis ("Horizontal") * 3, transform.eulerAngles.z);
		rb.AddRelativeForce (Vector3.forward * 150 * Input.GetAxisRaw ("Vertical"));
	}

	void OnTriggerStay(Collider outro){
		if (outro.gameObject.name == "universidade"  && artigosColetados >= 3 && !controleEnvio && artigosEnviados < 3) {
			artigosEnviados += 1;
			controleEnvio = true;
			Invoke ("ControlarEnvio", 1);
		}
	}

	void IrJornal(){
		SceneManager.LoadScene ("Jornal");
	}

	void ControlarEnvio(){
		controleEnvio = false;
	}
	public void SetArtigos(){
		artigosColetados += 1;
	}
}


