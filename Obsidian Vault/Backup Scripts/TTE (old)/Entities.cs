public enum Stat
{
    STR,
    DEX,
    CON,
    CHA,
    INT,
    WIS,

    LVL,
    SPD,
    NULL,
}

// Items
public class Item
{
    public string name;
    public string description;
    public string[] properties;
    public float value;

    public bool weapon;
    public string damage;
    public int range;

    public bool augment;
    public int slot_cost;
    public string[] features;

    public bool armor;
    public string defense;

    public bool currency;
    public bool consumed;

    public string function_on_use;
    public string[] use_stats;

    public string[] conditions;

    public Item(string name, string description, string[] properties, float value, bool weapon, string damage, int range, bool armor, string defense, bool currency, bool augment, string[] features, int slot_cost, bool consumed, string function_on_use, string[] use_stats, string[] conditions)
    {
        this.name = name;
        this.description = description;
        this.properties = properties;
        this.value = value;
        this.weapon = weapon;
        this.damage = damage;
        this.range = range;
        this.armor = armor;
        this.defense = defense;
        this.currency = currency;
        this.augment = augment;
        this.features = features;
        this.slot_cost = slot_cost;
        this.consumed = consumed;
        this.function_on_use = function_on_use;
        this.use_stats = use_stats;
        this.conditions = conditions;
    }
}


// Skills
public class Skill
{
    public string name;
    public string function;
    public string[] use_stats;

    public Skill(string name, string function, string[] use_stats)
    {
        this.name = name;
        this.function = function;
        this.use_stats = use_stats;
    }
}


// Properties
public class Property
{
    public string name;
    public string function;

    public Property(string name, string function)
    {
        this.name = name;
        this.function = function;
    }
}



// Features
public class Feature
{
    public string name;
    public string description;
    public string function = "";

    //Acquisition Requirements
    public bool player_accessible = false;

    public int repeat_lim = 1;
    public int repeat_per_levels = 0;

    public string[] req_stats = null;
    public int[] req_stats_amt = null;

    public string[] req_skills = null;
    public int[] req_skills_amt = null;

    public string[] req_items = null;
    public int[] req_items_amt = null;

    public int req_speed = 0;
    public int req_hp = 0;
    public int req_def = 0;
    public int req_lvl = 0;

    //Acquisition Bonuses
    public string[] add_stats = null;
    public int[] add_stats_amt = null;

    public string[] add_skills = null;
    public int[] add_skills_amt = null;

    public string[] add_items = null;
    public int[] add_items_amt = null;

    public int add_speed = 0;
    public int add_hp = 0;
    public int add_defense = 0;
    public int add_lvl = 0;

    public Feature(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}


// Conditions
public class Condition
{
    public string name;
    public string function;
    public string trigger;

    public Condition(string name, string function, string trigger)
    {
        this.name = name;
        this.function = function;
        this.trigger = trigger;
    }
}


// Backgrounds
public class Background
{
    public string name;
    public string description;
    public string[] stat_boost_options;
    public string[] skill_boosts;
    public string[] features;
    public string[] items;
    public float[] quantities_items;

    public Background(
        string name,
        string description,
        string[] items,
        string[] stat_boost_options,
        string[] skill_boosts,
        string[] features,
        float[] quantities_items)
        {
            this.name = name;
            this.description = description;
            this.stat_boost_options = stat_boost_options;
            this.skill_boosts = skill_boosts;
            this.features = features;
            this.items = items;
            this.quantities_items = quantities_items;
        }
}


// Species
public class Species
{
    public string name;
    public string description;
    public int tile_speed;
    public int hp_per_level;
    public string[] stat_boost_options;
    public string[] skill_boosts;
    public string[] features;
    public string[] items;
    public float[] quantities_items;

    public Species(
        string name,
        string description,
        int tile_speed,
        int hp_per_level,
        string[] stat_boost_options,
        string[] skill_boosts,
        string[] features,
        string[] items,
        float[] quantities_items)
    {
        this.name = name;
        this.description = description;
        this.tile_speed = tile_speed;
        this.hp_per_level = hp_per_level;
        this.stat_boost_options = stat_boost_options;
        this.skill_boosts = skill_boosts;
        this.features = features;
        this.items = items;
        this.quantities_items = quantities_items;
    }
}


// Classes
public class Class
{
    public string name;
    public string description;
    public int hp_per_level;
    public string[] stat_boost_options;
    public string[] skill_boosts;
    public string[] features;
    public string[] items;
    public float[] quantities_items;

    public Class(
        string name,
        string description,
        int hp_per_level,
        string[] stat_boost_options,
        string[] skill_boosts,
        string[] features,
        string[] items,
        float[] quantities_items)
    {
        this.name = name;
        this.description = description;
        this.hp_per_level = hp_per_level;
        this.stat_boost_options = stat_boost_options;
        this.skill_boosts = skill_boosts;
        this.features = features;
        this.items = items;
        this.quantities_items = quantities_items;
    }
}