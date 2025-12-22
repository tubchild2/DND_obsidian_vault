using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// VALIDATION
public static class debug
{
    public static List<char> invalid_characters = new List<char>
    {
        ':', '/', '\\', '*', '?', '"', '<', '>', '|', '.', '!', '\0', '\t', '\n', '\r'
    };
    public static bool valid_string(string text)
    {
        bool valid = true;
        foreach (char c in text)
        {
            if (invalid_characters.Contains(c))
            {
                valid = false;
            }
        }
        return valid;
    }
    public static void error(string message)
    {
        Debug.Log(message);
    }
}



// PREFERENCES
[Serializable] public class Preferences
{
    float _music_vol = 0;
    float _sfx_vol = 0;
    string _username = "";

    public float music_volume() { return _music_vol; }
    public float sfx_volume() { return _sfx_vol; }
    public string username() { return _username; }

    public void set_music_volume(float music_volume) { 
        if (music_volume >= 0 && music_volume < 1) {
            _music_vol = music_volume;
        }
    }
    public void set_sfx_volume (float sfx_volume) {
        if (sfx_volume >= 0 && sfx_volume < 1) {
            _sfx_vol = sfx_volume;
        }
    }
    public void set_username (string username) {
        if (debug.valid_string(username)) {
            _username = username;
        }
    }

    public Preferences(float music_volume, float sfx_volume, string username)
    {
        set_music_volume(music_volume);
        set_sfx_volume(sfx_volume);
        set_username(username);
    }
}


// CORE STATS
public class CoreStatStr
{
    static List<string> _stats = new List<string>() { "STR", "DEX", "CON", "CHA", "INT", "WIS" };
    public static List<string> stats() { return _stats; }
}
[Serializable] public class CoreStatAmt
{
    CoreStat _stat = CoreStat.ERR;
    int _amount = 0;
    public CoreStat stat() { return _stat; }
    public int amount() { return _amount; }

    public void set_stat(CoreStat stat) { _stat = stat; }
    public void set_amount(int amount) 
    { 
        if (amount >= 0)
        {
            _amount = amount;
        }
    }

    public CoreStatAmt(CoreStat stat, int amount)
    {
        set_stat(stat);
        set_amount(amount);
    }

}
[Serializable] public enum CoreStat
{
    STR,
    DEX,
    CON,
    CHA,
    INT,
    WIS,
    ERR
}
[Serializable] public class CoreStatblock
{
    CoreStatAmt _str = new CoreStatAmt(CoreStat.STR, 0);
    CoreStatAmt _dex = new CoreStatAmt(CoreStat.DEX, 0);
    CoreStatAmt _con = new CoreStatAmt(CoreStat.CON, 0);
    CoreStatAmt _cha = new CoreStatAmt(CoreStat.CHA, 0);
    CoreStatAmt _wis = new CoreStatAmt(CoreStat.WIS, 0);
    CoreStatAmt _int = new CoreStatAmt(CoreStat.INT, 0);
    
    public CoreStatAmt STR() { return  _str; }
    public CoreStatAmt DEX() { return _dex; }
    public CoreStatAmt CON() { return _con; }
    public CoreStatAmt CHA() { return _cha; }
    public CoreStatAmt WIS() { return _wis; }
    public CoreStatAmt INT() { return _int; }

    public void set_STR(int STR) { _str.set_amount(STR); }
    public void set_DEX(int DEX) { _dex.set_amount(DEX); }
    public void set_CON(int CON) { _con.set_amount(CON); }
    public void set_CHA(int CHA) { _cha.set_amount(CHA); }
    public void set_WIS(int WIS) { _wis.set_amount(WIS); }
    public void set_INT(int INT) { _int.set_amount(INT); }
}


