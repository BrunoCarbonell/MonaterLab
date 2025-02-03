using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Part { HEAD, TORSO, LEGS}
public class PartsController : MonoBehaviour
{

    public GameObject partMenu;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            partMenu.SetActive(true);
            partMenu.GetComponentInParent<Image>().enabled = true;
            if (partMenu.GetComponent<PartsManager>())
                partMenu.GetComponent<PartsManager>().Open();
        }
    }
}
