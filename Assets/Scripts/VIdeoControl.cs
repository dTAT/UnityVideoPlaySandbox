using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent (typeof (VideoPlayer))]
public class VIdeoControl : MonoBehaviour {
	VideoPlayer videoPlayer;
	[SerializeField]
	string videoUrl1;
	[SerializeField]
	string videoUrl2;
	[SerializeField]
	UnityEngine.UI.Text testStatus;
	private void Awake () {
		videoPlayer = GetComponent<VideoPlayer> ();
		InitializeVideoPlayer (videoPlayer);
	}
	private void InitializeVideoPlayer (VideoPlayer player) {
		//player.Pause ();
		//player.Stop ();
		player.time = 0;
		player.timeSource = VideoTimeSource.GameTimeSource;
		player.frame = 0;
		player.audioOutputMode = VideoAudioOutputMode.None;
		player.playOnAwake = false;
		player.source = VideoSource.Url;
		player.waitForFirstFrame = false;
		player.isLooping = false;
		player.aspectRatio = VideoAspectRatio.NoScaling;
		player.playbackSpeed = 1.0f;
		player.clip = null;
		player.skipOnDrop = true;
	}
	public void PlayMovie1 () {
		PlayMovie (videoPlayer, videoUrl1);
	}
	public void PlayMovie2 () {
		PlayMovie (videoPlayer, videoUrl2);
	}
	private void PlayMovie (VideoPlayer player, string url) {
		Stop (player);
		InitializeVideoPlayer (player);
		player.url = url;
		testStatus.text = "prepare...";
		player.Prepare ();
		player.prepareCompleted += Play;
	}
	private void Play (VideoPlayer player) {
		testStatus.text = "playing";
		player.Play ();
		player.prepareCompleted -= Play;
	}
	public void Stop (VideoPlayer player) {
		//player.Stop ();
		//player.url = string.Empty;
		InitializeVideoPlayer (player);
	}
}