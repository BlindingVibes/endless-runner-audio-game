using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    public string tutorial;

    public void Tutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

}
