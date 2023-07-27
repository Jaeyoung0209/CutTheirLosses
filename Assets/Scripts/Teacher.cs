using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teacher : MonoBehaviour
{
    private Animator animator;
    public bool looking = false;
    public AudioSource audiosource;
    public AudioClip key;
    public AudioClip think;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("LookCoroutine");
    }

    public void gameend()
    {
        animator.SetTrigger("End");
    }
    IEnumerator LookCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(7, 14));
        animator.SetTrigger("Look");
        yield return new WaitForSeconds(2.84f);
        looking = true;
        yield return new WaitForSeconds(2.16f);
        looking = false;
        StartCoroutine("LookCoroutine");
    }

    void PlayKeySound()
    {
        audiosource.PlayOneShot(key);
    }

    void PlayThinkSound()
    {
        audiosource.PlayOneShot(think);
    }
}
