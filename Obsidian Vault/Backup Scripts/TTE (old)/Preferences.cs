using System.IO;
using System.Linq;
using UnityEngine;

public class Preferences : MonoBehaviour
{
    private string PreferencesDirectory;
    public string howto;

    private void Awake()
    {
        PreferencesDirectory = Application.persistentDataPath + "/UserData/Preferences.txt";
        RepairUserDataDirectory();
        EditMusic(GetMusic());
        howto = File.ReadAllText(Path.Combine(new[] { Application.streamingAssetsPath, "howto.txt" }));
    }

    //GENERAL USE
    public void ResetPreferences()
    {
        File.WriteAllText(PreferencesDirectory, " " +
            "PREFERENCES" +
            "\nUser:New User" +
            "\nSFX:0.8" +
            "\nMusic:0.8");
    }
    public void RepairUserDataDirectory()
    {
        string UserDataDirectory = Application.persistentDataPath + "/UserData";
        if (!Directory.Exists(UserDataDirectory))
        {
            Directory.CreateDirectory(UserDataDirectory);
        }
        if (!Directory.Exists(UserDataDirectory + "/Characters"))
        {
            Directory.CreateDirectory(UserDataDirectory + "/Characters");
        }
        if (!Directory.Exists(UserDataDirectory + "/Libraries"))
        {
            Directory.CreateDirectory(UserDataDirectory + "/Libraries");
        }
        if (!File.Exists(Path.Combine(new[] { Application.streamingAssetsPath, "howto.txt" })))
        {
            Debug.Log("cant find howto!");
            return;
        }
    }
    public void EditUsername(string username)
    {
        if (!File.Exists(PreferencesDirectory)) ResetPreferences();
        string[] lines = File.ReadAllLines(PreferencesDirectory);
        lines[1] = "User:" + username;
        File.WriteAllLines(PreferencesDirectory, lines);
    }
    public string GetUsername()
    {
        if (!File.Exists(PreferencesDirectory)) ResetPreferences();
        string[] lines = File.ReadAllLines(PreferencesDirectory);
        string username = lines[1].Substring(5);
        return username;
    }
    public void EditSFX(float vol)
    {
        if (vol > 10) vol = 10;
        if (vol < 0) vol = 0;
        if (!File.Exists(PreferencesDirectory)) ResetPreferences();
        string[] lines = File.ReadAllLines(PreferencesDirectory);
        lines[2] = "SFX:" + vol;
        File.WriteAllLines(PreferencesDirectory, lines);
    }
    public float GetSFX()
    {
        if (!File.Exists(PreferencesDirectory)) ResetPreferences();
        string[] lines = File.ReadAllLines(PreferencesDirectory);
        string sfx_text = lines[2].Substring(4);
        float vol;
        if (!float.TryParse(sfx_text, out vol)) { vol = 0.8f; }
        return vol;
    }
    public void EditMusic(float vol)
    {
        if (vol > 10) vol = 10;
        if (vol < 0) vol = 0;
        if (!File.Exists(PreferencesDirectory)) ResetPreferences();
        string[] lines = File.ReadAllLines(PreferencesDirectory);
        lines[3] = "Music:" + vol;
        File.WriteAllLines(PreferencesDirectory, lines);

        Camera.main.GetComponent<AudioSource>().volume = vol;
    }
    public float GetMusic()
    {
        if (!File.Exists(PreferencesDirectory)) ResetPreferences();
        string[] lines = File.ReadAllLines(PreferencesDirectory);
        string sfx_text = lines[3].Substring(6);
        float vol;
        if (!float.TryParse(sfx_text, out vol)) { vol = 5; }
        return vol;
    }



