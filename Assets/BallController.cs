using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody rb;

    void Start()
    {
        // Pega a referência do componente de física
        rb = GetComponent<Rigidbody>();
    }

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

        // Aplica a força na bola para fazê-la rolar
        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized;
        rb.AddForce(movement * speed);
    }
}