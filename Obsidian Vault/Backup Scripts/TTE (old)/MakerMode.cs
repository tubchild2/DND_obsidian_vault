using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Unity.VisualScripting;
using UnityEngine;

public class MakerMode : MonoBehaviour
{
    [SerializeField] Preferences pref;
    string active_directory;



    //UNITY FUNCTIONS
    private void Start() 
    { 
        active_directory = "";

        pref.DeleteLibrary("FS");
        pref.CreateLibrary("FS", "For Science");
        SelectLibrary("FS");
        Add_Null_Options();
        Add_Default_Skills();
    }



    //SELECTION
    public void SelectLibrary(string name)
    {
        string directory = UnityEngine.Application.persistentDataPath + "/UserData/Libraries/" + name + ".txt";
        if (File.Exists(directory))
        {
            active_directory = directory;
        }
        else
        {
            Debug.Log("ERR: Attempting to select a library that doesn't exist");
        }
    }
    public string GetSelectedLibrary()
    {
        if (active_directory != "" && File.Exists(active_directory))
        {
            string name_with_txt = Path.GetFileName(active_directory);
            int index = name_with_txt.IndexOf('.');
            return name_with_txt.Substring(0, index);
        }
        else
        {
            return "ERR: No directory selected";
        }
    }
    public string GetSelectedLibraryDirectory()
    {
        if (active_directory != "" && File.Exists(active_directory))
        {
            return active_directory;
        }
        else
        {
            return "ERR: No directory selected";
        }
    }



