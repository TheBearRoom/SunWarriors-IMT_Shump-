using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    //Private variable to reference to the animator
    private Animator anim;
    void Start()
    {
        //Used to find animator component that is added to button
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void StartAnim()
    {
        anim.SetTrigger("Active");
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("Main Game");
    }
}
