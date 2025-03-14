using UnityEngine;
using UnityEngine.SceneManagement;
public class Boundry : MonoBehaviour
{
        [SerializeField] private string newGameLevel = "";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            SceneManager.LoadScene(newGameLevel);
            
        }
        
    }

}
