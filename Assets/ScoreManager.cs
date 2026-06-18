using UnityEngine;
using TMPro; // Necessário para usar o texto do TextMeshPro

public class ScoreManager : MonoBehaviour
{
    // O 'instance' facilita o acesso de outros scripts
    public static ScoreManager instance;

    [Tooltip("Arraste o seu Texto da UI para cá")]
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        // Garante que só existe um ScoreManager
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        AtualizarTexto();
    }

    // Função que a sua Linha de Chegada vai chamar
    public void AdicionarPonto()
    {
        score++; // Adiciona 1 ao score
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}