using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuOnClick : MonoBehaviour {

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("menuScene");
    }
}
