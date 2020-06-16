using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour {

	public float alcance;
	public Image pontaria;

	private RaycastHit objetoNaMira;

	void Start ( ) {
		objetoNaMira = new RaycastHit ( );
	}

	void Update ( ) {
		DetectarObjetoNoAlcance ( );

		if ( Input.GetMouseButtonUp ( 0 ) && objetoNaMira.collider != null ) {
			objetoNaMira.collider.GetComponent<Objeto> ( ).Interagir ( );
		}
	}

	void DetectarObjetoNoAlcance ( ) {

		Transform cam = Camera.main.transform;
		Ray ray = new Ray ( cam.position, cam.forward );
		RaycastHit hit;
		if ( Physics.Raycast ( ray, out hit, alcance ) ) {
			if ( hit.collider.name.Contains ( "OBJ_" ) ) AcenderPonteiro ( hit );
			else ApagarPonteiro ( );
		}
		else ApagarPonteiro ( );
	}

	void AcenderPonteiro ( RaycastHit hit ) {
		objetoNaMira = hit;
		pontaria.color = new Color32 ( 0, 255, 0, 255 );
	}

	void ApagarPonteiro ( ) {
		objetoNaMira = new RaycastHit ( );
		pontaria.color = new Color32 ( 255, 255, 255, 255 );
	}

}
