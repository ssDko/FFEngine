using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace TiledEngine.DatabaseObjects
{
    class CommonEnumsAndStructs
    {

        // Not needed but leaving here
    }

    #region Enums
    public enum SkillType
    {
        None = 0,
        Magic = 1,
        Special = 2
    }

    [DataContract]
    [Flags]
    public enum GrowSpellSlot
    {
        None = 0,
        [EnumMember]
        Level1 = 1,
        [EnumMember]
        Level2 = 2,
        [EnumMember]
        Level3 = 4,
        [EnumMember]
        Level4 = 8,
        [EnumMember]
        Level5 = 16,
        [EnumMember]
        Level6 = 32,
        [EnumMember]
        Level7 = 64
    }

    [DataContract]
    [Flags]
    public enum GrowStat
    {
        None = 0,
        [EnumMember]
        Strength = 1,
        [EnumMember]
        Vitality = 2,
        [EnumMember]
        Agility = 4,
        [EnumMember]
        Luck = 8,
        [EnumMember]
        Intelligence = 16,
        [EnumMember]
        HP = 32,
        [EnumMember]
        MP = 64
    }
   
    public enum ItemType
    {
        Regular,
        KeyItem,
        HiddenItemA,
        HiddenItemB
    };

    public enum Scope
    {
        None,
        OneEnemy,
        AllEnemies,
        OneRandomEnemies,
        TwoRandomEnemies,
        ThreeRandomEnemies,
        FourRandomEnemies,
        OneAlly,
        AllAllies,
        OneAllyDead,
        AllAlliesDead,
        TheUser
    };

    public enum Occasion
    {
        Always,
        BattleScene,
        MenuScene,
        Never
    }

    public enum HitType
    {
        CertainHit,
        PhysicalHit,
        MagicalHit

    }

    public enum DamageType
    {
        None,
        HpDamage,
        MpDamage,
        HpRecover,
        MpRecover,
        HpDrain,
        MpDrain
    }

    public enum Restriction
    {
        None,
        AttackAnEnemy,
        AttackAnyone,
        AttackAnAlly,
        CannontMove
    }

    public enum BattlerStateAnimation
    {
        Normal,
        Abnormal,
        Petrified, 
        Sleeping,
        Dead
    }

    public enum BattlerStateOverlay
    {
        None, 
        Poison,
        Blind,
        Silence,
        Bezerk,
        Confusion,
        Fascination,
        Sleep,
        Paralyze
    }

    public enum AutoRemoveTiming
    {
        None,
        ActionEnd,
        TurnEnd
    }

    public enum Codes
    {
        RecoverHP,
        RecoverMp,
        AddState,
        RemoveState,
        AddBuff,
        AddDebuf,
        RemoveBuff,
        RemoveDebuf,
        SpecialEffect,
        Grow,
        LearnSkill,
        CommonEvent
    }

    public enum AnimationPosition
    {
        Head,
        Center,
        Feet,
        Screen
    }

    public enum FlashScope
    {
        None,
        Target,
        Screen,
        HideTarget
    }

    public enum Trigger
    {
        None,
        Autorun,
        Parallel
    }

    public enum TilesetLayer
    {
        A1,
        A2,
        A3,
        A4,
        A5,
        B,
        C,
        D,
        E        
    }

    public enum TilesetMode
    {
        WorldType,
        AreaType
    }

    public enum TileSize
    {
        Eight,
        Sixteen,        
        ThirtyTwo,
        FourtyEight,
        SixtyFour
    }

    public enum TilePassage
    {
        Passable,
        NonPassable,
        PassBehind //This is for when the character is supposed to pass behind the object. Instead of infront
    }
    
    public enum TilePassageDirection
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
        All = 15


    }

  
    #endregion

    #region Structs

    public struct ClassSkills
    {
        [XmlAttribute("Level")]
        public int Level;

        [XmlAttribute("ID")]
        public int SkillID;

        [XmlAttribute("Notes")]
        public string Notes;

        public ClassSkills(int level, int skillID, string notes)
        {
            Level = level;
            SkillID = skillID;
            Notes = notes;
        }
    }

    public struct IndexedGrowStat
    {
        [XmlAttribute("Level")]
        public int Level;

        [XmlAttribute("Stats")]
        public GrowStat GrowStat;

        public IndexedGrowStat(int level, GrowStat growStat)
        {
            Level = level;
            GrowStat = growStat;
        }
    }

    public struct IndexedGrowSpellSlot
    {
        [XmlAttribute("Level")]
        public int Level;

        [XmlAttribute("Slots")]
        public GrowSpellSlot GrowSpell;

        public IndexedGrowSpellSlot(int level, GrowSpellSlot growSpell)
        {
            Level = level;
            GrowSpell = growSpell;
        }

    }

    public struct EnemyAction
    {
        public int SkillID;
        public int Rating;
        public int ConditionParameter1;
        public int ConditionParameter2;
        public int ConditionType;

        public EnemyAction(int skillID, int rating, int conditionParameter1, int conditionParameter2, int conditionType)
        {
            SkillID = skillID;
            Rating = rating;
            ConditionParameter1 = conditionParameter1;
            ConditionParameter2 = conditionParameter2;
            ConditionType = conditionType;
        }
    }

    public struct BattleEventPage
    {
        //Conditions
        public int ActorHP;
        public int ActorID;
        public bool UseActor;
        public int EnemyHP;
        public int EnemyIndex;
        public bool UseEnemy;
        public int SwtichId;
        public bool UseSwitch;
        public int TurnA;
        public int TurnB;
        public bool UseTurn;
        public bool UseTurnEnding;

        public int Span;

        public List<EventCommand> CommandList;

        public BattleEventPage(int actorHP, 
                               int actorID, 
                               bool useActor, 
                               int enemyHP, 
                               int enemyIndex, 
                               bool useEnemy, 
                               int swtichId, 
                               bool useSwitch, 
                               int turnA, 
                               int turnB, 
                               bool useTurn, 
                               bool useTurnEnding, 
                               int span, List<EventCommand> commandList)
        {
            ActorHP = actorHP;
            ActorID = actorID;
            UseActor = useActor;
            EnemyHP = enemyHP;
            EnemyIndex = enemyIndex;
            UseEnemy = useEnemy;
            SwtichId = swtichId;
            UseSwitch = useSwitch;
            TurnA = turnA;
            TurnB = turnB;
            UseTurn = useTurn;
            UseTurnEnding = useTurnEnding;
            Span = span;
            CommandList = commandList;
        }
    }

    public struct EventCommand
    {
        public int Code;
        public int Indent;

        public BattleEventParameters Parameters;

        public EventCommand(int code, int indent, BattleEventParameters parameters)
        {
            Code = code;
            Indent = indent;
            Parameters = parameters;
        }
    }

    public struct BattleEventParameters
    {
        //Todo
    }    

    public struct Flash
    {
        public Color Color;
        public FlashScope Scope;
        public int Duration;

        public Flash(Color color, FlashScope scope, int duration)
        {
            Color = color;
            Scope = scope;
            Duration = duration;
        }
    }

    public struct SoundFile
    {
        public string Name;
        public int Volume;
        public int Pitch;
        public int Pan;

        public SoundFile(string name, int volume, int pitch, int pan)
        {
            Name = name;
            Volume = volume;
            Pitch = pitch;
            Pan = pan;
        }
    }

    public struct SoundFXandFlashTiming
    {
        public int Frame;
        public SoundFile SoundFile;
        public Flash Flash;

        public SoundFXandFlashTiming(int frame, SoundFile soundFile, Flash flash)
        {
            Frame = frame;
            SoundFile = soundFile;
            Flash = flash;
        }
    }

    public struct AnimationCell
    {
        public int Pattern; //The sub image of the image we use for the animation
        public int X;
        public int Y;
        public int Scale;
        public int Rotation;
        public bool Mirror;
        public int Opacity;

        public AnimationCell(int pattern, int x, int y, int scale, int rotation, bool mirror, int opacity)
        {
            Pattern = pattern;
            X = x;
            Y = y;
            Scale = scale;
            Rotation = rotation;
            Mirror = mirror;
            Opacity = opacity;
        }

        //Todo: Possibly add blending. 
    }

    public struct AnimationFrame
    {
        public List<AnimationCell> Cells;

        public AnimationFrame(List<AnimationCell> cells)
        {
            Cells = cells;
        }
    }

    #endregion
}
