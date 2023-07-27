using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostItemScript : MonoBehaviour
{
    private List<GameObject> CurrentItems = new List<GameObject>();
    public GameObject teddybear;
    public GameObject phone;
    public GameObject bottle;
    public GameObject slash;
    private List<Vector2> ItemLocation = new List<Vector2>();
    private List<GameObject> Items = new List<GameObject>();
    private AudioSource audio;
    void Start()
    {
        ItemLocation.Add(new Vector2(5.63f, -1.47f));
        ItemLocation.Add(new Vector2(6.87f, -1.45f));
        ItemLocation.Add(new Vector2(8.57f, -1.35f));
        ItemLocation.Add(new Vector2(5.61f, -2.67f));
        ItemLocation.Add(new Vector2(6.71f, -2.64f));
        ItemLocation.Add(new Vector2(7.91f, -2.65f));
        ItemLocation.Add(new Vector2(6.18f, -3.85f));
        ItemLocation.Add(new Vector2(7.8f, -3.79f));
        Items.Add(teddybear);
        Items.Add(phone);
        Items.Add(bottle);
        FillShelf();
        audio = GetComponent<AudioSource>();
    }

    public void Cut()
    {
        if (CurrentItems.Count > 0)
        {
            GameObject cutobject = CurrentItems[Random.Range(0, CurrentItems.Count)];
            CurrentItems.Remove(cutobject);
            StartCoroutine("CutCoroutine", cutobject);
            Destroy(cutobject);
            if (CurrentItems.Count == 0)
            {
                GameObject.Find("game boy").GetComponent<PlayerControls>().ItemExists = false;
                FillShelf();
            }
        }
    }

    IEnumerator CutCoroutine(GameObject cutobject)
    {
        GameObject SlashEffect = Instantiate(slash, cutobject.transform.position, Quaternion.identity);
        audio.Play();
        yield return new WaitForSeconds(1);
        Destroy(cutobject);
        Destroy(SlashEffect);
    }
    private void FillShelf()
    {
        StartCoroutine("FillCoroutine");
    }

    IEnumerator FillCoroutine()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 8; i++)
        {
            CurrentItems.Add(Instantiate(Items[Random.Range(0, Items.Count)], ItemLocation[i], Quaternion.identity));
        }
        GameObject.Find("game boy").GetComponent<PlayerControls>().ItemExists = true;
    }
}
