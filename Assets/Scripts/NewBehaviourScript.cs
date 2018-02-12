using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(MeshRenderer))]
public class NewBehaviourScript : MonoBehaviour
{
	private VideoPlayer _videoPlayer;
	private MeshRenderer _renderer;

	void Start()
	{
		this._videoPlayer = this.gameObject.AddComponent<VideoPlayer>();
		this._renderer = this.GetComponent<MeshRenderer>();
	}
	private void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			this._videoPlayer.source = VideoSource.Url;
			this._videoPlayer.url = "http://hoge_01.mp4";
			this._videoPlayer.prepareCompleted += this.PrepareCompleted;
			this._videoPlayer.Prepare();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			this._videoPlayer.source = VideoSource.Url;
			this._videoPlayer.url = "http://hoge_02.mp4";
			this._videoPlayer.prepareCompleted += this.PrepareCompleted;
			this._videoPlayer.Prepare();
		}
#elif UNITY_WEBGL
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			//	一度破棄してから再生をする
			if (this._videoPlayer) Destroy(this._videoPlayer);
			this._videoPlayer = this.gameObject.AddComponent<VideoPlayer>();
			this._videoPlayer.source = VideoSource.Url;
			this._videoPlayer.playOnAwake = false;
			this._videoPlayer.isLooping = false;
			this._videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
			this._videoPlayer.targetMaterialRenderer = this._renderer;
			this._videoPlayer.targetMaterialProperty = "_MainTex";

			this._videoPlayer.url = "http://hoge_01.mp4";
			this._videoPlayer.prepareCompleted += this.PrepareCompleted;
			this._videoPlayer.Prepare();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			//	一度破棄してから再生をする
			if (this._videoPlayer) Destroy(this._videoPlayer);
			this._videoPlayer = this.gameObject.AddComponent<VideoPlayer>();
			this._videoPlayer.source = VideoSource.Url;
			this._videoPlayer.playOnAwake = false;
			this._videoPlayer.isLooping = false;
			this._videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
			this._videoPlayer.targetMaterialRenderer = this._renderer;
			this._videoPlayer.targetMaterialProperty = "_MainTex";

			this._videoPlayer.url = "http://hoge_02.mp4";
			this._videoPlayer.prepareCompleted += this.PrepareCompleted;
			this._videoPlayer.Prepare();
		}
#endif

	}
	void PrepareCompleted(VideoPlayer vp)
	{
		vp.prepareCompleted -= PrepareCompleted;
		vp.Play();
	}
}