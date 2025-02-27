using UnityEngine;
public class FinishLine : MonoBehaviour
{
    private void OiggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            SceneController.instance.NextScene();
        }
        
    }

}
