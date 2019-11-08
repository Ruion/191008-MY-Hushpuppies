using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {

	public AudioClip JumpSound;
	public AudioClip CoinSound;
	public AudioClip ShoeSound;
	public List<AudioClip> DeadSoundList;
	AudioSource audioSourceComponent;
	AudioClip DeadSound;

	void Awake(){
		audioSourceComponent = GetComponent<AudioSource>();
	}

	public void PlayJumpSound(){
		audioSourceComponent.PlayOneShot(JumpSound,1f);
	}

	public void PlayCoinSound(){
		audioSourceComponent.PlayOneShot(CoinSound,1.1f);
	}

    public void PlayShoeSound()
    {
        audioSourceComponent.PlayOneShot(ShoeSound, 1.1f);
    }

    public void PlayDeadSound(){
		DeadSound = DeadSoundList[Random.Range(0,DeadSoundList.Count)];
		audioSourceComponent.PlayOneShot(DeadSound,1f);
	}

	public void StopDeadSound(){
		audioSourceComponent.Stop();
	}
}
