using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject visao;
	public float velox, sensibilidade;

	private float vertRotation = 0.0f;
	private bool canMove = false;

	private void Start ( ) {
		StartCoroutine ( StartMoving ( ) );
	}

	private IEnumerator StartMoving ( ) {
		yield return new WaitForSeconds ( 1.0f );
		canMove = true;
	}

	private void FixedUpdate ( ) {
		// OBTENDO A DIREÇÃO EM QUE O PLAYER ESTÁ OLHANDO
		float rad = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;

		// TRAVANDO OU DESTRAVANDO O MOUSE NO CENTRO DA TELA COM A TECLA ESC
		if ( Input.GetKeyUp ( KeyCode.Escape ) && Cursor.lockState.Equals ( CursorLockMode.Confined ) )
			Cursor.lockState = CursorLockMode.None;
		else
		if ( Input.GetKeyUp ( KeyCode.Escape ) && Cursor.lockState.Equals ( CursorLockMode.None ) )
			Cursor.lockState = CursorLockMode.Confined;

		if ( !canMove ) return;

		if ( Input.GetKey ( KeyCode.W ) ) {
			Vector3 d = new Vector3 ( Mathf.Sin ( rad ), 0, Mathf.Cos ( rad ) );
			transform.position += d * velox;
		}

		if ( Input.GetKey ( KeyCode.S ) ) {
			Vector3 d = new Vector3 ( Mathf.Sin ( rad ), 0, Mathf.Cos ( rad ) );
			transform.position -= d * velox;
		}

		if ( Input.GetKey ( KeyCode.A ) ) {
			Vector3 d = new Vector3 ( Mathf.Sin ( rad - Mathf.PI / 2 ), 0, Mathf.Cos ( rad - Mathf.PI / 2 ) );
			transform.position += d * velox;
		}

		if ( Input.GetKey ( KeyCode.D ) ) {
			Vector3 d = new Vector3 ( Mathf.Sin ( rad - Mathf.PI / 2 ), 0, Mathf.Cos ( rad - Mathf.PI / 2 ) );
			transform.position -= d * velox;
		}

		OlharParaMouse ( );
	}

	void OlharParaMouse ( ) {

		float horizontal = Input.GetAxis ( "Mouse X" ) * sensibilidade;
		float vertical = Input.GetAxis ( "Mouse Y" ) * sensibilidade * -1;

		transform.rotation = Quaternion.Euler ( new Vector3 (
			transform.rotation.eulerAngles.x,
			transform.rotation.eulerAngles.y + horizontal,
			transform.rotation.eulerAngles.z
		) ); ;

		if ( vertRotation > 50 && vertical > 0 ) return;
		if ( vertRotation < -20 && vertical < 0 ) return;

		vertRotation += vertical;

		visao.transform.localRotation = Quaternion.Euler ( new Vector3 (
			vertRotation,
			0,
			0
		) );
	}

}
