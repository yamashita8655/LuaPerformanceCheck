﻿/*
 * サウンドマネージャ
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// サウンドの管理を行う
/// AudioSourceが紐づいているオブジェクトを生成するが、音を鳴らすのは、外部からClipを渡してもらうようにする
/// </summary>
public class SoundManager : Singleton<SoundManager>
{
	private class SoundData {
		public bool IsPlaying;	// 再生中かどうか
		public AudioSource AudioSource; // 音を鳴らす本体
		public int LoopCount;	// 何回再生するか
		public int PlayedCount;	// 再生済みカウント数
		public SoundData(AudioSource audioSource) {
			IsPlaying = false;
			AudioSource = audioSource;
			LoopCount = 0;
			PlayedCount = 0;
		}
	}

	private List<SoundData> BGMSoundDataList = new List<SoundData>();
	private List<SoundData> SESoundDataList = new List<SoundData>();

	/// <summary>
	/// サウンドマネージャ初期化処理
	/// </summary>
	public void Initialize()	{
		DontDestroyOnLoad(this);
	}
	
	/// <summary>
	/// BGM用のAudioSourceの作成
	/// </summary>
	public void CreateBGMAudioSource(List<AudioClip> bgmClipList) {
		for (int i = 0; i < bgmClipList.Count; i++) {
			GameObject obj = new GameObject();
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.clip = bgmClipList[i];
			obj.transform.SetParent(this.transform);
			SoundData soundData = new SoundData(audioSource);
			BGMSoundDataList.Add(soundData);
		}
	}
	
	/// <summary>
	/// SE用のAudioSourceの作成
	/// </summary>
	public void CreateSEAudioSource(int sourceNum) {
		for (int i = 0; i < sourceNum; i++) {
			GameObject obj = new GameObject();
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			obj.transform.SetParent(this.transform);
			SoundData soundData = new SoundData(audioSource);
			SESoundDataList.Add(soundData);
		}
	}
	
	/// <summary>
	/// SEの再生
	/// </summary>
	public void PlaySE(AudioClip seClip, int loopCount = 1) {
		for (int i = 0; i < SESoundDataList.Count; i++) {
			if (SESoundDataList[i].IsPlaying == true) {
				continue;
			}
			SESoundDataList[i].AudioSource.clip = seClip;
			SESoundDataList[i].LoopCount = loopCount;
			SESoundDataList[i].PlayedCount = 0;
			SESoundDataList[i].AudioSource.Play();
			SESoundDataList[i].IsPlaying = true;
		}
	}


	public void Update() {
	}
}
