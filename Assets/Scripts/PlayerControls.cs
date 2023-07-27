using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float score = 0;
    public bool isCutting = false;
    private Animator animator;
    [SerializeField]
    private GameObject Scissors;
    public GameObject Camera;
    private bool canCut = true;
    public bool ItemExists = false;
    private AudioSource audiosource;
    public AudioClip scissorbgm;
    public AudioClip normalbgm;
    void Start()
    {
        
        score = 0;
        isCutting = false;
        Scissors.GetComponent<SpriteRenderer>().enabled = false;
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(normalbgm);
    }

    void Update()
    {
        if (isCutting == true && GameObject.Find("game teacher").GetComponent<Teacher>().looking == true)
        {
            audiosource.Pause();
            StartCoroutine("GameOver");
        }
        if (Input.GetKeyDown("z"))
        {
            StartCoroutine("ScissorCoroutine");
            audiosource.Stop();
            audiosource.PlayOneShot(scissorbgm);

        }
        if (Input.GetKeyUp("z"))
        {
            animator.SetTrigger("CuttingOver");
            isCutting = false;
            audiosource.Stop();
            audiosource.PlayOneShot(normalbgm);
        }
        if(Input.GetKeyDown("x") && isCutting == true && canCut == true && ItemExists == true)
        {
            StartCoroutine("CutItem");
        }
    }

    IEnumerator CutItem()
    {
        canCut = false;
        animator.SetTrigger("Cut");
        score += 100;
        Camera.GetComponent<Animator>().SetTrigger("Cut");
        GameObject.Find("LostItems").GetComponent<LostItemScript>().Cut();
        yield return new WaitForSeconds(0.5f);
        canCut = true;
    }
    IEnumerator ScissorCoroutine()
    {
        animator.SetTrigger("isCutting");
        yield return new WaitForSeconds(0.2f);
        isCutting = true;
        yield return new WaitForSeconds(0.8f);
        Scissors.GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator GameOver()
    {
        GameObject.Find("game boy").GetComponent<Animator>().enabled = false;
        GameObject.Find("game teacher").GetComponent<Teacher>().gameend();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }
}
