using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    AudioSource myaudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
            Sounds();
    }

    void Sounds()
    {
        AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        myaudioSource.PlayOneShot(clip);
    }
}
