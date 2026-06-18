using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Arraste o seu Player para cá no Inspector
    public Vector3 offset;   // Distância que a câmera vai manter da bola

    void Start()
    {
        // Calcula a distância inicial entre a câmera e a bola
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        // Acompanha a bola sem girar junto com ela
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}