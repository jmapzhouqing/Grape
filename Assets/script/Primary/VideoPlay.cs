using UnityEngine;
using System.Collections;
using System;

using UnityEngine.UI;

public class VideoPlay : MonoBehaviour {
	private MovieTexture movTexture; 

	private Action callback;

	public RawImage image;

	public void Play(string fileName){
		StopAllCoroutines ();
		StartCoroutine (PlayVideo(fileName));
	}

	private IEnumerator PlayVideo(string fileName){
		movTexture = Resources.Load ("Vedios/" + fileName, typeof(MovieTexture)) as MovieTexture;

		image.texture = movTexture;

		if (movTexture != null) {
			while(!movTexture.isReadyToPlay){
				yield return new WaitForEndOfFrame();
			}

			movTexture.Play();

			while(movTexture.isPlaying){
				yield return new WaitForEndOfFrame();
			}
			movTexture.Pause();
			movTexture.Stop();
			movTexture = null;
			Resources.UnloadUnusedAssets ();
		}

		if (callback != null) {
			callback();
		}

		this.gameObject.SetActive (false);
	}

	public void SetCallback(Action action){
		this.callback = action;
	}
}
