using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public static SceneNavigation instance = null;
    public GameObject[] popUps;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        print("Quiere Funcionar!!");
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("Funciona!!");
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PopUpActive(int index)
    {
        popUps[index].SetActive(true);
    }
    public void PopUpDisactive(int index)
    {
        popUps[index].SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangeScene(int s)
    {
        Time.timeScale = 1;
        Debug.Log("Cambio a la escena: " + s);
        if (s == 2)
        {
            StartCoroutine(LoadingScene(s));
        }
        else
        {
            StartCoroutine(CambioEscena(s));
        }
    }
    IEnumerator CambioEscena(int escena)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(escena);
    }
    IEnumerator LoadingScene(int escena)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(escena);
        popUps[0].SetActive(true);
        while (!asyncLoad.isDone)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
        }
    }
}
