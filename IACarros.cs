using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(NavMeshAgent))]
public class IACarros : MonoBehaviour {
	NavMeshAgent navMesh;
	[SerializeField]
	Transform[] points;

	void Start(){
		navMesh = GetComponent<NavMeshAgent> ();
		InvokeRepeating ("MudarRota", 1, 10);
	}

	void MudarRota(){
		navMesh.SetDestination (points[Random.Range (0, 4)].position);
	}
}


