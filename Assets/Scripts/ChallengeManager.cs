using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Script Challenge manager
/// Criado para armazenar blocos de informações (arrays) como áudios,perguntas e respostas;
/// Por: Leonardo Delafiori

public class ChallengeManager : MonoBehaviour {

    #region Declaring Variables
    [SerializeField] private AudioClip[] audio;
    private AudioSource audioSource;
    [SerializeField] private string[] perguntas;
    [SerializeField] private string[] respostasA;
    [SerializeField] private string[] respostasB;
    [SerializeField] private string[] respostasC;
    [SerializeField] private string[] respostasD;
    private int prevCounter = 0;
    #endregion

    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>(); //Setando o audio source
        StartCoroutine(WaitBeforeExplaining());
	}
	
	
	void Update () {
		
        
	}

    private void StartExplaining()
    {
        int counter = 0;
        /*while (counter == prevCounter)
        {
            counter = Random.Range(0, audio.Length); //Pequena verificacao pra nao deixar duas explicacoes serem iguais
        }*/
        //prevCounter = counter;

        // Integrating the audio and playing it
        audioSource.clip = audio[counter];
        audioSource.Play();
    }

    IEnumerator WaitBeforeExplaining()
    {
        yield return new WaitForSeconds(Random.Range(0, 7));
        StartExplaining();
    }
}