    //LIBRARY PREFERENCES
    public void Update_Desc(string description)
    {
        if (!File.Exists(active_directory))
        {
            return;
        }
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("Description:"))
            {
                lines[i] = "Description:" + description;
                File.WriteAllLines(active_directory, lines);
            }
        }
    }
    public void Update_Name(string name)
    {
        if (!File.Exists(active_directory))
        {
            Debug.Log("ERR: No library selected for name to be edited");
            return;
        }

        if (name.ToUpper() == GetSelectedLibrary().ToUpper())
        {
            Debug.Log("ERR: Same Name");
            return;
        }
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("Name:"))
            {
                lines[i] = "Name:" + name;
                File.WriteAllLines(active_directory, lines);
                string newpath = UnityEngine.Application.persistentDataPath + "/UserData/Libraries/" + name + ".txt";
                File.Move(active_directory, newpath);
                File.Delete(active_directory);
                SelectLibrary(name);
            }
        }
    }
    public void Update_Username()
    {
        if (!File.Exists(active_directory))
        {
            return;
        }
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("User:"))
            {
                lines[i] = "User:" + pref.GetUsername();
                File.WriteAllLines(active_directory, lines);
            }
        }
    }
    public void Update_Date()
    {
        if (!File.Exists(active_directory))
        {
            return;
        }
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("Date:"))
            {
                lines[i] = "Date:" + System.DateTime.Now;
                File.WriteAllLines(active_directory, lines);
            }
        }
    }
    public string Get_Description()
    {
        string description = "ERROR";

        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("Description:"))
            {
                description = lines[i].Substring(lines[i].IndexOf(':') + 1);
            }
        }

        return description;
    }
    public string Get_Name()
    {
        string name = "ERROR";

        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("Name:"))
            {
                name = lines[i].Substring(lines[i].IndexOf(':') + 1);
            }
        }

        return name;
    }



    //DEFAULTING
    public void Add_Default_Skills()
    {
        Add_Skill(new Skill("Athletics", "Jump farther, stay afloat in rough water, break something.", new[] { "STR" }));
        Add_Skill(new Skill("Endurance", "Resist poison, resist exhaustion, power through a hot room.", new[] { "CON" }));
        Add_Skill(new Skill("Acrobatics", "Stay on your feet or perform an acrobatic stunt.", new[] { "DEX" }));
        Add_Skill(new Skill("Sleight of Hand", "Pick a pocket, conceal an object, swap items, etc.", new[] { "DEX" }));
        Add_Skill(new Skill("Stealth", "Escape notice by moving quietly and hiding.", new[] { "DEX" }));
        Add_Skill(new Skill("Deception", "Tell a convincing lie or wear a convincing disguise.", new[] { "CHA" }));
        Add_Skill(new Skill("Intimidation", "Awe or threaten someone into doing what you want.", new[] { "CHA" }));
        Add_Skill(new Skill("Performance", "Act, tell a story, perform music, or dance.", new[] { "CHA" }));
        Add_Skill(new Skill("Persuasion", "Honestly and graciously convince someone of something.", new[] { "CHA" }));
        Add_Skill(new Skill("Insight", "Discern a person’s mood or intentions.", new[] { "WIS" }));
        Add_Skill(new Skill("Perception", "Notice something that’s easy to miss.", new[] { "WIS" }));
        Add_Skill(new Skill("Investigation", "Find obscure information in books, deduce something.", new[] { "WIS" }));
        Add_Skill(new Skill("History", "Recall lore about historical events, people, nations, etc.", new[] { "INT" }));
        Add_Skill(new Skill("Medicine", "Recall information about disease, death, health, and medicine.", new[] { "INT" }));
        Add_Skill(new Skill("Engineering", "Recall information about using / making machines (if any).", new[] { "INT" }));
        Add_Skill(new Skill("Arcana", "Recall information about your world’s unnatural elements (if any).", new[] { "INT" }));
        Add_Skill(new Skill("Art", "Recall information about art, or about creating art.", new[] { "INT" }));
        Add_Skill(new Skill("Nature", "Recall information about nature, farming, or survival.", new[] { "INT" }));
    }
    public void Add_Null_Options()
    {
        Add_Skill(new Skill("N/A", "N/A", new[] { "STR" }));
        Add_Property(new Property("N/A", "N/A"));
        Add_Feature(new Feature("N/A", "N/A"));
        Add_Condition(new Condition("N/A", "N/A", "N/A"));
        Add_Item(new Item("N/A", "N/A", new[] { "N/A" }, 0, false, "0", 0, false, "0", false, false, new[] { "N/A" }, 0, false, "N/A", new[] { "STR" }, new[] {"N/A"}));
        Add_Background(new Background("N/A", "N/A", new[] {"N/A"}, new[] {"STR"}, new[] {"N/A"}, new[] {"N/A"}, new[] {0f}));
        Add_Species(new Species("N/A", "N/A", 0, 0, new[] {"STR"}, new[] {"N/A"}, new[] {"N/A"}, new[] {"N/A"}, new[] {0f}));
        Add_Class(new Class("N/A", "N/A", 0, new[] {"STR"}, new[] {"N/A"}, new[] {"N/A"}, new[] {"N/A"}, new[] { 0f }));
    }


    //REMOVING
    public void Remove(string section, string name)
    {
        if (name == "N/A" ||
            name == "ERR" ||
            name == "Athletics" ||
            name == "Endurance" ||
            name == "Acrobatics" ||
            name == "Sleight of Hand" ||
            name == "Stealth" ||
            name == "Deception" ||
            name == "Intimidation" ||
            name == "Performance" ||
            name == "Persuasion" ||
            name == "Insight" ||
            name == "Perception" ||
            name == "Investigation" ||
            name == "History" ||
            name == "Medicine" ||
            name == "Engineering" ||
            name == "Arcana" ||
            name == "Art" ||
            name == "Animal Handling" ||
            name == "Nature")
        {
            return;
        }

        section = section.ToUpper();
        bool in_section = false;
        List<string> lines = File.ReadAllLines(active_directory).ToList();
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("#" + section)) in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + name + "`"))
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
        }
        File.WriteAllLines(active_directory, lines);
        if (section == "ITEMS")
        {
            Remove("SKILLS", "item." + name);
        }
    }



    //COPYING AND MOVING CONTENT
    public void CopyTo(string from, string to)
    {
        SelectLibrary(from);
        Skill[] allSkills = Get_All_Skills();
        Property[] allProperties = Get_All_Properties();
        Feature[] allFeatures = Get_All_Features();
        Condition[] allConditions = Get_All_Conditions();
        Background[] allBackgrounds = Get_All_Backgrounds();
        Species[] allSpecies = Get_All_Species();
        Class[] allClasses = Get_All_Classes();
        Item[] allItems = Get_All_Items();

        SelectLibrary(to);
        foreach (Skill s in allSkills) Add_Skill(s);
        foreach (Property p in allProperties) Add_Property(p);
        foreach (Feature f in allFeatures) Add_Feature(f);
        foreach (Condition co in allConditions) Add_Condition(co);
        foreach (Background b in allBackgrounds) Add_Background(b);
        foreach (Species sp in allSpecies) Add_Species(sp);
        foreach (Class cl in allClasses) Add_Class(cl);
        foreach (Item i in allItems) Add_Item(i);
    }



    //CONVERSION
    public float ConvertCurrency(float amt, string from, string to)
    {
        List<Item> currencies = Get_Currencies().ToList();
        Item c1 = Get_Item("N/A");
        Item c2 = Get_Item("N/A");

        foreach (Item i in currencies) {
            if (i.name == from) {
                c1 = i;
            }
            if (i.name == to) {
                c2 = i;
            }
        }

        if (c1.name == "N/A" || c2.name == "N/A") return 0;
        if (c1.name == "ERR" || c1.value == 0) return 0;
        if (c2.name == "ERR" || c2.value == 0) return 0;

        float amt_c2 = amt * (c1.value / c2.value);
        return amt_c2;
    }



    //ADD
    public void Add_Skill(Skill new_skill)
    {
        string[] valid_stats = new[] { "STR", "DEX", "CON", "WIS", "INT", "CHA" };
        foreach (string stat in new_skill.use_stats)
        {
            if (!valid_stats.Contains(stat))
            {
                Debug.Log("ERR: Attempted use of invalid stat");
                return;
            }
        }

        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#SKILLS") in_section = true;
            if (in_section)
            {
                if(lines[i].StartsWith("-" + new_skill.name + "`"))
                {
                    Debug.Log("ERR: Skill already exists");
                    return;
                }
            }
            if (lines[i] == "#PROPERTIES")
            {
                lines[i - 1] += "\n-" + new_skill.name + "`{" + string.Join("||", new_skill.use_stats) + "}`" + new_skill.function;
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Property(Property new_property)
    {
        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#PROPERTIES") in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + new_property.name + "`"))
                {
                    Debug.Log("ERR: Property already exists");
                    return;
                }
            }
            if (lines[i] == "#FEATURES")
            {
                lines[i - 1] += "\n-" + new_property.name + '`' + new_property.function;
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Feature(Feature new_feature)
    {
        // Valid Stats
        string[] valid_stats = { "STR", "DEX", "CON", "WIS", "INT", "CHA" };
        List<string> stats = new List<string>();
        stats.AddRange(new_feature.add_stats ?? Array.Empty<string>());
        stats.AddRange(new_feature.req_stats ?? Array.Empty<string>());
        foreach (string stat in stats) {
            if (!valid_stats.Contains(stat)) {
                Debug.Log("ERR: Attempted Use of Invalid Stat");
                return;
            }
        }

        // Valid Skills
        string[] viable_skills = Get_Section("SKILLS");
        List<string> skills = new List<string>();
        skills.AddRange(new_feature.add_skills ?? Array.Empty<string>());
        skills.AddRange(new_feature.req_skills ?? Array.Empty<string>());
        foreach (string skill in skills) {
            if (!viable_skills.Contains(skill)) {
                Debug.Log("ERR: Attempted Use of Invalid Skill");
                return;
            }
        }

        // Valid Items
        string[] viable_items = Get_Section("ITEMS");
        List<string> items = new List<string>();
        items.AddRange(new_feature.add_items ?? Array.Empty<string>());
        items.AddRange(new_feature.req_items ?? Array.Empty<string>());
        foreach (string item in items) {
            if (!viable_items.Contains(item)) {
                Debug.Log("ERR: Attempted Use of Invalid Item");
                return;
            }
        }

        // Finding Space For and Adding Feature
        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#FEATURES") in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + new_feature.name + "`"))
                {
                    Debug.Log("ERR: Feature already exists");
                    return;
                }
            }
            if (lines[i] == "#BACKGROUNDS")
            {
                string req_stat_list = "STR";
                string req_stat_amt_list = "0";
                if (new_feature.req_stats != null)
                {
                    req_stat_list = string.Join("||", new_feature.req_stats);
                    req_stat_amt_list = string.Join("||", new_feature.req_stats_amt);
                }

                string req_skill_list = "N/A";
                string req_skill_amt_list = "0";
                if (new_feature.req_skills != null)
                {
                    req_skill_list = string.Join("||", new_feature.req_skills);
                    req_skill_amt_list = string.Join("||", new_feature.req_skills_amt);
                }

                string req_item_list = "N/A";
                string req_item_amt_list = "0";
                if (new_feature.req_items != null)
                {
                    req_item_list = string.Join("||", new_feature.req_items);
                    req_item_amt_list = string.Join("||", new_feature.req_items_amt);
                }

                string add_stat_list = "STR";
                string add_stat_amt_list = "0";
                if (new_feature.add_stats != null)
                {
                    add_stat_list = string.Join("||", new_feature.add_stats);
                    add_stat_amt_list = string.Join("||", new_feature.add_stats_amt);
                }

                string add_skill_list = "N/A";
                string add_skill_amt_list = "0";
                if (new_feature.add_skills != null)
                {
                    add_skill_list = string.Join("||", new_feature.add_skills);
                    add_skill_amt_list = string.Join("||", new_feature.add_skills_amt);
                }

                string add_item_list = "N/A";
                string add_item_amt_list = "0";
                if (new_feature.add_items != null)
                {
                    add_item_list = string.Join("||", new_feature.add_items);
                    add_item_amt_list = string.Join("||", new_feature.add_items_amt);
                }

                lines[i - 1] +=
                    "\n-" + new_feature.name +
                    "`" + new_feature.description +
                    "`" + new_feature.player_accessible.ToString() +
                    "`" + new_feature.repeat_lim.ToString() +
                    "`" + new_feature.repeat_per_levels.ToString() +
                    "`{" + req_stat_list + "}" +
                    "`{" + req_stat_amt_list + "}" +
                    "`{" + req_skill_list + "}" +
                    "`{" + req_skill_amt_list + "}" +
                    "`{" + req_item_list + "}" +
                    "`{" + req_item_amt_list + "}" +
                    "`" + new_feature.req_speed.ToString() + 
                    "`" + new_feature.req_hp.ToString() +
                    "`" + new_feature.req_def.ToString() + 
                    "`" + new_feature.req_lvl.ToString() +
                    "`" + new_feature.function +
                    "`{" + add_stat_list + "}" +
                    "`{" + add_stat_amt_list + "}" +
                    "`{" + add_skill_list + "}" +
                    "`{" + add_skill_amt_list + "}" +
                    "`{" + add_item_list + "}" +
                    "`{" + add_item_amt_list + "}" +
                    "`" + new_feature.add_speed.ToString() +
                    "`" + new_feature.add_hp.ToString() +
                    "`" + new_feature.add_defense.ToString() +
                    "`" + new_feature.add_lvl.ToString();

                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Condition(Condition new_condition)
    {
        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#CONDITIONS") in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + new_condition.name + "`"))
                {
                    Debug.Log("ERR: Condition already exists");
                    return;
                }
            }
            if (i == lines.Count() - 1)
            {
                lines[i] +=
                    "\n-" + new_condition.name +
                    "`" + new_condition.trigger +
                    "`" + new_condition.function;
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Background(Background new_background)
    {
        string[] valid_stats = new[] { "STR", "DEX", "CON", "WIS", "INT", "CHA" };
        foreach (string stat in new_background.stat_boost_options)
        {
            if (!valid_stats.Contains(stat))
            {
                Debug.Log("ERR: Attempted Use of Invalid Stat");
                return;
            }
        }

        string[] viable_skills = Get_Section("SKILLS");
        for (int i = 0; i < new_background.skill_boosts.Count(); i++)
        {
            if (!viable_skills.Contains(new_background.skill_boosts[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Skill");
                return;
            }
        }

        string[] viable_features = Get_Section("FEATURES");
        for (int i = 0; i < new_background.features.Count(); i++)
        {
            if (!viable_features.Contains(new_background.features[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Feature");
                return;
            }
        }

        string[] viable_items = Get_Section("ITEMS");
        for (int i = 0; i < new_background.items.Count(); i++)
        {
            if (!viable_items.Contains(new_background.items[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Item");
                return;
            }
        }

        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#BACKGROUNDS") in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + new_background.name + "`"))
                {
                    Debug.Log("ERR: Background already exists");
                    return;
                }
            }
            if (lines[i] == "#SPECIES")
            {
                string stat_list = string.Join("||", new_background.stat_boost_options);
                string skill_list = string.Join("||", new_background.skill_boosts);
                string feature_list = string.Join("||", new_background.features);
                string item_list = string.Join("||", new_background.items);
                string quantity_list = string.Join("||", new_background.quantities_items);

                lines[i - 1] +=
                    "\n-" + new_background.name +
                    "`" + new_background.description +
                    "`{" + stat_list + "}" +
                    "`{" + skill_list + "}" +
                    "`{" + feature_list + "}" +
                    "`{" + item_list + "}" +
                    "`{" + quantity_list + "}";
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Species(Species new_species)
    {
        string[] valid_stats = new[] { "STR", "DEX", "CON", "WIS", "INT", "CHA" };
        foreach (string stat in new_species.stat_boost_options)
        {
            if (!valid_stats.Contains(stat))
            {
                Debug.Log("ERR: Attempted Use of Invalid Stat");
                return;
            }
        }

        string[] viable_skills = Get_Section("SKILLS");
        for (int i = 0; i < new_species.skill_boosts.Count(); i++)
        {
            if (!viable_skills.Contains(new_species.skill_boosts[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Skill");
                return;
            }
        }

        string[] viable_features = Get_Section("FEATURES");
        for (int i = 0; i < new_species.features.Count(); i++)
        {
            if (!viable_features.Contains(new_species.features[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Feature");
                return;
            }
        }

        string[] viable_items = Get_Section("ITEMS");
        for (int i = 0; i < new_species.items.Length; i++)
        {
            if (!viable_items.Contains(new_species.items[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Item");
                return;
            }
        }

        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#SPECIES") in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + new_species.name + "`"))
                {
                    Debug.Log("ERR: Species already exists");
                    return;
                }
            }
            if (lines[i] == "#CLASSES")
            {
                string stat_list = string.Join("||", new_species.stat_boost_options);
                string skill_list = string.Join("||", new_species.skill_boosts);
                string feature_list = string.Join("||", new_species.features);

                string item_list = string.Join("||", new_species.items);
                if (item_list == "") { item_list = "N/A"; }

                string quantity_list = string.Join("||", new_species.quantities_items);
                if (quantity_list == "") { quantity_list = "0"; }


                lines[i - 1] +=
                    "\n-" + new_species.name +
                    "`" + new_species.description +
                    "`" + new_species.tile_speed +
                    "`" + new_species.hp_per_level +
                    "`{" + stat_list + "}" +
                    "`{" + skill_list + "}" +
                    "`{" + feature_list + "}" +
                    "`{" + item_list + "}" +
                    "`{" + quantity_list + "}";
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Class(Class new_class)
    {
        // Stats
        string[] valid_stats = new[] { "STR", "DEX", "CON", "WIS", "INT", "CHA" };
        foreach (string stat in new_class.stat_boost_options)
        {
            if (!valid_stats.Contains(stat))
            {
                Debug.Log("ERR: Attempted Use of Invalid Stat");
                return;
            }
        }

        // Skills
        string[] viable_skills = Get_Section("SKILLS");
        for (int i = 0; i < new_class.skill_boosts.Length; i++)
        {
            if (!viable_skills.Contains(new_class.skill_boosts[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Skill");
                return;
            }
        }

        // Features
        string[] viable_features = Get_Section("FEATURES");
        for (int i = 0; i < new_class.features.Length; i++)
        {
            if (!viable_features.Contains(new_class.features[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Feature");
                return;
            }
        }
        
        // Items
        string[] viable_items = Get_Section("ITEMS");
        for (int i = 0; i < new_class.items.Length; i++)
        {
            if (!viable_items.Contains(new_class.items[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Item");
                return;
            }
        }

        // Finding space for and placing class
        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "#CLASSES") in_section = true;
            if (in_section)
            {
                if (lines[i].StartsWith("-" + new_class.name + "`"))
                {
                    Debug.Log("ERR: Class already exists");
                    return;
                }
            }
            if (lines[i] == "#ITEMS")
            {
                string stat_list = string.Join("||", new_class.stat_boost_options);
                string skill_list = string.Join("||", new_class.skill_boosts);
                string feature_list = string.Join("||", new_class.features);
                string item_list = string.Join("||", new_class.items);
                string quantity_list = string.Join("||", new_class.quantities_items);

                lines[i - 1] +=
                    "\n-" + new_class.name +
                    "`" + new_class.description +
                    "`{" + stat_list + "}" +
                    "`{" + skill_list + "}" +
                    "`{" + feature_list + "}" +
                    "`{" + item_list + "}" +
                    "`{" + quantity_list + "}" +
                    "`" + new_class.hp_per_level;
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }
    public void Add_Item(Item new_item)
    {
        //Valid Properties
        string[] viable_properties = Get_Section("PROPERTIES");
        for (int i = 0; i < new_item.properties.Length; i++) {
            if (!viable_properties.Contains(new_item.properties[i])) {
                Debug.Log("ERR: Attempted Use of Invalid Property");
                return;
            }
        }

        //Valid Use Stats
        string[] valid_stats = new[] { "STR", "DEX", "CON", "WIS", "INT", "CHA" };
        for (int i = 0; i < new_item.use_stats.Length; i++) {
            if (!valid_stats.Contains(new_item.use_stats[i])) {
                Debug.Log("ERR: Attempted Use of Invalid Stat: " + new_item.use_stats[i]);
                return;
            }
        }


        //Valid Features
        string[] valid_features = Get_Section("FEATURES");
        for (int i = 0; i < new_item.features.Length; i++) {
            if (!valid_features[i].Contains(new_item.features[i])) {
                Debug.Log("ERR: Attempted Use of Invalid Feature: " + new_item.features[i]);
                return;
            }
        }

        //Valid Conditions
        string[] valid_conditions = Get_Section("CONDITIONS");
        if (new_item.conditions.Contains("N/A"))
        {
            if(new_item.conditions.Length != 1)
            {
                Debug.Log("ERR: Invalid Conditions Selected. N/A can't be selected WITH something else.");
                return;
            }
        }
        for (int i = 0; i < new_item.conditions.Length; i++)
        {
            if (!valid_conditions[i].Contains(new_item.conditions[i]))
            {
                Debug.Log("ERR: Attempted Use of Invalid Condition: " + new_item.conditions[i]);
                return;
            }
        }


        //Item Already Exists
        string[] items = Get_Section("ITEMS");
        if (items.Contains(new_item.name))
        {
            Debug.Log("ERR: Item " + new_item.name + " Already Exists");
            return;
        }

        //Constructing Item
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++) {
            if (lines[i] == "#CONDITIONS")
            {
                //list of properties
                string property_list = "";
                for (int y = 0; y < new_item.properties.Count(); y++) {
                    if (y == 0) property_list += new_item.properties[y];
                    else property_list += "||" + new_item.properties[y];
                }

                //list of use stats
                string use_stats_list = "";
                for (int y = 0; y < new_item.use_stats.Count(); y++) {
                    if (y == 0) use_stats_list += new_item.use_stats[y];
                    else use_stats_list += "||" + new_item.use_stats[y];
                }

                //list of features
                string features_list = "";
                for (int y = 0; y < new_item.features.Count(); y++) {
                    if (y == 0) features_list += new_item.features[y];
                    else features_list += "||" + new_item.features[y];
                }

                //list of conditions
                string conditions_list = "";
                for (int y = 0; y < new_item.conditions.Count(); y++) {
                    if (y == 0) conditions_list += new_item.conditions[y];
                    else conditions_list += "||" + new_item.conditions[y];
                }

                //assembly
                lines[i - 1] +=
                    "\n-" + new_item.name +
                    "`" + new_item.description +
                    "`" + new_item.value +
                    "`" + new_item.weapon.ToString() +
                    "`" + new_item.damage +
                    "`" + new_item.range +
                    "`" + new_item.armor.ToString() +
                    "`" + new_item.defense +
                    "`" + new_item.currency.ToString() +
                    "`" + new_item.consumed.ToString() +
                    "`" + new_item.augment.ToString() +
                    "`" + new_item.slot_cost +
                    "`" + new_item.function_on_use +
                    "`{" + property_list + "}" +
                    "`{" + use_stats_list + "}" +
                    "`{" + features_list + "}" +
                    "`{" + conditions_list + "}";
                File.WriteAllLines(active_directory, lines);
                break;
            }
        }
    }



    //GET
    public Item Get_Item(string name)
    {
        //Defaulting Constructor Values
        string desc = "ERR";
        List<string> properties = new List<string>();
        float value = -5318008;
        bool weapon = false;
        string damage = "ERR";
        int range = -5318008;
        bool augment = false;
        int slot_cost = -5318008;
        List<string> features = new List<string>();
        bool armor = false;
        string defense = "ERR";
        bool currency = false;
        bool consumed = false;
        string function = "ERR";
        string[] use_stats = new[] { "STR" };
        List<string> conditions = new List<string>();

        //Parsing Document for Constructor Values
        bool inSection = false;
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#ITEMS")) inSection = true;
            if (inSection && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');
                desc = parts[1];
                float.TryParse(parts[2], out value);
                bool.TryParse(parts[3], out weapon);
                damage = parts[4];
                int.TryParse(parts[5], out range);
                bool.TryParse(parts[6], out armor);
                defense = parts[7];
                bool.TryParse(parts[8], out currency);
                bool.TryParse(parts[9], out consumed);
                bool.TryParse(parts[10], out augment);
                int.TryParse(parts[11], out slot_cost);
                function = parts[12];
                properties = parts[13].Trim('{', '}').Split("||").ToList();
                use_stats = parts[14].Trim('{', '}').Split("||");
                features = parts[15].Trim('{', '}').Split("||").ToList();
                conditions = parts[16].Trim('{', '}').Split("||").ToList();
                break;
            }
        }

        //Checking if Parsing Failed
        if (properties.Count == 0 ||
            desc == "ERR" ||
            damage == "ERR" ||
            defense == "ERR" ||
            function == "ERR" ||
            use_stats.Contains("ERR") ||
            value == -5318008 ||
            range == -5318008 ||
            slot_cost == -5318008 ||
            features.Count == 0 ||
            conditions.Count == 0)
        {
            Item err = new Item("ERR", "ERR", new[] { "ERR" }, 0, false, "0", 0, false, "0", false, false, new[] { "N/A" }, 0, false, "ERR", new[] { "STR" }, new[] {"N/A"});
            return err;
        }
        else
        {
            Item new_item = new Item(name, desc, properties.ToArray(), value, weapon, damage, range, armor, defense, currency, augment, features.ToArray(), slot_cost, consumed, function, use_stats, conditions.ToArray());
            return new_item;
        }
    }
    public Skill Get_Skill(string name)
    {
        string function = "ERR";
        string[] use_stats = new[] { "ERR" };

        bool inSection = false;
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#SKILLS")) inSection = true;
            if (inSection && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');

                use_stats = parts[1].Trim('{', '}').Split("||");
                function = parts[2];

                break;
            }
        }
        if(function == "ERR" || use_stats[0] == "ERR")
        {
            Debug.Log("ERR: Skill not Found");
            return new Skill("ERR", "ERR", new[] { "ERR" });
        }
        else
        {
            return new Skill(name, function, use_stats);
        }
    }
    public Property Get_Property(string name)
    {
        string function = "ERR";

        string[] lines = File.ReadAllLines(active_directory);
        bool inSection = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#PROPERTIES")) inSection = true;
            if (inSection && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');
                function = parts[1];
                break;
            }
        }
        if (function == "ERR")
        {
            return new Property("ERROR", "ERROR");
        }
        else
        {
            return new Property(name, function);
        }
    }
    public Feature Get_Feature(string name)
    {
        string description = "ERR";

        //Acquisition Requirements
        bool player_accessible = false;

        int repeat_lim = -5318008;
        int repeat_per_levels = -5318008;

        List<string> req_stats = new List<string>();
        List<int> req_stats_amt = new List<int>();

        List<string> req_skills = new List<string>();
        List<int> req_skills_amt = new List<int>();

        List<string> req_items = new List<string>();
        List<int> req_items_amt = new List<int>();

        int req_speed = -5318008;
        int req_hp = -5318008;
        int req_def = -5318008;
        int req_lvl = -5318008;

        //Acquisition Bonuses
        string function = "ERR";

        List<string> add_stats = new List<string>();
        List<int> add_stats_amt = new List<int>();

        List<string> add_skills = new List<string>();
        List<int> add_skills_amt = new List<int>();

        List<string> add_items = new List<string>();
        List<int> add_items_amt = new List<int>();

        int add_speed = -5318008;
        int add_hp = -5318008;
        int add_defense = -5318008;
        int add_lvl = -5318008;


        bool in_section = false;
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#FEATURES")) in_section = true;
            if (in_section && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');

                description = parts[1];
                bool.TryParse(parts[2], out player_accessible);
                int.TryParse(parts[3], out repeat_lim);
                int.TryParse(parts[4], out repeat_per_levels);

                req_stats = parts[5].Trim('{', '}').Split("||").ToList();
                List<string> req_stats_amt_str = parts[6].Trim('{', '}').Split("||").ToList();
                foreach (string o in req_stats_amt_str) if (int.TryParse(o, out int n)) req_stats_amt.Add(n);

                req_skills = parts[7].Trim('{', '}').Split("||").ToList();
                List<string> req_skills_amt_str = parts[8].Trim('{', '}').Split("||").ToList();
                foreach (string o in req_skills_amt_str) if (int.TryParse(o, out int n)) req_skills_amt.Add(n);

                req_items = parts[9].Trim('{', '}').Split("||").ToList();
                List<string> req_items_amt_str = parts[10].Trim('{', '}').Split("||").ToList();
                foreach (string o in req_items_amt_str) if (int.TryParse(o, out int n)) req_items_amt.Add(n);

                int.TryParse(parts[11], out req_speed);
                int.TryParse(parts[12], out req_hp);
                int.TryParse(parts[13], out req_def);
                int.TryParse(parts[14], out req_lvl);

                function = parts[15];

                add_stats = parts[16].Trim('{', '}').Split("||").ToList();
                List<string> add_stats_amt_str = parts[17].Trim('{', '}').Split("||").ToList();
                foreach (string o in add_stats_amt_str) if (int.TryParse(o, out int n)) add_stats_amt.Add(n);

                add_skills = parts[18].Trim('{', '}').Split("||").ToList();
                List<string> add_skills_amt_str = parts[19].Trim('{', '}').Split("||").ToList();
                foreach (string o in add_skills_amt_str) if (int.TryParse(o, out int n)) add_skills_amt.Add(n);

                add_items = parts[20].Trim('{', '}').Split("||").ToList();
                List<string> add_items_amt_str = parts[21].Trim('{', '}').Split("||").ToList();
                foreach (string o in add_items_amt_str) if (int.TryParse(o, out int n)) add_items_amt.Add(n);

                int.TryParse(parts[22], out add_speed);
                int.TryParse(parts[23], out add_hp);
                int.TryParse(parts[24], out add_defense);
                int.TryParse(parts[25], out add_lvl);

                break;
            }
        }
        if (description == "ERR"
            || repeat_lim == -5318008
            || repeat_per_levels == -5318008
            || req_speed == -5318008
            || req_hp == -5318008
            || req_def == -5318008
            || req_lvl == -5318008
            || add_speed == -5318008
            || add_hp == -5318008
            || add_defense == -5318008
            || add_lvl == -5318008
            || !req_stats.Any()
            || !req_stats_amt.Any()
            || !req_skills.Any()
            || !req_skills_amt.Any()
            || !req_items.Any()
            || !req_items_amt.Any()
            || function == "ERR"
            || !add_stats.Any()
            || !add_stats_amt.Any()
            || !add_skills.Any()
            || !add_skills_amt.Any()
            || !add_items.Any()
            || !add_items_amt.Any())
        {
            return new Feature("ERR", "ERR");
        }
        else
        {
            Feature new_feature = new Feature(name, description);
            new_feature.player_accessible = player_accessible;
            new_feature.repeat_lim = repeat_lim;
            new_feature.repeat_per_levels = repeat_per_levels;

            new_feature.req_stats = req_stats.ToArray();
            new_feature.req_stats_amt = req_stats_amt.ToArray();

            new_feature.req_skills = req_skills.ToArray();
            new_feature.req_skills_amt = req_skills_amt.ToArray();

            new_feature.req_items = req_items.ToArray();
            new_feature.req_items_amt = req_items_amt.ToArray();

            new_feature.req_speed = req_speed;
            new_feature.req_hp = req_hp;
            new_feature.req_def = req_def;
            new_feature.req_lvl = req_lvl;

            new_feature.function = function;

            new_feature.add_stats = add_stats.ToArray();
            new_feature.add_stats_amt = add_stats_amt.ToArray();

            new_feature.add_skills = add_skills.ToArray();
            new_feature.add_skills_amt = add_skills_amt.ToArray();

            new_feature.add_items = add_items.ToArray();
            new_feature.add_items_amt = add_items_amt.ToArray();

            new_feature.add_speed = add_speed;
            new_feature.add_hp = add_hp;
            new_feature.add_defense = add_defense;
            new_feature.add_lvl = add_lvl;

            return new_feature;
        }
    }
    public Condition Get_Condition(string name)
    {
        string function = "ERR";
        string trigger = "ERR";

        bool in_section = false;
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#CONDITIONS")) in_section = true;
            if (in_section && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');

                trigger = parts[1];
                function = parts[2];

                break;
            }
        }
        if (function == "ERR" || trigger == "ERR")
        {
            return new Condition("ERR", "ERR", "ERR");
        }
        else
        {
            return new Condition(name, function, trigger);
        }
    }
    public Background Get_Background(string name)
    {
        string description = "ERR";
        List<string> stat_boost_options = new List<string>();
        List<string> skill_boosts = new List<string>();
        List<string> features = new List<string>();
        List<string> items = new List<string>();
        List<float> quantities = new List<float>();


        bool in_section = false;
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#BACKGROUNDS")) in_section = true;
            if (in_section && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');

                description = parts[1];
                stat_boost_options = parts[2].Trim('{', '}').Split("||").ToList();
                skill_boosts = parts[3].Trim('{', '}').Split("||").ToList();
                features = parts[4].Trim('{', '}').Split("||").ToList();
                items = parts[5].Trim('{', '}').Split("||").ToList();

                List<string> quantities_items_string =
                parts[6].Trim('{', '}').Split("||").ToList();
                foreach (string item in quantities_items_string)
                {
                    if (float.TryParse(item, out float n))
                        quantities.Add(n);
                }
                if (items.Count < 1 || quantities.Count < 1)
                {
                    items = new[] { "N/A" }.ToList();
                    quantities = new[] { 0f }.ToList();
                }

                break;
            }
        }

        if (description == "ERR" || stat_boost_options.Count < 1 || skill_boosts.Count < 1 || features.Count < 1)
        {
            return new Background("ERR", "ERR", new[] {"N/A"}, new[] {"STR"}, new[] {"N/A"}, new[] {"N/A"}, new[] {0f});
        }
        else
        {
            return new Background(name, description, items.ToArray(), stat_boost_options.ToArray(), skill_boosts.ToArray(), features.ToArray(), quantities.ToArray());
        }
    }
    public Species Get_Species(string name)
    {
        string description = "ERR";
        int tile_speed = -5018018;
        int hp_per_level = -5018018;
        List<string> stat_boost_options = new List<string>();
        List<string> skill_boosts = new List<string>();
        List<string> features = new List<string>();
        List<string> items = new List<string>();
        List<float> quantities = new List<float>();


        bool in_section = false;
        string[] lines = File.ReadAllLines(active_directory);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#SPECIES")) in_section = true;
            if (in_section && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');

                description = parts[1];
                int.TryParse(parts[2], out tile_speed);
                int.TryParse(parts[3], out hp_per_level);
                stat_boost_options = parts[4].Trim('{', '}').Split("||").ToList();
                skill_boosts = parts[5].Trim('{', '}').Split("||").ToList();
                features = parts[6].Trim('{', '}').Split("||").ToList();
                items = parts[7].Trim('{', '}').Split("||").ToList();

                List<string> quantities_items_string = parts[6].Trim('{', '}').Split("||").ToList();
                foreach (string item in quantities_items_string)
                {
                    if (float.TryParse(item, out float n))
                        quantities.Add(n);
                }
                if (items.Count < 1 || quantities.Count < 1)
                {
                    items = new[] { "N/A" }.ToList();
                    quantities = new[] { 0f }.ToList();
                }

                break;
            }
        }

        if (description == "ERR" || stat_boost_options.Count < 1 || skill_boosts.Count < 1 || features.Count < 1)
        {
            return new Species("ERR", "ERR", 0, 0, new[] {"STR"}, new[] {"N/A"}, new[] {"N/A"}, new[] {"N/A"}, new[] {0f});
        }
        else
        {
            return new Species(name, description, tile_speed, hp_per_level, stat_boost_options.ToArray(), skill_boosts.ToArray(), features.ToArray(), items.ToArray(), quantities.ToArray());
        }
    }
    public Class Get_Class(string name)
    {
        string description = "ERR";
        int hp_per_level = -5018018;
        List<string> stat_boost_options = new List<string>();
        List<string> skill_boosts = new List<string>();
        List<string> features = new List<string>();
        List<string> items = new List<string>();
        List<float> quantities_items = new List<float>();

        string[] lines = File.ReadAllLines(active_directory);
        bool in_section = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("#CLASSES")) in_section = true;
            if (in_section && lines[i].StartsWith("-" + name + "`"))
            {
                string line = lines[i].Substring(1);
                string[] parts = line.Split('`');
                description = parts[1];

                stat_boost_options = parts[2].Trim('{', '}').Split("||").ToList();
                skill_boosts = parts[3].Trim('{', '}').Split("||").ToList();
                features = parts[4].Trim('{', '}').Split("||").ToList();
                items = parts[5].Trim('{', '}').Split("||").ToList();

                List<string> quantities_items_string =
                    parts[6].Trim('{', '}').Split("||").ToList();

                foreach (string item in quantities_items_string)
                {
                    if (float.TryParse(item, out float n))
                        quantities_items.Add(n);
                }
                if (items.Count < 1 || quantities_items.Count < 1)
                {
                    items = new[] { "N/A" }.ToList();
                    quantities_items = new[] { 0f }.ToList();
                }

                int.TryParse(parts[7], out hp_per_level);
                break;
            }
        }

        if (description == "ERR" || stat_boost_options.Count < 1 || skill_boosts.Count < 1)

        {
            return new Class("ERR", "ERR", 0, new[] {"STR"}, new[] {"N/A"}, new[] {"N/A"}, new[] {"N/A"}, new[] { 0f });
        }
        else
        {
            return new Class(name, description, hp_per_level, stat_boost_options.ToArray(), skill_boosts.ToArray(), features.ToArray(), items.ToArray(), quantities_items.ToArray());
        }
    }



    //GET SECTION
    public string[] Get_Section(string section)
    {
        List<string> lines = File.ReadAllLines(active_directory).ToList();
        List<string> objects = new List<string>();
        bool inSection = false;
        for (int i = 0; i < lines.Count(); i++)
        {
            if (lines[i].StartsWith("#" + section.ToUpper())) inSection = true;
            if (inSection)
            {
                if (lines[i].StartsWith("#") && !lines[i].StartsWith("#" + section.ToUpper())) inSection = false;
                if (lines[i].StartsWith("-")) objects.Add(lines[i].Substring(1, lines[i].IndexOf("`") - 1).Trim());
            }
        }

        objects.Sort();
        return objects.ToArray();
    }
    public Skill[] Get_All_Skills()
    {
        string[] skills = Get_Section("SKILLS");
        List<Skill> returned = new List<Skill>();
        foreach(string skill in skills)
        {
            Skill to_return = Get_Skill(skill);
            if(to_return.name != "ERR" && to_return.name != "N/A")
            {
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Property[] Get_All_Properties()
    {
        string[] section = Get_Section("PROPERTIES");
        List<Property> returned = new List<Property>();
        foreach (string obj in section)
        {
            Property to_return = Get_Property(obj);
            if (to_return.name != "ERR" && to_return.name != "N/A")
            {
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Feature[] Get_All_Features()
    {
        string[] section = Get_Section("FEATURES");
        List<Feature> returned = new List<Feature>();
        foreach (string obj in section)
        {
            if (obj != "ERR" && obj != "N/A")
            {
                Feature to_return = Get_Feature(obj);
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Condition[] Get_All_Conditions()
    {
        string[] section = Get_Section("CONDITIONS");
        List<Condition> returned = new List<Condition>();
        foreach (string obj in section)
        {
            if (obj != "ERR" && obj != "N/A")
            {
                Condition to_return = Get_Condition(obj);
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Background[] Get_All_Backgrounds()
    {
        string[] section = Get_Section("BACKGROUNDS");
        List<Background> returned = new List<Background>();
        foreach (string obj in section)
        {
            if (obj != "ERR" && obj != "N/A")
            {
                Background to_return = Get_Background(obj);
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Species[] Get_All_Species()
    {
        string[] section = Get_Section("SPECIES");
        List<Species> returned = new List<Species>();
        foreach (string obj in section)
        {
            if (obj != "ERR" && obj != "N/A")
            {
                Species to_return = Get_Species(obj);
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Class[] Get_All_Classes()
    {
        string[] section = Get_Section("CLASSES");
        List<Class> returned = new List<Class>();
        foreach (string obj in section)
        {
            if (obj != "ERR" && obj != "N/A")
            {
                Class to_return = Get_Class(obj);
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Item[] Get_All_Items()
    {
        string[] section = Get_Section("ITEMS");
        List<Item> returned = new List<Item>();
        foreach (string obj in section)
        {
            if (obj != "ERR" && obj != "N/A")
            {
                Item to_return = Get_Item(obj);
                returned.Add(to_return);
            }
        }
        return returned.ToArray();
    }
    public Item[] Get_Currencies()
    {
        Item[] items = Get_All_Items();
        List<Item> currencies = new List<Item>();
        foreach (Item item in items)
        {
            if (item.currency) currencies.Add(item);
        }
        return currencies.ToArray();
    }


    //INTERPRET DATA
    public string Interpret_Skill(string name)
    {
        string r = "ERR: Not Found";
        Skill s = Get_Skill(name);
        if(s.name != "ERR")
        {
            r   = "Name: " + s.name
                + "\n\nFunction: " + s.function
                + "\n\nUse Stats: " + string.Join("\n\t- ", s.use_stats);
        }
        return r;
    }
    public string Interpret_Property(string name)
    {
        string r = "ERR: Not Found";
        Property p = Get_Property(name);
        if (p.name != "ERR")
        {
            r   = "Name: " + p.name
                + "\n\nFunction: " + p.function;
        }
        return r;
    }
    public string Interpret_Feature(string name)
    {
        string r = "ERR: Not Found";
        Feature f = Get_Feature(name);
        if (f.name != "ERR")
        {
            r   = "Name: " + f.name
                + "\n\nDescription" + f.description
                + "\n\nRepeat Limit: " + f.repeat_lim
                + "\n\nRepeats Every " + f.repeat_per_levels + " Level(s)";

            string required_stats = "";
            for (int i = 0; i < f.req_stats.Count(); i++)
            {
                if (i == 0) { required_stats += "Required Stats:"; }
                required_stats += "\n\t- " + f.req_stats[i] + " LVL " + f.req_stats_amt[i];
            }
            string required_skills = "";
            for (int i = 0; i < f.req_skills.Count(); i++)
            {
                if (i == 0) { required_skills += "Required Skills:"; }
                required_skills += "\n\t- " + f.req_skills[i] + " LVL " + f.req_skills_amt[i];
            }
            string required_items = "";
            for (int i = 0; i < f.req_items.Count(); i++)
            {
                if (i == 0) { required_items += "Required Items:"; }
                required_items += "\n\t- " + f.req_items[i] + " x" + f.req_items_amt[i];
            }
            r += "\n\n" + required_stats 
                + "\n\n" + required_skills 
                + "\n\n" + required_items;

            r += "\n\nRequired Speed: " + f.req_speed +
                "\n\nRequired HP: " + f.req_hp +
                "\n\nRequired Defense: " + f.req_def +
                "\n\nRequired Level: " + f.req_lvl;

            string added_stats = "";
            for (int i = 0; i < f.add_stats.Count(); i++)
            {
                if (i == 0) { added_stats += "Granted Stats:"; }
                added_stats += "\n\t- " + f.add_stats[i] + " LVL " + f.add_stats_amt[i];
            }
            string added_skills = "";
            for (int i = 0; i < f.add_skills.Count(); i++)
            {
                if (i == 0) { added_skills += "Granted Skills:"; }
                added_skills += "\n\t- " + f.add_skills[i] + " LVL " + f.add_skills_amt[i];
            }
            string added_items = "";
            for (int i = 0; i < f.add_items.Count(); i++)
            {
                if (i == 0) { added_items += "Granted Skills:"; }
                added_items += "\n\t- " + f.add_items[i] + " LVL " + f.add_items_amt[i];
            }

            r += "\n\n" + added_stats 
                + "\n\n" + added_skills 
                + "\n\n" + added_items;

            r += "\n\nFunction: " + f.function 
                + "\n\nGranted Speed: " + f.add_speed
                + "\n\nGranted HP: " + f.add_hp
                + "\n\nGranted Defense: " + f.add_defense
                + "\n\nGranted Level(s): " + f.add_lvl;
        }
        return r;
    }
    public string Interpret_Condition(string name)
    {
        string r = "ERR: Not Found";
        Condition c = Get_Condition(name);
        if (c.name != "ERR")
        {
            r = "Name: " + c.name
                + "\n\nFunction: " + c.function
                + "\n\nTrigger: " + c.trigger;
        }
        return r;
    }
    public string Interpret_Background(string name)
    {
        string r = "ERR: Not Found";
        Background b = Get_Background(name);
        if (b.name != "ERR")
        {
            r = "Name: " + b.name
                + "\n\nStat Boost Options: " + string.Join(", ", b.stat_boost_options)
                + "\n\nSkill Boosts: " + string.Join(", ", b.skill_boosts)
                + "\n\nFeatures: " + string.Join(", ", b.features);

            string items = "Items:";
            for (int i = 0; i < b.items.Count(); i++)
            {
                items += "\n\t- " + b.items[i] + " x" + b.quantities_items[i];
            }
            r += "\n\n" + items;
        }
        return r;
    }
    public string Interpret_Species(string name)
    {
        string r = "ERR: Not Found";
        Species s = Get_Species(name);
        if (s.name != "ERR")
        {
            r = "Name: " + s.name
                + "\n\nDescription: " + s.description
                + "\n\nTile Speed: " + s.tile_speed
                + "\n\nHP per Level: " + s.hp_per_level
                + "\n\nStat Boost Options: " + string.Join(", ", s.stat_boost_options)
                + "\n\nSkill Boosts: " + string.Join(", ", s.skill_boosts)
                + "\n\nFeatures: " + string.Join(", ", s.features);

            string items = "Items:";
            for (int i = 0; i < s.items.Count(); i++)
            {
                items += "\n\t- " + s.items[i] + " x" + s.quantities_items[i];
            }
            r += "\n\n" + items;
        }
        return r;
    }
    public string Interpret_Class(string name)
    {
        string r = "ERR: Not Found";
        Class c = Get_Class(name);
        if (c.name != "ERR")
        {
            r = "Name: " + c.name
                + "\n\n" + c.description
                + "\n\nHP per Level: " + c.hp_per_level
                + "\n\nStat Boost Options: " + string.Join(", ", c.stat_boost_options)
                + "\n\nSkill Boosts: " + string.Join(", ", c.skill_boosts)
                + "\n\nFeatures: " + string.Join(", ", c.features);

            string items = "Items:";
            for (int i = 0; i < c.items.Count(); i++)
            {
                items += "\n\t- " + c.items[i] + " x" + c.quantities_items[i];
            }
            r += "\n\n" + items;
        }
        return r;
    }
    public string Interpret_Item(string name)
    {
        string r = "ERR: Not Found";
        Item i = Get_Item(name);
        if (i.name != "ERR")
        {
            r = "Name: " + i.name
                + "\n\n" + i.description
                + "\n\n" + i.function_on_use
                + "\n\nIs Weapon: " + i.weapon
                + "\n\nIs Armor: " + i.armor
                + "\n\nIs Augment: " + i.augment
                + "\n\nIs Currency: " + i.currency
                + "\n\nIs Consumed: " + i.consumed
                + "\n\nRange: " + i.range
                + "\n\nDamage: " + i.damage
                + "\n\nDefense: " + i.defense
                + "\n\nValue: " + i.value
                + "\n\nAugment Slot Cost: " + i.slot_cost
                + "\n\nProperties: " + string.Join(", ", i.properties)
                + "\n\nUse Stats: " + string.Join(", ", i.use_stats)
                + "\n\nFeatures: " + string.Join(", ", i.features)
                + "\n\nInflicted Conditions:" + string.Join("\n-", i.conditions);
        }
        return r;
    }
}