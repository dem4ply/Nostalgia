using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class cambioecenaaut : MonoBehaviour
{
    
	private VideoPlayer m_VideoPlayer;
	
	public string nivelACargar;
    public float retraso;

    void Awake () 
    {
        m_VideoPlayer = GetComponent<VideoPlayer>();
        m_VideoPlayer.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    void OnMovieFinished(VideoPlayer player)
    {
        CargarNivel();
    }
	
	[ContextMenu("Activar Carga")]
    public void ActivarCarga()
    {
        Invoke("CargarNivel", retraso);
    }

    void CargarNivel()
    {
        SceneManager.LoadScene(nivelACargar);
    }
    
}

