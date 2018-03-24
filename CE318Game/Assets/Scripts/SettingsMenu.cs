using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour {
	public AudioMixer mixer;

	Resolution[] resolutions;
	public Dropdown ddr;
	public void SetVolume(float volume){
		mixer.SetFloat ("volume", volume);
	}
	public void SetQuality(int qualityIndex){
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	public void SetFullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}

	public void SetResolution(int resolutionIndex){
		Resolution r = resolutions [resolutionIndex];
		Screen.SetResolution (r.width, r.height, Screen.fullScreen);
	}

	// Use this for initialization
	void Start () {
		resolutions = Screen.resolutions;
		ddr.ClearOptions ();
		int cri = 0;
		List<string> list = new List<string> ();
		for (int i = 0; i < resolutions.Length; i++) {
			list.Add (resolutions[i].width + " x " + resolutions[i].height);
			if (resolutions [i].width == Screen.currentResolution.width &&
				resolutions [i].height == Screen.currentResolution.height) {
				cri = i;
			}
		}
		ddr.AddOptions (list);
		ddr.value = cri;
		ddr.RefreshShownValue ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