    //LIBRARY FILES
    public bool CreateLibrary(string name, string description)
    {
        string LibraryDirectory = Application.persistentDataPath + "/UserData/Libraries/" + name + ".txt";

        char[] nonos = new char[]
        {
                ':', '/', '\\', '*', '?', '"', '<', '>', '|', '.', '!',
                '\0',
                '\t', '\n', '\r'
        };

        foreach (char nono in nonos)
        {
            if (name.Contains(nono))
            {
                Debug.Log("ERR: Cannot contain special characters");
                return false;
            }
        }

        if (!File.Exists(LibraryDirectory))
        {
            File.WriteAllText(LibraryDirectory,
                "# LIBRARY INFORMATION" +
                "\nUser:" + GetUsername() +
                "\nDate:" + System.DateTime.Now +
                "\nName:" + name +
                "\nDescription:" + description +
                "\n#SKILLS" +
                "\n#PROPERTIES" +
                "\n#FEATURES" +
                "\n#BACKGROUNDS" +
                "\n#SPECIES" +
                "\n#CLASSES" +
                "\n#ITEMS" +
                "\n#CONDITIONS" +
                "");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void DeleteLibrary(string name)
    {
        string LibraryDir = Application.persistentDataPath + "/UserData/Libraries/" + name + ".txt";
        if (File.Exists(LibraryDir))
        {
            File.Delete(LibraryDir);
        }
    }
    public string[] GetAllLibraries()
    {
        string path = Path.Combine(Application.persistentDataPath, "UserData/Libraries");
        string[] files = Directory.GetFiles(path);
        string[] libraries = new string[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            libraries[i] = Path.GetFileName(files[i]);
            int index = libraries[i].IndexOf('.');
            libraries[i] = libraries[i].Substring(0, index);
        }

        return libraries;
    }



    //CHARACTER FILES
    public bool CreateCharacter(string name)
    {
        char[] nonos = new char[]
        {
                ':', '/', '\\', '*', '?', '"', '<', '>', '|', // Windows forbidden
                '\0', // null character — invalid in all systems
                '\t', '\n', '\r' // control characters — problematic in filenames   
        };
        foreach (char nono in nonos)
        {
            if (name.Contains(nono))
            {
                Debug.Log("ERR: Cannot contain special characters");
                return false;
            }
        }

        string CharacterDirectory = Application.persistentDataPath + "/UserData/Characters/" + name + ".txt";
        if (!File.Exists(CharacterDirectory))
        {
            File.WriteAllText(CharacterDirectory, "" +
                "# INFORMATION" +
                "\nUser:" + GetUsername() +
                "\nDate:" + System.DateTime.Now +
                "\n\n# PERSONALITY" +
                "\nName:" + name +
                "\nTraits:" +
                "\nBackstory:" +
                "\nGoals:" +
                "\n\n# ATTRIBUTES" +
                "\nBackground:" +
                "\nSpecies:" +
                "\nClass:" +
                "\nLevel:" +
                "\n\n# CORE STATS" +
                "\nSTR:" +
                "\nDEX:" +
                "\nCON:" +
                "\nINT:" +
                "\nWIS:" +
                "\nCHA:" +
                "\n\n# OTHER STATS" +
                "\nSpeed:" +
                "\nDefense:" +
                "\nMax Health:" +
                "\nCurrent Health:" +
                "\n\n# Skill Levels" +
                "\n\n# Item Skill Levels" +
                "\n\n# Features" +
                "\n\n# Inventory");

            return true;
        }
        else
        {
            return false;
        }
    }
    public void DeleteCharacter(string name)
    {
        string CharacterDirectory = Application.persistentDataPath + "/UserData/Characters/" + name + ".txt";
        if (File.Exists(CharacterDirectory))
        {
            File.Delete(CharacterDirectory);
        }
    }



    //HOW TO FILES
    public string get_section(string section_name)
    {
        string[] sections = howto.Split('@');
        foreach (string section in sections)
        {
            if (section.TrimStart().StartsWith(section_name)) return section;
        }
        return "";
    }
    public string get_header(string section_name, string header_name)
    {
        string section = get_section(section_name);
        if (string.IsNullOrEmpty(section)) return "";
        string[] headers = section.Split('$').Skip(1).ToArray();
        foreach (string header in headers)
        {
            if (header.TrimStart().StartsWith(header_name)) return header;
        }
        return "";
    }
    public string get_paragraph(string section_name, string header_name, int paragraph_num)
    {
        string header = get_header(section_name, header_name);
        if (string.IsNullOrEmpty(header)) return "";
        string[] paragraphs = header.Split('^').Skip(1).ToArray();
        if (paragraph_num >= 0) return paragraphs[paragraph_num];
        return "";

    }

}