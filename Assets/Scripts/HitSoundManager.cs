using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundManager : MonoBehaviour {

    public AudioClip[] grunts;

    public void PlayGrunt()
    {
        int index = (int)Random.Range(0, grunts.Length);

        StartCoroutine(PlayClip(grunts[index]));
    }

    IEnumerator PlayClip(AudioClip clip)
    {
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();

        yield return new WaitForSeconds(clip.length);

        Destroy(source);
    }
}
