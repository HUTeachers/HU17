using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Respawn : MonoBehaviour 
{
    //Denne variabel holder positionen som spilleren bliver respawnet til.
    private Vector2 lastCheckpoint;


    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {

    }

    //Denne metode bliver kaldt i Checkpoint.cs
    //Set respawn positionen til position
    public void SetCheckpoint(Vector3 position)
    {
        //Set respawn positionen til position
        lastCheckpoint = position;
    }

    //Denne metode sætter spilleren tilbage. Her skal ting som health sættes tilbage til max også.
    //Den skal kaldes fra det som dræber spilleren
    public void RespawnPlayer()
    {
        //Set spillerens position til det nyeste checkpoint
        transform.position = lastCheckpoint;
    }

    //Denne metode genstarter scenen
    //Den skal kaldes fra det som dræber spilleren
    public void Restart()
    {
        //Finder index for den nuværende scene
        int index = SceneManager.GetActiveScene().buildIndex;

        //Loader scenen med nummeret som index angiver (den nuværende scene).
        SceneManager.LoadScene(index);
    }
}
