using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : Objeto {

	public GameObject portaEsquerda, portaDireita;

	private bool aberta = false;
	private Animator animE, animD;

	private void Start ( ) {
		animE = portaEsquerda.GetComponent<Animator> ( );
		animD = portaDireita.GetComponent<Animator> ( );
	}

	public override void Interagir ( ) {
		if ( aberta ) Fechar ( );
		else Abrir ( );
	}

	public void Fechar ( ) {
		animE.SetBool ( "Aberta", false );
		animD.SetBool ( "Aberta", false );
		aberta = false;
	}

	public void Abrir ( ) {
		animE.SetBool ( "Aberta", true );
		animD.SetBool ( "Aberta", true );
		aberta = true;
	}

}
