using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Instruction Scene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void NewGameButton(){
        SceneManager.LoadScene(newGameLevel);
    }
}
