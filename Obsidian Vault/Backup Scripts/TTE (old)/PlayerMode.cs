using System.IO;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
    [SerializeField] Preferences pref;
    [SerializeField] MakerMode maker;
    string active_character;
    //string active_library;
    private void Start()
    {
        active_character = "";
        //active_library = "";

        //Edit Traits
        //Edit Backstory
        //Edit Goals
        //Get Traits
        //Get Backstory
        //Get Goals
    }
    public void Select_Character(string to_select)
    {
        string directory = Application.persistentDataPath + "/UserData/Characters/" + name + ".txt";
        if (File.Exists(directory))
        {
            active_character = directory;
        }
        else
        {
            Debug.Log("ERR: Attempting to select a character that doesn't exist");
        }
    }

}
