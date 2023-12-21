using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    // Referencia al componente de audio de la Main Camera
    private AudioSource audioSource;

    // Volumen deseado para la canción
    public float volumenDeseado = 0.5f;

    void Start()
    {
        // Obtén la referencia al componente AudioSource de la Main Camera
        audioSource = Camera.main.GetComponent<AudioSource>();

        // Ajusta el volumen al valor deseado
        if (audioSource != null)
        {
            audioSource.volume = volumenDeseado;
        }
        else
        {
            Debug.LogWarning("No se encontró el componente AudioSource en la Main Camera.");
        }
    }
}
