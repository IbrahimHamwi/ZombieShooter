using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFX : MonoBehaviour
{
    // called everytime when gameobject is activated
    void OnEnable()
    {
        Invoke("DeactivateGameObject", 2f);
    }


    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