// DERIVED STATS
[Serializable] public enum DerivedStat
{
    MHP,
    SPD,
    DEF,
    ERR
}
[Serializable] public class DerivedStatAmt
{
    DerivedStat _stat = DerivedStat.ERR;
    int _amt = 0;

    public DerivedStat stat() { return _stat; }
    public int amount() { return _amt; }

    public void set_stat(DerivedStat stat) { _stat = stat; }
    public void set_amount(int amount) 
    {
        if (_stat == DerivedStat.SPD)
        {
            if (amount > 0)
            {
                _amt = amount;
            }
        }
        else if (_stat == DerivedStat.DEF)
        {
            if (amount > 0)
            {
                _amt = amount;
            }
        }
        else if (_stat == DerivedStat.MHP)
        {
            if (amount > 0)
            {
                _amt = amount;
            }
        }
    }

    public DerivedStatAmt(DerivedStat stat, int amount)
    {
        set_stat(stat);
        set_amount(amount);
    }
}


// DICE
public class DiceStr
    {
        static List<string> _dice = new List<string>() { "d2", "d4", "d6", "d8", "d10", "d12", "d20" };
        public static List<string> dice() { return _dice; }
    }
[Serializable] public enum Die
{
    d2,
    d4,
    d6,
    d8,
    d10,
    d12,
    d20,
    d100
}


