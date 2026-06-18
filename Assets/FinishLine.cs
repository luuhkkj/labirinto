using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [Tooltip("Arraste o objeto do Respawn/Início para cá no Inspector")]
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem bateu na linha de chegada foi o Player
        if (other.CompareTag("Player"))
        {
            // 1. Manda o ScoreManager adicionar 1 ponto na tela
            ScoreManager.instance.AdicionarPonto();

            // 2. Aviso no Console só para você saber que funcionou
            Debug.Log("Ponto marcado!");

            // 3. Teleporta o jogador de volta para o início
            if (respawnPoint != null)
            {
                other.transform.position = respawnPoint.position;
            }
        }
    }
}