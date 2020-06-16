using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0, 100)]
    public float speed;
    public float sensibilidade;
    public int pontos;

    float mouseX;
    float mouseY;
    Rigidbody rb;

    public GameObject seeds;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtendo valor Vertical(Frente, trás, cima, baixo)
        float vertical = Input.GetAxis("Vertical") * (speed * Time.deltaTime);

        // Obtendo valor Horizontal(Esquerda e Direita)
        float horizontal = Input.GetAxis("Horizontal") * (speed * Time.deltaTime);

        // Aplicando velocidade ao ridigbody
        rb.velocity = transform.forward * vertical;
        
        mouseX += Input.GetAxis("Mouse X") * sensibilidade;
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

}