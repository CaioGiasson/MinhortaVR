using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzOutrosAP : MonoBehaviour {

	public float acende, apaga, potencia;
	public Light luz;

	void Start ( ) {
		acende = Random.Range ( 18, 20 );
		apaga = Random.Range ( 21, 24 );
		potencia = Random.Range ( 2, 5f );
		luz.color = Color.Lerp ( Color.yellow, Color.white, Random.Range ( 0, 1 ) );
	}

	void Update ( ) {
		if ( DiaNoite.d.horario > acende && DiaNoite.d.horario < apaga ) luz.intensity = potencia;
		else luz.intensity = 0;
	}
}