// EQUATION
[Serializable] public class Equation
{
    string _equation;
    List<string> _parts = new List<string>();

    List<string> _functions = new List<string>();
    List<string> _stats = new List<string>();
    List<string> _dice = new List<string>();
    List<string> _nums = new List<string>();
    List<string> _mods = new List<string>();


    // Private Functions
    void Reset_Parts()
    {
        if (string.IsNullOrWhiteSpace(_equation)) _parts = new List<string>();
        else _parts = _equation.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    enum Type
    {
        err,
        stat,
        num,
        mod,
        dice
    }
    Type GetType(string key)
    {
        if (_stats.Contains(key)) return Type.stat;
        if (_dice.Contains(key)) return Type.dice;
        if (_nums.Contains(key)) return Type.num;
        if (_mods.Contains(key)) return Type.mod;
        return Type.err;
    }


    // Public Functions
    public Equation()
    {
        _equation = "";
        Reset_Parts();

        _stats = CoreStatStr.stats();
        _dice = DiceStr.dice();
        _nums = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        _mods = new List<string> { "+", "-" };

        _functions = new List<string>();
        _functions.AddRange(_stats);
        _functions.AddRange(_dice);
        _functions.AddRange(_nums);
        _functions.AddRange(_mods);
    }
    public void Add(string key)
    {
        if (!_functions.Contains(key)) return;
        Reset_Parts();


        // Identification of New Part
        Type type = GetType(key);


        // Anything first, except mods
        if (_parts.Count == 0 && type != Type.mod)
        {
            _equation += key;
            _equation = _equation.TrimStart();
            Reset_Parts();
            return;
        }

        // Identification of Last Part
        string last_key = _parts[_parts.Count - 1];
        if (!_functions.Contains(last_key))
        {
            Clear();
            return;
        }
        Type last_type = GetType(last_key);


        // Num -> Num
        if (last_type == Type.num && type == Type.num)
        {
            _equation += " " + key;
            _equation = _equation.TrimStart();
            Reset_Parts();
            return;
        }


        // Num -> Dice
        if (last_type == Type.num && type == Type.dice)
        {
            _equation += " " + key;
            _equation = _equation.TrimStart();
            Reset_Parts();
            return;
        }


        // !Mod -> Mod || Mod -> !Mod
        if ((last_type != Type.mod && type == Type.mod) || (last_type == Type.mod && type != Type.mod))
        {
            _equation += " " + key;
            _equation = _equation.TrimStart();
            Reset_Parts();
            return;
        }
    }
    public void Delete()
    {
        Reset_Parts();

        // Expected equation split into parts
        List<string> new_parts = new List<string>();
        for (int i = 0; i < _parts.Count() - 1; i++)
        {
            new_parts.Add(_parts[i]);
        }


        // Do nothing if the equation is empty
        if (new_parts.Count == 0)
        {
            Clear();
            return;
        }


        // Assembling new equation from expected equation parts
        _equation = string.Join(" ", new_parts);
        Reset_Parts();
    }
    public void Clear()
    {
        _equation = "";
        Reset_Parts();
    }

    public string equation_f()
    {
        Reset_Parts();
        List<string> out_parts = new List<string>();
        for (int i = 0; i < _parts.Count; i++)
        {
            string part = _parts[i];
            if (_mods.Contains(part))
            {
                out_parts.Add(" " + part + " ");
            }
            else
            {
                out_parts.Add(part);
            }
        }

        string output = string.Join("", out_parts).Replace("  ", " ").Trim();
        return output;
    }
    public string equation()
    {
        return _equation;
    }
}


// LIBRARY ATTRIBUTES
[Serializable] public class LibraryAttributes
{
    string _name = "";
    string _description = "";
    int _difficulty = 1;

    int _min_difficulty = 1;
    int _max_difficulty = 20;

    public string name() { return _name; }
    public string description() { return _description; }
    public int difficulty() { return _difficulty; }

    public void set_name(string name)
    {
        if (debug.valid_string(name))
        {
            _name = name;
        }
    }
    public void set_description(string description)
    {
        if (debug.valid_string(description))
        {
            _description = description;
        }
    }
    public void set_difficulty(int difficulty)
    {
        if (difficulty >= _min_difficulty && difficulty < _max_difficulty)
        {
            _difficulty = difficulty;
        }
    }

    public LibraryAttributes(string name, string description, int difficulty)
    {
        set_name(name);
        set_description(description);
        set_difficulty(difficulty);
    }
}


// ID
// A library content needs an ID that can be referenced
[Serializable] public class ID
{
    int _id = 0;
    public void set_id(int id) 
    { 
        if (id <= 0)
        {
            _id = id;
        }
    }
    public int id() { return _id; }
}
[Serializable] public class IDAmt : ID
{
    int _amt = 0;
    public int amount() { return _amt; }
    public void set_amount(int amount) 
    { 
        if (amount >= 0)
        {
            _amt = amount;
        }
    }
}


// SKILLS
[Serializable] public class Skill : ID
{
    string _name;
    string _function;
    CoreStat[] _use_stats;

    public void set_name(string name)
    {
        _name = name;
    }
    public void set_function(string function)
    {
        _function = function;
    }
    public void set_use_stats(CoreStat[] use_stats)
    {
        _use_stats = use_stats;
    }

    public string name() { return _name; }
    public string function() { return _function; }
    public CoreStat[] use_stats() { return _use_stats; }


    public Skill(string name, string function, CoreStat[] use_stats)
    {
        set_name(name);
        set_function(function);
        set_use_stats(use_stats);
    }
}
[Serializable] public class SkillAmt : IDAmt
{
    public SkillAmt(int id, int amount)
    {
        set_id(id);
        set_amount(amount);
    }
}


// ITEM PROPERTIES
[Serializable] public class Property : ID
{
    string _name = "";
    string _function = "";

    public string name()
    {
        return _name;
    }
    public string function()
    {
        return _function;
    }

    public void set_name(string name)
    {
        if (debug.valid_string(name))
        {
            _name = name;
        }

    }
    public void set_function(string function)
    {
        if (debug.valid_string(function))
        {
            _function = function;
        }
    }

    public Property(string name, string function)
    {
        set_name(name);
        set_function(function);
    }
}


// CONDITIONS
[Serializable] public class Condition : ID
{
    string _name = "";
    string _function = "";
    string _trigger = "";

    public string name() { return _name; }
    public string function() { return _function; }
    public string trigger() { return _trigger; }

    public void set_name(string name) 
    {
        if (debug.valid_string(name))
        {
            _name = name;
        }
    }
    public void set_function(string function) 
    {
        if (debug.valid_string(function))
        {
            _function = function;
        }
    }
    public void set_trigger(string trigger) 
    { 
        if (debug.valid_string(trigger))
        {
            _trigger = trigger;
        }
    }

    public Condition(string name, string function, string trigger)
    {
        set_name(name);
        set_function(function);
        set_trigger(trigger);
    }
}


// FEATURES
[Serializable] public class Feature : ID
{
    string _name = "";
    string _description = "";

    // Acquisition Requirements
    bool _player_accessible = false;
    int _repeat_lim = 1;
    int _repeat_every_levels = 0;

    CoreStatAmt[] _req_stats = new CoreStatAmt[] { new CoreStatAmt(CoreStat.ERR, 0)};
    SkillAmt[] _req_skills = new SkillAmt[] { new SkillAmt(0, 0) };
    DerivedStatAmt[] _req_d_stats = new DerivedStatAmt[] { new DerivedStatAmt(DerivedStat.ERR, 0) };
    ItemAmt[] _req_items = new ItemAmt[] { new ItemAmt(0, 0) };

    // Acquisition Bonuses
    CoreStatAmt[] _add_stats = new CoreStatAmt[] { new CoreStatAmt(CoreStat.ERR, 0) };
    SkillAmt[] _add_skills = new SkillAmt[] { new SkillAmt(0, 0) };
    DerivedStatAmt[] _add_d_stats = new DerivedStatAmt[] { new DerivedStatAmt(DerivedStat.ERR, 0) };
    ItemAmt[] _add_items = new ItemAmt[] { new ItemAmt(0, 0) };

    // Getters
    public string name() { return _name; }
    public string description() { return _description; }
    public bool player_accessible() { return _player_accessible; }
    public int repeat_limit() { return _repeat_lim; }
    public int repeat_every_levels() { return _repeat_every_levels; }
    public CoreStatAmt[] required_stats() {  return _req_stats; }
    public SkillAmt[] required_skills() { return _req_skills; }
    public DerivedStatAmt[] required_derived_stats() { return _req_d_stats; }
    public ItemAmt[] required_items() { return _req_items; }
    public CoreStatAmt[] added_stats() { return _add_stats; }
    public SkillAmt[] added_skills() { return _add_skills;}
    public DerivedStatAmt[] added_derived_stats() { return _add_d_stats; }
    public ItemAmt[] added_items() { return _add_items; }


    // Setters
    public void set_name(string name) 
    {
        if (debug.valid_string(name))
        {
            _name = name;
        }
    }
    public void set_description(string description) 
    {
        if (debug.valid_string(description))
        {
            _description = description;
        }
    }
    public void set_player_accessible(bool player_accessible) { _player_accessible = player_accessible; }
    public void set_repeat_limit(int repeat_limit) 
    {
        if (repeat_limit >= 0)
        {
            _repeat_lim = repeat_limit;
        }
    }
    public void set_repeat_every_levels(int repeat_every_levels) 
    {
        if (repeat_every_levels >= 0)
        {
            _repeat_every_levels = repeat_every_levels;
        }
    }
    public void set_required_stats(CoreStatAmt[] required_stats) 
    {
        bool invalid_integers = false;
        List<CoreStat> used_stats = new List<CoreStat>(); 

        foreach(CoreStatAmt stat in required_stats)
        {
            if (stat.amount() >= 0)
            {
                invalid_integers = true;
            }
            if (!used_stats.Contains(stat.stat()))
            {
                used_stats.Add(stat.stat());
            }
        }
        bool repeated_stats = used_stats.Count() < required_stats.Length;

        if (!repeated_stats && !invalid_integers)
        {
            _req_stats = required_stats;
        }
    }
    public void set_required_skiills(SkillAmt[] required_skills) { _req_skills = required_skills; }
    public void set_required_derived_stats(DerivedStatAmt[] required_derived_stats) { _req_d_stats = required_derived_stats; }
    public void set_required_items(ItemAmt[] required_items) { _req_items = required_items; }
    public void set_added_stats(CoreStatAmt[] added_stats) { _add_stats =  added_stats; }
    public void set_added_skills(SkillAmt[] added_skills) { _add_skills = added_skills; }
    public void set_added_derived_stats(DerivedStatAmt[] added_derived_stats) { _add_d_stats= added_derived_stats; }
    public void set_added_items(ItemAmt[] added_items) { _add_items = added_items; }


    // Constructor
    public Feature(string name, string description, bool player_accessible, int repeat_limit, int repeat_every_levels, CoreStatAmt[] required_stats, SkillAmt[] required_skills, DerivedStatAmt[] required_derived_stats, ItemAmt[] required_items, CoreStatAmt[] added_stats, SkillAmt[] added_skills, DerivedStatAmt[] added_derived_stats, ItemAmt[] added_items)
    {
        set_name(name);
        set_description(description);
        set_player_accessible(player_accessible);
        set_repeat_limit(repeat_limit);
        set_repeat_every_levels(repeat_every_levels);
        set_required_stats(required_stats);
        set_required_skiills(required_skills);
        set_required_derived_stats(required_derived_stats);
        set_required_items(required_items);
        set_added_stats(added_stats);
        set_added_skills(added_skills);
        set_added_derived_stats(added_derived_stats);
        set_added_items(added_items);
    }
}


// ITEMS
[Serializable] public class Item : ID
{
    string _name;
    string _description;
    int[] _properties;
    float _value;

    bool _weapon;
    Equation _damage;
    int _range;

    bool _augment;
    int _slot_cost;
    int[] _features;

    bool _armor;
    Equation _defense;

    bool _currency;
    bool _consumed;

    string _function_on_use;
    CoreStat[] _use_stats;

    int[] _conditions;

    public string name() { return _name; }
    public string description() { return _description; }
    public int[] properties() { return _properties; }
    public float value() { return _value; }
    public bool isWeapon() { return _weapon; }
    public Equation damage() { return _damage; }
    public int range() { return _range; }
    public bool isAugment() { return _augment; }
    public int slot_cost() {  return _slot_cost; }
    public int[] features() { return  _features; }
    public bool isArmor() { return _armor; }
    public Equation defense() { return _defense; }
    public bool isCurrency() {  return _currency; }
    public bool isConsumed() { return _consumed; }
    public string function() { return _function_on_use; }
    public CoreStat[] use_stats() { return _use_stats; }
    public int[] imbued_conditions() {  return _conditions; }
}
[Serializable] public class ItemAmt : IDAmt
{
    public ItemAmt(int id, int amount)
    {
        set_id(id);
        set_amount(amount);
    }
}


// ORIGIN ELEMENTS
[Serializable] public class OriginElement
{
    string _name;
    string _description;
    int _lvl_hp;
    CoreStat[] _stat_boost_options;
    CoreStat[] _stat_loss_options;

    int[] _skill_boost_options;
    int[] _features;

    public string name() { return _name; }
    public string description() { return _description; }
    public int hp_per_level() { return _lvl_hp; }
    public CoreStat[] stat_boost_options() { return _stat_boost_options; }
    public CoreStat[] stat_loss_options() { return _stat_loss_options; }
    public int[] skill_boost_options() { return _skill_boost_options; }
    public int[] features() {  return _features; }

    public void set_name(string name) { _name = name; }
    public void set_description(string description) { _description = description; }
    public void set_hp_per_level(int hp_per_level) { _lvl_hp = hp_per_level; }
    public void set_stat_boost_options(CoreStat[] stat_boost_options) {_stat_boost_options = stat_boost_options; }
    public void set_stat_loss_options(CoreStat[] stat_loss_options) {_stat_loss_options = stat_loss_options; }
    public void set_skill_boost_options(int[] skill_boost_options) { _skill_boost_options= skill_boost_options; }
    public void set_features(int[] features) {  _features = features; }
}
[Serializable] public class Origin_Background : OriginElement
{
    public Origin_Background(string name, string description, int hp_per_level, CoreStat[] stat_boost_options, CoreStat[] stat_loss_options, int[] skill_boost_options, int[] features)
    {
        set_name(name);
        set_description(description);
        set_hp_per_level(hp_per_level);
        set_stat_boost_options(stat_boost_options);
        set_stat_loss_options(stat_loss_options);
        set_skill_boost_options(skill_boost_options);
        set_features(features);
    }
}
[Serializable] public class Origin_Species : OriginElement
{
    public Origin_Species(string name, string description, int hp_per_level, CoreStat[] stat_boost_options, CoreStat[] stat_loss_options, int[] skill_boost_options, int[] features)
    {
        set_name(name);
        set_description(description);
        set_hp_per_level(hp_per_level);
        set_stat_boost_options(stat_boost_options);
        set_stat_loss_options(stat_loss_options);
        set_skill_boost_options(skill_boost_options);
        set_features(features);
    }
}
[Serializable] public class Origin_Class : OriginElement
{
    public Origin_Class(string name, string description, int hp_per_level, CoreStat[] stat_boost_options, CoreStat[] stat_loss_options, int[] skill_boost_options, int[] features)
    {
        set_name(name);
        set_description(description);
        set_hp_per_level(hp_per_level);
        set_stat_boost_options(stat_boost_options);
        set_stat_loss_options(stat_loss_options);
        set_skill_boost_options(skill_boost_options);
        set_features(features);
    }
}
[Serializable] public class ClassLevel : IDAmt
{

}


// CHARACTER
[Serializable] public class Character : ID
{
    string _name;
    string[] _traits;
    string _backstory;
    string[] _goals;

    int _background;
    int _species;
    ClassLevel[] _classes;
    int[] _features;

    CoreStatblock _core_stats;

    DerivedStatAmt _mhp;
    DerivedStatAmt _def;
    DerivedStatAmt _spd;

    int _hp;

    SkillAmt[] _skills;
    ItemAmt[] _items;

    public string name() { return _name; }
    public string[] traits() { return _traits; }
    public string backstory() { return _backstory; }
    public string[] goals() { return _goals; }
    public int background() { return _background; }
    public int species() { return _species; }
    public ClassLevel[] classes() { return _classes; }
    public int[] features() { return _features; }
    public CoreStatblock core_stats() { return _core_stats; }
    public DerivedStatAmt maximum_hp() { return _mhp; }
    public DerivedStatAmt defense() { return _def; }
    public DerivedStatAmt speed() { return _spd; }
    public int hp() { return _hp; }
    public SkillAmt[] skills() { return _skills; }
    public ItemAmt[] items() { return _items; }


    public void set_name(string name) { _name = name; }
    public void set_traits(string[] traits) { _traits = traits; }
    public void set_backstory(string backstory) { _backstory = backstory; }
    public void set_goals(string[] goals) { _goals = goals; }
    public void set_background(int background) { _background = background; }
    public void set_species(int species) { _species = species; }
    public void set_classes(ClassLevel[] classes) { _classes = classes; }
    public void set_features(int[] features) { _features = features; }
    public void set_core_stats(CoreStatblock core_stats) { _core_stats = core_stats; }
    public void set_maximum_hp(DerivedStatAmt mhp) { _mhp = mhp; }
    public void set_defense(DerivedStatAmt def) { _def = def; }
    public void set_speed(DerivedStatAmt spd) { _spd = spd; }
    public void set_hp(int hp) { _hp = hp; }
    public void set_skills(SkillAmt[] skills) { _skills = skills; }
    public void set_items(ItemAmt[] items) { _items = items; }

    public Character(string name, string[] traits, string backstory, string[] goals, int background, int species, ClassLevel[] classes, int[] features, CoreStatblock core_stats, DerivedStatAmt maximum_hp, DerivedStatAmt defense, DerivedStatAmt speed, int hp, SkillAmt[] skills, ItemAmt[] items)
    {
        set_name(name);
        set_traits(traits);
        set_backstory(backstory);
        set_goals(goals);
        set_background(background);
        set_species(species);
        set_classes(classes);
        set_features(features);
        set_core_stats(core_stats);
        set_maximum_hp(maximum_hp);
        set_defense(defense);
        set_speed(speed);
        set_hp(hp);
        set_skills(skills);
        set_items(items);
    }
}