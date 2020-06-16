using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiaNoite : MonoBehaviour {

	public static DiaNoite d;
	private void Awake ( ) { d = this; }

	public float horario = 12.0f;                           // HORÁRIO ATUAL, EM SEGUNDOS
	public float offsetRelogio, offsetRotacao;
	public Light Sol;
	public bool usarSoisFake;
	public Light[] fakeSol;

	public int velox;
	public float intensidade, fakeIntensidade;
	public Color fogday = Color.grey;
	public Color fognight = Color.black;

	public GameObject ponteiroHoras, ponteiroMinutos;

	void FixedUpdate ( ) {
		ChangeTime ( );
	}

	public void ChangeTime ( ) {
		horario += Time.deltaTime * velox;
		if ( horario >= 24.0f ) horario = 0;

		Sol.transform.rotation = Quaternion.Euler ( new Vector3 (
			( horario - offsetRotacao ) / 24.0f * 360,
			35,
			0
		) );

		ponteiroHoras.transform.localRotation = Quaternion.Euler ( new Vector3 (
			0,
			-2 * ( horario - offsetRelogio ) / 24.0f * 360,
			0
		) );
		ponteiroMinutos.transform.localRotation = Quaternion.Euler ( new Vector3 (
			0,
			-1 * ( horario - offsetRelogio ) / 1.0f * 360,
			0
		) );

		if ( horario < 5 ) intensidade = 0;
		else if ( horario < 6 ) intensidade = horario - 5;
		else if ( horario < 12 ) intensidade = 1;
		else if ( horario < 18 ) intensidade = 1;
		else if ( horario < 19 ) intensidade = 19 - horario;
		else intensidade = 0;

		Sol.intensity = intensidade * 2;
		if ( usarSoisFake ) foreach ( Light l in fakeSol ) l.intensity = fakeIntensidade * intensidade;

		RenderSettings.fogColor = Color.Lerp ( fognight, fogday, intensidade * intensidade * intensidade );
	}

}
