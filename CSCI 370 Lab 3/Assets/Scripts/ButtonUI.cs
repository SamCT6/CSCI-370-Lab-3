using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonUI : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] private string newGameLevel = "Instruction Scene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void NewGameButton(){
        StartCoroutine(Loadlevel());
    }

    IEnumerator Loadlevel()
    {
        transition.SetTrigger("Fadeout");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(newGameLevel);
        transition.SetTrigger("Fadein");
    }
}
