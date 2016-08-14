using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class PlayMovie : MonoBehaviour {

    // Use this for initialization

    public MovieTexture movie;

	void Start () {
        GetComponent<Renderer>().material.mainTexture = movie as MovieTexture;
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
