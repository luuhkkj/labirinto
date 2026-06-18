using UnityEngine;
using UnityEngine.InputSystem; // Essencial para usar o Keyboard.current

public class BallController : MonoBehaviour
{
    public float speed = 15f;
    public Transform resetPoint; // Refer�ncia de onde a bola vai renascer
    private Rigidbody rb;

    void Start()
    {
        // Pega a refer�ncia do componente de f�sica
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate � o lugar correto para usar f�sica (AddForce) na Unity
    void FixedUpdate()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Captura as teclas pressionadas e inverte os eixos
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveZ = -1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveZ = 1f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveX = 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveX = -1f;
        }

        // Aplica a forca na bola para faz�-la rolar
        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized;
        rb.AddForce(movement * speed);
    }

    // Sistema de colisao com a zona final
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("FinishZone"))
        {
            // Teletransporta a bola para o ponto de reset
            transform.position = resetPoint.position;

            // Zera as for�as de movimento e rota��o para a bola n�o continuar rolando sozinha ao renascer
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}