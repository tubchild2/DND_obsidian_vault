using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class DataManager : MonoBehaviour
{
    private string dbPath;
    private string libPath;
    private string prefPath;

    private float default_sfx_volume = 0.66f;
    private float default_music_volume = 0.66f;
    private string default_username = "Default User";
    private Preferences default_preferences;


    private void Awake()
    {
        default_preferences = new Preferences(default_music_volume, default_sfx_volume, default_username);
        RepairDirectories();

        Feature f = new Feature(
            "Test Feature",
            "Description",
            true,
            1,
            0,
            new CoreStatAmt[] { new CoreStatAmt(CoreStat.STR, 0), new CoreStatAmt(CoreStat.WIS, 1) },
            new SkillAmt[] { new SkillAmt(0, 0) },
            new DerivedStatAmt[] { new DerivedStatAmt(DerivedStat.ERR, 0) },
            new ItemAmt[] { new ItemAmt(0, 0) },
            new CoreStatAmt[] { new CoreStatAmt(CoreStat.ERR, 0) },
            new SkillAmt[] { new SkillAmt(0, 0) },
            new DerivedStatAmt[] { new DerivedStatAmt(DerivedStat.ERR, 0) },
            new ItemAmt[] { new ItemAmt(0, 0) });

        Debug.Log(f.required_stats()[0].stat());
    }

    // DIRECTORY MANAGEMENT
    public void RepairDirectories()
    {
        dbPath = Application.persistentDataPath + "/UserData";
        libPath = dbPath + "/Libraries";
        prefPath = dbPath + "/Preferences.json";

        if (!Directory.Exists(dbPath)) Directory.CreateDirectory(dbPath);
        if (!Directory.Exists(libPath)) Directory.CreateDirectory(libPath);
        if (!File.Exists(prefPath))
        {
            File.Create(prefPath);
            SetPreferences(default_preferences);
        }
    }


    // PREFERENCES
    public void SetPreferences(Preferences pref)
    {
        string json_text = JsonUtility.ToJson(pref);
        File.WriteAllText(prefPath, json_text);
    }
    public Preferences GetPreferences()
    {
        string file_text = File.ReadAllText(prefPath);
        Preferences pref = JsonUtility.FromJson<Preferences>(file_text);

        if (pref == null || pref.username() == "")
        {
            debug.error("Error: Incapable of reading data from preferences file.");
            RepairDirectories();
            SetPreferences(default_preferences);
            return default_preferences;
        }
        return pref;
    }
}
