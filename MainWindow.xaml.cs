using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Shapes;
using System.Xml;
using Items.Protobuf.Shared;

namespace Devm_items_editor
{
    public class Item
    {
        public Item(string name, int fromID, int toID)
        {
            Name = name;
            FromID = fromID;
            ToID = toID;

            #region Strings

            Article = string.Empty;
            Plural = string.Empty;
            Type = string.Empty;
            Description = string.Empty;
            RuneSpellName = string.Empty;
            FloorChange = string.Empty;
            CorpseType = string.Empty;
            FluidSource = string.Empty;
            WeaponType = string.Empty;
            SlotType = string.Empty;
            AmmoType = string.Empty;
            ShootType = string.Empty;
            Effect = string.Empty;
            LootType = string.Empty;
            Field_Type = string.Empty;
            PartnerDirection = string.Empty;
            EditorSuffix = string.Empty; // To-Do

            #endregion

            #region Int values

            Weight = int.MinValue;
            Armor = int.MinValue;
            Defense = int.MinValue;
            ExtraDefense = int.MinValue;
            Attack = int.MinValue;
            RotateTo = int.MinValue;
            ImbuingSlots = int.MinValue;
            WrapableTo = int.MinValue;
            ContainerSize = int.MinValue;
            MaxTextLenght = int.MinValue;
            WriteOnceItemId = int.MinValue;
            Range = int.MinValue;
            DecayTo = int.MinValue;
            EquipTo = int.MinValue;
            DequipTo = int.MinValue;
            Duration = int.MinValue;
            Charges = int.MinValue;
            HitChance = int.MinValue;
            MaxHitChance = int.MinValue;
            Speed = int.MinValue;

            HealthGain = int.MinValue;
            HealthTicks = int.MinValue;
            ManaGain = int.MinValue;
            ManaTicks = int.MinValue;

            SkillSword = int.MinValue;
            SkillAxe = int.MinValue;
            SkillClub = int.MinValue;
            SkillDistance = int.MinValue;
            SkillFish = int.MinValue;
            SkillShield = int.MinValue;
            SkillFist = int.MinValue;
            SkillCriticalChance = int.MinValue;
            SkillCriticalDamage = int.MinValue;
            SkillLifeChance = int.MinValue;
            SkillLifeAmount = int.MinValue;
            SkillManaChance = int.MinValue;
            SkillManaAmount = int.MinValue;
            MaxHitPoints = int.MinValue;
            MaxHitPointsPercent = int.MinValue;
            MaxManaPoints = int.MinValue;
            MaxManaPointsPercent = int.MinValue;
            MagicLevel = int.MinValue;
            MagicLevelPercent = int.MinValue;

            AbsorbFieldEnergy = int.MinValue;
            AbsorbFieldFire = int.MinValue;
            AbsorbFieldPoison = int.MinValue;
            AbsorbAll = int.MinValue;
            AbsorbElements = int.MinValue;
            AbsorbMagic = int.MinValue; // To-Do
            AbsorbEnergy = int.MinValue;
            AbsorbFire = int.MinValue;
            AbsorbPoison = int.MinValue;
            AbsorbIce = int.MinValue;
            AbsorbHoly = int.MinValue;
            AbsorbDeath = int.MinValue;
            AbsorbLifeDrain = int.MinValue;
            AbsorbManaDrain = int.MinValue;
            AbsorbDrown = int.MinValue;
            AbsorbPhysical = int.MinValue;
            AbsorbHealing = int.MinValue;

            FieldTicks = int.MinValue;
            FieldCount = int.MinValue;
            FieldDamage = int.MinValue;
            FieldStart = int.MinValue;

            LevelDoor = int.MinValue;
            MaleTransformTo = int.MinValue;
            FemaleTransformTo = int.MinValue;
            TransformTo = int.MinValue;
            DestroyTo = int.MinValue;

            ElementIce = int.MinValue;
            ElementEarth = int.MinValue;
            ElementFire = int.MinValue;
            ElementEnergy = int.MinValue;
            ElementDeath = int.MinValue;
            ElementHoly = int.MinValue;

            #endregion

            #region Bool values

            ShowCount = null;
            WrapContainer = null;
            Moveable = null;
            IsPodium = null;
            BlockProjectile = null;
            Pickupable = null;
            Readable = null;
            Writeable = null;
            StopDuration = null;
            ShowDuration = null;
            ShowCharges = null;
            ShowAttributes = null;
            Invisible = null;
            ManaShield = null;

            SuppressDrunk = false;
            SuppressEnergy = false;
            SuppressFire = false;
            SuppressPoison = false;
            SuppressDrown = false;
            SuppressPhysical = false;
            SuppressFreeze = false;
            SuppressDazzle = false;
            SuppressCurse = false;

            Replaceable = null;
            WalkStack = null;
            Blocking = null;
            DistanceRead = null;

            #endregion

            #region Internal
            Comments = new List<(string text, bool inside)>();
            Tag = string.Empty;
            ServerIds = new List<int>();
            #endregion
        }

        #region Internal

        public string Tag { get; set; }

        public List<(string text, bool inside)> Comments { get; set; }

        public List<int> ServerIds { get; set; }

        #endregion

        #region Strings
        public string Name { get; set; }
        public string Article { get; set; }
        public string Plural { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string RuneSpellName { get; set; }
        public string FloorChange { get; set; }
        public string CorpseType { get; set; }
        public string FluidSource { get; set; }
        public string WeaponType { get; set; }
        public string SlotType { get; set; }
        public string AmmoType { get; set; }
        public string ShootType { get; set; }
        public string Effect { get; set; }
        public string LootType { get; set; }
        public string Field_Type { get; set; }
        public string PartnerDirection { get; set; }
        public string EditorSuffix { get; set; }

        #endregion

        #region Int values
        public int FromID { get; set; }
        public int ToID { get; set; }
        public int Weight { get; set; }
        public int Armor { get; set; }
        public int Defense { get; set; }
        public int ExtraDefense { get; set; }
        public int Attack { get; set; }
        public int RotateTo { get; set; }
        public int ImbuingSlots { get; set; }
        public int WrapableTo { get; set; }
        public int ContainerSize { get; set; }
        public int MaxTextLenght { get; set; }
        public int WriteOnceItemId { get; set; }
        public int Range { get; set; }
        public int DecayTo { get; set; }
        public int EquipTo { get; set; }
        public int DequipTo { get; set; }
        public int Duration { get; set; }
        public int Charges { get; set; }
        public int HitChance { get; set; }
        public int MaxHitChance { get; set; }
        public int Speed { get; set; }

        public int HealthGain { get; set; }
        public int HealthTicks { get; set; }
        public int ManaGain { get; set; }
        public int ManaTicks { get; set; }

        public int SkillSword { get; set; }
        public int SkillAxe { get; set; }
        public int SkillClub { get; set; }
        public int SkillDistance { get; set; }
        public int SkillFish { get; set; }
        public int SkillShield { get; set; }
        public int SkillFist { get; set; }
        public int SkillCriticalChance { get; set; }
        public int SkillCriticalDamage { get; set; }
        public int SkillLifeChance { get; set; }
        public int SkillLifeAmount { get; set; }
        public int SkillManaChance { get; set; }
        public int SkillManaAmount { get; set; }
        public int MaxHitPoints { get; set; }
        public int MaxHitPointsPercent { get; set; }
        public int MaxManaPoints { get; set; }
        public int MaxManaPointsPercent { get; set; }
        public int MagicLevel { get; set; }
        public int MagicLevelPercent { get; set; }

        public int AbsorbFieldEnergy { get; set; }
        public int AbsorbFieldFire { get; set; }
        public int AbsorbFieldPoison { get; set; }
        public int AbsorbAll { get; set; }
        public int AbsorbElements { get; set; }
        public int AbsorbMagic { get; set; }
        public int AbsorbEnergy { get; set; }
        public int AbsorbFire { get; set; }
        public int AbsorbPoison { get; set; }
        public int AbsorbIce { get; set; }
        public int AbsorbHoly { get; set; }
        public int AbsorbDeath { get; set; }
        public int AbsorbLifeDrain { get; set; }
        public int AbsorbManaDrain { get; set; }
        public int AbsorbDrown { get; set; }
        public int AbsorbPhysical { get; set; }
        public int AbsorbHealing { get; set; }

        public int FieldTicks { get; set; }
        public int FieldCount { get; set; }
        public int FieldDamage { get; set; }
        public int FieldStart { get; set; }

        public int LevelDoor { get; set; }
        public int MaleTransformTo { get; set; }
        public int FemaleTransformTo { get; set; }
        public int TransformTo { get; set; }
        public int DestroyTo { get; set; }

        public int ElementIce { get; set; }
        public int ElementEarth { get; set; }
        public int ElementFire { get; set; }
        public int ElementEnergy { get; set; }
        public int ElementDeath { get; set; }
        public int ElementHoly { get; set; }

        #endregion

        #region Bool values
        public bool? ShowCount { get; set; }
        public bool? WrapContainer { get; set; }
        public bool? Moveable { get; set; }
        public bool? IsPodium { get; set; }
        public bool? BlockProjectile { get; set; }
        public bool? Pickupable { get; set; }
        public bool? Readable { get; set; }
        public bool? Writeable { get; set; }
        public bool? StopDuration { get; set; }
        public bool? ShowDuration { get; set; }
        public bool? ShowCharges { get; set; }
        public bool? ShowAttributes { get; set; }
        public bool? Invisible { get; set; }
        public bool? ManaShield { get; set; }

        public bool SuppressDrunk { get; set; }
        public bool SuppressEnergy { get; set; }
        public bool SuppressFire { get; set; }
        public bool SuppressPoison { get; set; }
        public bool SuppressDrown { get; set; }
        public bool SuppressPhysical { get; set; }
        public bool SuppressFreeze { get; set; }
        public bool SuppressDazzle { get; set; }
        public bool SuppressCurse { get; set; }

        public bool? Replaceable { get; set; }
        public bool? WalkStack { get; set; }
        public bool? Blocking { get; set; }
        public bool? DistanceRead { get; set; }

        #endregion

    }

    public class ComboBox_t
    {
        public ComboBox_t(string name, string xml)
        {
            Xml = new List<string>();

            Name = name;
            Xml.Add(xml);

            // Used only on wiki loader filter.
            FilterChecked = false;
        }
        public string Name { get; set; }
        public List<string> Xml { get; }
        public bool FilterChecked { get; set; }
    }

    public enum DamageElement_t
    {
        Physical,
        Holy,
        Death,
        Fire,
        Energy,
        Ice,
        Earth,
        Drown,
        Lifedrain,
        Poison,
        Unknown
    }

    public enum Hands_t
    {
        One,
        Two
    }

    public enum Weapon_t
    {
        Axe,
        Club,
        Sword,
        Distance
    }

    public enum SpecialChar : byte
    {
        NodeStart = 0xFE,       // 254 (OTB Only)
        EscapeChar = 0xFD,      // 253 (OTB Only)
        NodeEnd = 0xFF          // 255 (OTB Only)
    }

    public enum RootAttribute : byte
    {
        Version = 0x01
    }

    public enum ItemGroup : byte
    {
        None = 0x00,
        Ground = 0x01,
        Container = 0x02,
        Weapon = 0x03,
        Ammunition = 0x04,
        Armor = 0x05,
        Changes = 0x06,
        Teleport = 0x07,
        MagicField = 0x08,
        Writable = 0x09,
        Key = 0x0A,
        Splash = 0x0B,
        Fluid = 0x0C,
        Door = 0x0D,
        Deprecated = 0x0E
    }

    public enum ItemAttribute : byte
    {
        ServerID = 0x10,
        ClientID = 0x11,
        Name = 0x12,
        GroundSpeed = 0x14,
        SpriteHash = 0x20,
        MinimaColor = 0x21,
        MaxReadWriteChars = 0x22,
        MaxReadChars = 0x23,
        Light = 0x2A,
        StackOrder = 0x2B,
        TradeAs = 0x2D
    }

    public class BinaryTreeReader : IDisposable
        {
        #region Private Properties

        private BinaryReader reader;
        private long currentNodePosition;
        private uint currentNodeSize;

        #endregion

        #region Constructor
        public BinaryTreeReader(string path)
        {
            if (string.IsNullOrEmpty(path)) {
				throw new ArgumentNullException("input");
            }

            this.reader = new BinaryReader(new FileStream(path, FileMode.Open));
            this.Disposed = false;
        }

        #endregion

        #region Public Properties
        public bool Disposed { get; private set; }

        #endregion

        #region Public Properties
        public BinaryReader GetRootNode()
        {
            return GetChildNode();
        }

        public BinaryReader GetChildNode()
        {
            Advance();
            return GetNodeData();
        }

        public BinaryReader GetNextNode()
        {
            reader.BaseStream.Seek(currentNodePosition, SeekOrigin.Begin);

            SpecialChar value = (SpecialChar)reader.ReadByte();
            if (value != SpecialChar.NodeStart)
                return null;

            value = (SpecialChar)reader.ReadByte();

            int level = 1;
            while (true) {
                value = (SpecialChar)reader.ReadByte();
                if (value == SpecialChar.NodeEnd) {
					--level;
					if (level == 0) {
                        value = (SpecialChar)reader.ReadByte();
                        if (value == SpecialChar.NodeEnd) {
                            return null;
                        } else if (value != SpecialChar.NodeStart) {
                            return null;
                        } else {
                            currentNodePosition = reader.BaseStream.Position - 1;
                            return GetNodeData();
                        }
                    }
                } else if (value == SpecialChar.NodeStart) {
                    ++level;
                } else if (value == SpecialChar.EscapeChar) {
                    reader.ReadByte();
                }
            }
        }

        public void Dispose()
        {
            if (reader != null) {
                reader.Dispose();
                reader = null;
                Disposed = true;
            }
        }

        #endregion

        #region Private Methods
        private BinaryReader GetNodeData()
        {
            reader.BaseStream.Seek(currentNodePosition, SeekOrigin.Begin);

            // read node type
            byte value = reader.ReadByte();

            if ((SpecialChar)value != SpecialChar.NodeStart)
                return null;

            MemoryStream ms = new MemoryStream();

            currentNodeSize = 0;
            while (true) {
                value = reader.ReadByte();
                if ((SpecialChar)value == SpecialChar.NodeEnd || (SpecialChar)value == SpecialChar.NodeStart)
					break;
                else if ((SpecialChar)value == SpecialChar.EscapeChar)
                    value = reader.ReadByte();

                currentNodeSize++;
                ms.WriteByte(value);
            }

            reader.BaseStream.Seek(currentNodePosition, SeekOrigin.Begin);
            ms.Position = 0;
            return new BinaryReader(ms);
        }

        private bool Advance()
        {
            try
            {
                long seekPos = 0;
                if (currentNodePosition == 0)
                    seekPos = 4;
                else
                    seekPos = currentNodePosition;

                reader.BaseStream.Seek(seekPos, SeekOrigin.Begin);

                SpecialChar value = (SpecialChar)reader.ReadByte();
                if (value != SpecialChar.NodeStart)
					return false;

                if (currentNodePosition == 0) {
                    currentNodePosition = reader.BaseStream.Position - 1;
                    return true;
                } else {
                    value = (SpecialChar)reader.ReadByte();

                    while (true) {
                        value = (SpecialChar)reader.ReadByte();
                        if (value == SpecialChar.NodeEnd) {
                            return false;
                        } else if (value == SpecialChar.NodeStart) {
                            currentNodePosition = reader.BaseStream.Position - 1;
                            return true;
                        } else if (value == SpecialChar.EscapeChar) {
                            reader.ReadByte();
                        }
                    }
                }
            } catch (Exception) {
                return false;
            }
        }

        #endregion
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Utils

        private SolidColorBrush _greenBrush = new SolidColorBrush(Color.FromRgb(0, 200, 0));
        private SolidColorBrush _yellowBrush = new SolidColorBrush(Color.FromRgb(200, 200, 0));

        private int _lastItemId = -1;

        private string _itemsNode = "items";
        private string _itemNode = "item";
        private string _itemChildNode = "attribute";
        private string _childKey = "key";
        private string _childValue = "value";
        private string _xmlVersion = "1.0";
        private string _xmlEncoding = "ISO-8859-1";

        public string _editedTag = " - edited";
        public string _newTag = " - new";
        public string _wikiUri = "https://tibiawiki.dev/api/items/";

        private bool _hasChange = false;

        public List<(int ClientID, int ServerID)> _itemConverterList = new List<(int ClientID, int ServerID)>();

        private List<string> _error = new List<string>();

        private Grid _selectionGrid;

        public Message _message;

        public Loader _asyncLoader;

        public bool ValidateStringParseToInt(string value) {
            if (value == null || value.Length == 0)
                return false;

            foreach (char c in value) {
                if (c != '+' && c != '-' && (c < '0' || c > '9'))
                    return false;
            }

            return true;
        }
        
        public int ParseStringToFinalInt(string value, int defaultValue = int.MinValue) {
            return ValidateStringParseToInt(value) ? int.Parse(value) : defaultValue;
        }

        public bool? ParseComboBoxToFinalBool(string value) {
            if (value.ToLower() == "true") {
                return true;
            } else if (value.ToLower() == "false") {
                return false;
            } else {
                return null;
            }
        }

        public string ParseProtobufItemCategoryToLootType(ITEM_CATEGORY category)
        {
            switch (category) {
                case ITEM_CATEGORY.Armors: {
                        return "armor";
                    }
                case ITEM_CATEGORY.Amulets: {
                        return "amulet";
                    }
                case ITEM_CATEGORY.Boots: {
                        return "boots";
                    }
                case ITEM_CATEGORY.Containers: {
                        return "container";
                    }
                case ITEM_CATEGORY.Decoration: {
                        return "decoration";
                    }
                case ITEM_CATEGORY.Food: {
                        return "food";
                    }
                case ITEM_CATEGORY.HelmetsHats: {
                        return "helmet";
                    }
                case ITEM_CATEGORY.Legs: {
                        return "legs";
                    }
                case ITEM_CATEGORY.Others: {
                        return "other";
                    }
                case ITEM_CATEGORY.Potions: {
                        return "potion";
                    }
                case ITEM_CATEGORY.Rings: {
                        return "ring";
                    }
                case ITEM_CATEGORY.Runes: {
                        return "rune";
                    }
                case ITEM_CATEGORY.Shields: {
                        return "shield";
                    }
                case ITEM_CATEGORY.Tools: {
                        return "tools";
                    }
                case ITEM_CATEGORY.Valuables: {
                        return "valuable";
                    }
                case ITEM_CATEGORY.Ammunition: {
                        return "ammo";
                    }
                case ITEM_CATEGORY.Axes: {
                        return "axe";
                    }
                case ITEM_CATEGORY.Clubs: {
                        return "club";
                    }
                case ITEM_CATEGORY.DistanceWeapons: {
                        return "distance";
                    }
                case ITEM_CATEGORY.Swords: {
                        return "sword";
                    }
                case ITEM_CATEGORY.WandsRods: {
                        return "wand";
                    }
                case ITEM_CATEGORY.SpecialCoins: {
                        return "gold";
                    }
                case ITEM_CATEGORY.CreatureProducts: {
                        return "creatureproduct";
                    }
                default:
                        return "unassigned";
            }
        }

        #endregion

        #region Logging

        public void AppendLog(string text)
        {
            _error.Add(text);
        }

        public void ClearLog()
        {
            _error = new List<string>();
        }

        public void ShowLog()
        {
            if (_error.Count == 0 || _message != null) {
                return;
            }

            _message = new Message("Log window", this);

            Button closeButton = _message.CreateNewButton("Close");
            closeButton.Click += _message.Close_Click;
            closeButton.Margin = new Thickness(0, 0, 40, 0);
            
            foreach (string line in _error) {
                _message.CreateTextOnLog(line);
            }

            _message.Show();
        }

        #endregion

        #region Items declarations

        public int GetItemServerIDByClientID(int clientId)
        {
            foreach (var tuple in _itemConverterList) {
                if (tuple.ClientID == clientId) {
                    return tuple.ServerID;
                }
            }

            return int.MinValue;
        }

        public Item GetItemByID(int id, bool forceClient = false)
        {
            int finalId = id;
            if (forceClient && _itemConverterList.Count > 0) {
                finalId = GetItemServerIDByClientID(id);
            }

            foreach (Item listItem in ItemsList.Items) {
                if (listItem.FromID <= finalId && listItem.ToID >= finalId) {
                    return listItem;
                }
            }

            return null;
        }

        public void SelectItem()
        {
            Item item = GetItemByID((int)_selectionGrid.DataContext);
            
            if (item == null) {
                return;
            }

            #region Strings

            ItemName.Text = item.Name;
            Article.Text = item.Article;
            Plural.Text = item.Plural;
            Description.Text = item.Description;
            EditorSufix.Text = item.EditorSuffix;
            RuneSpell.Text = item.RuneSpellName;

            foreach (ComboBox_t type in Type.Items) {
                if (item.Type.Length == 0) {
                    if (type.Xml[0].Length == 0) {
                        Type.SelectedItem = type;
                        break;
                    }
                } else if (type.Xml.Contains(item.Type)) {
                    Type.SelectedItem = type;
                    break;
                }
            }
            
            foreach (ComboBox_t floorChange in FloorChange.Items) {
                if (item.FloorChange.Length == 0) {
                    if (floorChange.Xml[0].Length == 0) {
                        FloorChange.SelectedItem = floorChange;
                        break;
                    }
                } else if (floorChange.Xml.Contains(item.FloorChange)) {
                    FloorChange.SelectedItem = floorChange;
                    break;
                }
            }
            
            foreach (ComboBox_t corpseType in CorpseType.Items) {
                if (item.CorpseType.Length == 0) {
                    if (corpseType.Xml[0].Length == 0) {
                        CorpseType.SelectedItem = corpseType;
                        break;
                    }
                } else if (corpseType.Xml.Contains(item.CorpseType)) {
                    CorpseType.SelectedItem = corpseType;
                    break;
                }
            }
            
            foreach (ComboBox_t fluidSource in FluidSource.Items) {
                if (item.FluidSource.Length == 0) {
                    if (fluidSource.Xml[0].Length == 0) {
                        FluidSource.SelectedItem = fluidSource;
                        break;
                    }
                } else if (fluidSource.Xml.Contains(item.FluidSource)) {
                    FluidSource.SelectedItem = fluidSource;
                    break;
                }
            }
            
            foreach (ComboBox_t weaponType in WeaponType.Items) {
                if (item.WeaponType.Length == 0) {
                    if (weaponType.Xml[0].Length == 0) {
                        WeaponType.SelectedItem = weaponType;
                        break;
                    }
                } else if (weaponType.Xml.Contains(item.WeaponType)) {
                    WeaponType.SelectedItem = weaponType;
                    break;
                }
            }
            
            foreach (ComboBox_t slotType in SlotType.Items) {
                if (item.SlotType.Length == 0) {
                    if (slotType.Xml[0].Length == 0) {
                        SlotType.SelectedItem = slotType;
                        break;
                    }
                } else if (slotType.Xml.Contains(item.SlotType)) {
                    SlotType.SelectedItem = slotType;
                    break;
                }
            }
            
            foreach (ComboBox_t ammoType in AmmoType.Items) {
                if (item.AmmoType.Length == 0) {
                    if (ammoType.Xml[0].Length == 0) {
                        AmmoType.SelectedItem = ammoType;
                        break;
                    }
                } else if (ammoType.Xml.Contains(item.AmmoType)) {
                    AmmoType.SelectedItem = ammoType;
                    break;
                }
            }
            
            foreach (ComboBox_t shootType in ShootType.Items) {
                if (item.ShootType.Length == 0) {
                    if (shootType.Xml[0].Length == 0) {
                        ShootType.SelectedItem = shootType;
                        break;
                    }
                } else if (shootType.Xml.Contains(item.ShootType)) {
                    ShootType.SelectedItem = shootType;
                    break;
                }
            }
            
            foreach (ComboBox_t magicEffect in MagicEffect.Items) {
                if (item.Effect.Length == 0) {
                    if (magicEffect.Xml[0].Length == 0) {
                        MagicEffect.SelectedItem = magicEffect;
                        break;
                    }
                } else if (magicEffect.Xml.Contains(item.Effect)) {
                    MagicEffect.SelectedItem = magicEffect;
                    break;
                }
            }
            
            foreach (ComboBox_t lootType in LootType.Items) {
                if (item.LootType.Length == 0) {
                    if (lootType.Xml[0].Length == 0) {
                        LootType.SelectedItem = lootType;
                        break;
                    }
                } else if (lootType.Xml.Contains(item.LootType)) {
                    LootType.SelectedItem = lootType;
                    break;
                }
            }
            
            foreach (ComboBox_t fieldType in FieldType.Items) {
                if (item.Field_Type.Length == 0) {
                    if (fieldType.Xml[0].Length == 0) {
                        FieldType.SelectedItem = fieldType;
                        break;
                    }
                } else if (fieldType.Xml.Contains(item.Field_Type)) {
                    FieldType.SelectedItem = fieldType;
                    break;
                }
            }
            
            foreach (ComboBox_t partnerDirecttion in PartnerDirection.Items) {
                if (item.PartnerDirection.Length == 0) {
                    if (partnerDirecttion.Xml[0].Length == 0) {
                        PartnerDirection.SelectedItem = partnerDirecttion;
                        break;
                    }
                } else if (partnerDirecttion.Xml.Contains(item.PartnerDirection)) {
                    PartnerDirection.SelectedItem = partnerDirecttion;
                    break;
                }
            }

            #endregion

            #region Integrer

            FromID.Text = item.FromID.ToString();
            ToID.Text = item.ToID.ToString();
            Weight.Text = item.Weight != int.MinValue ? item.Weight.ToString() : string.Empty;
            Armor.Text = item.Armor != int.MinValue ? item.Armor.ToString() : string.Empty;
            Defense.Text = item.Defense != int.MinValue ? item.Defense.ToString() : string.Empty;
            ExtraDefense.Text = item.ExtraDefense != int.MinValue ? item.ExtraDefense.ToString() : string.Empty;
            Attack.Text = item.Attack != int.MinValue ? item.Attack.ToString() : string.Empty;
            RotateTo.Text = item.RotateTo != int.MinValue ? item.RotateTo.ToString() : string.Empty;
            ImbueSlots.Text = item.ImbuingSlots != int.MinValue ? item.ImbuingSlots.ToString() : string.Empty;
            WrapTo.Text = item.WrapableTo != int.MinValue ? item.WrapableTo.ToString() : string.Empty;
            ContainerSize.Text = item.ContainerSize != int.MinValue ? item.ContainerSize.ToString() : string.Empty;
            MaxTextLenght.Text = item.MaxTextLenght != int.MinValue ? item.MaxTextLenght.ToString() : string.Empty;
            WritingID.Text = item.WriteOnceItemId != int.MinValue ? item.WriteOnceItemId.ToString() : string.Empty;
            Range.Text = item.Range != int.MinValue ? item.Range.ToString() : string.Empty;
            DecayTo.Text = item.DecayTo != int.MinValue ? item.DecayTo.ToString() : string.Empty;
            EquipTo.Text = item.EquipTo != int.MinValue ? item.EquipTo.ToString() : string.Empty;
            DequipTo.Text = item.DequipTo != int.MinValue ? item.DequipTo.ToString() : string.Empty;
            Duration.Text = item.Duration != int.MinValue ? item.Duration.ToString() : string.Empty;
            Charges.Text = item.Charges != int.MinValue ? item.Charges.ToString() : string.Empty;
            HitChance.Text = item.HitChance != int.MinValue ? item.HitChance.ToString() : string.Empty;
            MaxHitChance.Text = item.MaxHitChance != int.MinValue ? item.MaxHitChance.ToString() : string.Empty;
            Speed.Text = item.Speed != int.MinValue ? item.Speed.ToString() : string.Empty;

            HealthGain.Text = item.HealthGain != int.MinValue ? item.HealthGain.ToString() : string.Empty;
            HealthTicks.Text = item.HealthTicks != int.MinValue ? item.HealthTicks.ToString() : string.Empty;
            ManaGain.Text = item.ManaGain != int.MinValue ? item.ManaGain.ToString() : string.Empty;
            ManaTicks.Text = item.ManaTicks != int.MinValue ? item.ManaTicks.ToString() : string.Empty;

            SkillSword.Text = item.SkillSword != int.MinValue ? item.SkillSword.ToString() : string.Empty;
            SkillAxe.Text = item.SkillAxe != int.MinValue ? item.SkillAxe.ToString() : string.Empty;
            SkillClub.Text = item.SkillClub != int.MinValue ? item.SkillClub.ToString() : string.Empty;
            SkillDistance.Text = item.SkillDistance != int.MinValue ? item.SkillDistance.ToString() : string.Empty;
            SkillFish.Text = item.SkillFish != int.MinValue ? item.SkillFish.ToString() : string.Empty;
            SkillShield.Text = item.SkillShield != int.MinValue ? item.SkillShield.ToString() : string.Empty;
            SkillFist.Text = item.SkillFist != int.MinValue ? item.SkillFist.ToString() : string.Empty;
            SkillCriticalChance.Text = item.SkillCriticalChance != int.MinValue ? item.SkillCriticalChance.ToString() : string.Empty;
            SkillCriticalDamage.Text = item.SkillCriticalDamage != int.MinValue ? item.SkillCriticalDamage.ToString() : string.Empty;
            SkillLifeLeechChance.Text = item.SkillLifeChance != int.MinValue ? item.SkillLifeChance.ToString() : string.Empty;
            SkillLifeLeechAmount.Text = item.SkillLifeAmount != int.MinValue ? item.SkillLifeAmount.ToString() : string.Empty;
            SkillManaLeechChance.Text = item.SkillManaChance != int.MinValue ? item.SkillManaChance.ToString() : string.Empty;
            SkillManaLeechAmount.Text = item.SkillManaAmount != int.MinValue ? item.SkillManaAmount.ToString() : string.Empty;
            SkillMaxHitPoints.Text = item.MaxHitPoints != int.MinValue ? item.MaxHitPoints.ToString() : string.Empty;
            SkillMaxHitPointsPercent.Text = item.MaxHitPointsPercent != int.MinValue ? item.MaxHitPointsPercent.ToString() : string.Empty;
            SkillMaxManaPoints.Text = item.MaxManaPoints != int.MinValue ? item.MaxManaPoints.ToString() : string.Empty;
            SkillMaxManaPointsPercent.Text = item.MaxManaPointsPercent != int.MinValue ? item.MaxManaPointsPercent.ToString() : string.Empty;
            SkillMagicLevelAmount.Text = item.MagicLevel != int.MinValue ? item.MagicLevel.ToString() : string.Empty;
            SkillMagicLevelPercent.Text = item.MagicLevelPercent != int.MinValue ? item.MagicLevelPercent.ToString() : string.Empty;

            AbsorbFieldEnergy.Text = item.AbsorbFieldEnergy != int.MinValue ? item.AbsorbFieldEnergy.ToString() : string.Empty;
            AbsorbFieldFire.Text = item.AbsorbFieldFire != int.MinValue ? item.AbsorbFieldFire.ToString() : string.Empty;
            AbsorbFieldPoison.Text = item.AbsorbFieldPoison != int.MinValue ? item.AbsorbFieldPoison.ToString() : string.Empty;
            AbsorbAll.Text = item.AbsorbAll != int.MinValue ? item.AbsorbAll.ToString() : string.Empty;
            AbsorbElements.Text = item.AbsorbElements != int.MinValue ? item.AbsorbElements.ToString() : string.Empty;
            AbsorbMagics.Text = item.AbsorbMagic != int.MinValue ? item.AbsorbMagic.ToString() : string.Empty;
            AbsorbEnergy.Text = item.AbsorbEnergy != int.MinValue ? item.AbsorbEnergy.ToString() : string.Empty;
            AbsorbFire.Text = item.AbsorbFire != int.MinValue ? item.AbsorbFire.ToString() : string.Empty;
            AbsorbEarth.Text = item.AbsorbPoison != int.MinValue ? item.AbsorbPoison.ToString() : string.Empty;
            AbsorbIce.Text = item.AbsorbIce != int.MinValue ? item.AbsorbIce.ToString() : string.Empty;
            AbsorbHoly.Text = item.AbsorbHoly != int.MinValue ? item.AbsorbHoly.ToString() : string.Empty;
            AbsorbDeath.Text = item.AbsorbDeath != int.MinValue ? item.AbsorbDeath.ToString() : string.Empty;
            AbsorbLifeDrain.Text = item.AbsorbLifeDrain != int.MinValue ? item.AbsorbLifeDrain.ToString() : string.Empty;
            AbsorbManaDrain.Text = item.AbsorbManaDrain != int.MinValue ? item.AbsorbManaDrain.ToString() : string.Empty;
            AbsorbDrown.Text = item.AbsorbDrown != int.MinValue ? item.AbsorbDrown.ToString() : string.Empty;
            AbsorbPhysical.Text = item.AbsorbPhysical != int.MinValue ? item.AbsorbPhysical.ToString() : string.Empty;
            AbsorbHealing.Text = item.AbsorbHealing != int.MinValue ? item.AbsorbHealing.ToString() : string.Empty;
            AbsorbMagics.Text = item.AbsorbMagic != int.MinValue ? item.AbsorbMagic.ToString() : string.Empty;

            FieldTicks.Text = item.FieldTicks != int.MinValue ? item.FieldTicks.ToString() : string.Empty;
            FieldCount.Text = item.FieldCount != int.MinValue ? item.FieldCount.ToString() : string.Empty;
            FieldDamage.Text = item.FieldDamage != int.MinValue ? item.FieldDamage.ToString() : string.Empty;
            FieldStart.Text = item.FieldStart != int.MinValue ? item.FieldStart.ToString() : string.Empty;

            LevelDoor.Text = item.LevelDoor != int.MinValue ? item.LevelDoor.ToString() : string.Empty;
            MaleBed.Text = item.MaleTransformTo != int.MinValue ? item.MaleTransformTo.ToString() : string.Empty;
            FemaleBed.Text = item.FemaleTransformTo != int.MinValue ? item.FemaleTransformTo.ToString() : string.Empty;
            TransformTo.Text = item.TransformTo != int.MinValue ? item.TransformTo.ToString() : string.Empty;
            DestroyTo.Text = item.DestroyTo != int.MinValue ? item.DestroyTo.ToString() : string.Empty;

            ElementIce.Text = item.ElementIce != int.MinValue ? item.ElementIce.ToString() : string.Empty;
            ElementEarth.Text = item.ElementEarth != int.MinValue ? item.ElementEarth.ToString() : string.Empty;
            ElementFire.Text = item.ElementFire != int.MinValue ? item.ElementFire.ToString() : string.Empty;
            ElementEnergy.Text = item.ElementEnergy != int.MinValue ? item.ElementEnergy.ToString() : string.Empty;
            ElementDeath.Text = item.ElementDeath != int.MinValue ? item.ElementDeath.ToString() : string.Empty;
            ElementHoly.Text = item.ElementHoly != int.MinValue ? item.ElementHoly.ToString() : string.Empty;

            #endregion

            #region Boolean
            
            foreach (ComboBoxItem showCount in ShowCount.Items) {
	            if (item.ShowCount == null) {
		            if (showCount.Content.ToString() == "-") {
                        ShowCount.SelectedItem = showCount;
			            break;
		            }
	            } else if (showCount.Content.ToString() == item.ShowCount.ToString()) {
                    ShowCount.SelectedItem = showCount;
		            break;
	            }
            }
            
            foreach (ComboBoxItem wrapContainer in WrapContainer.Items) {
	            if (item.WrapContainer == null) {
		            if (wrapContainer.Content.ToString() == "-") {
                        WrapContainer.SelectedItem = wrapContainer;
			            break;
		            }
	            } else if (wrapContainer.Content.ToString() == item.WrapContainer.ToString()) {
                    WrapContainer.SelectedItem = wrapContainer;
		            break;
	            }
            }
            
            foreach (ComboBoxItem moveable in Moveable.Items) {
	            if (item.Moveable == null) {
		            if (moveable.Content.ToString() == "-") {
                        Moveable.SelectedItem = moveable;
			            break;
		            }
	            } else if (moveable.Content.ToString() == item.Moveable.ToString()) {
                    Moveable.SelectedItem = moveable;
		            break;
	            }
            }
            
            foreach (ComboBoxItem podium in Podium.Items) {
	            if (item.IsPodium == null) {
		            if (podium.Content.ToString() == "-") {
                        Podium.SelectedItem = podium;
			            break;
		            }
	            } else if (podium.Content.ToString() == item.IsPodium.ToString()) {
                    Podium.SelectedItem = podium;
		            break;
	            }
            }
            
            foreach (ComboBoxItem blockProjectile in BlockProjectile.Items) {
	            if (item.BlockProjectile == null) {
		            if (blockProjectile.Content.ToString() == "-") {
                        BlockProjectile.SelectedItem = blockProjectile;
			            break;
		            }
	            } else if (blockProjectile.Content.ToString() == item.BlockProjectile.ToString()) {
                    BlockProjectile.SelectedItem = blockProjectile;
		            break;
	            }
            }
            
            foreach (ComboBoxItem pickupable in Pickupable.Items) {
	            if (item.Pickupable == null) {
		            if (pickupable.Content.ToString() == "-") {
                        Pickupable.SelectedItem = pickupable;
			            break;
		            }
	            } else if (pickupable.Content.ToString() == item.Pickupable.ToString()) {
                    Pickupable.SelectedItem = pickupable;
		            break;
	            }
            }
            
            foreach (ComboBoxItem readable in Readable.Items) {
	            if (item.Readable == null) {
		            if (readable.Content.ToString() == "-") {
                        Readable.SelectedItem = readable;
			            break;
		            }
	            } else if (readable.Content.ToString() == item.Readable.ToString()) {
                    Readable.SelectedItem = readable;
		            break;
	            }
            }
            
            foreach (ComboBoxItem writeable in Writeable.Items) {
	            if (item.Writeable == null) {
		            if (writeable.Content.ToString() == "-") {
                        Writeable.SelectedItem = writeable;
			            break;
		            }
	            } else if (writeable.Content.ToString() == item.Writeable.ToString()) {
                    Writeable.SelectedItem = writeable;
		            break;
	            }
            }
            
            foreach (ComboBoxItem stopDuration in StopDuration.Items) {
	            if (item.StopDuration == null) {
		            if (stopDuration.Content.ToString() == "-") {
                        StopDuration.SelectedItem = stopDuration;
			            break;
		            }
	            } else if (stopDuration.Content.ToString() == item.StopDuration.ToString()) {
                    StopDuration.SelectedItem = stopDuration;
		            break;
	            }
            }
            
            foreach (ComboBoxItem showDuration in ShowDuration.Items) {
	            if (item.ShowDuration == null) {
		            if (showDuration.Content.ToString() == "-") {
                        ShowDuration.SelectedItem = showDuration;
			            break;
		            }
	            } else if (showDuration.Content.ToString() == item.ShowDuration.ToString()) {
                    ShowDuration.SelectedItem = showDuration;
		            break;
	            }
            }
            
            foreach (ComboBoxItem showCharges in ShowCharges.Items) {
	            if (item.ShowCharges == null) {
		            if (showCharges.Content.ToString() == "-") {
                        ShowCharges.SelectedItem = showCharges;
			            break;
		            }
	            } else if (showCharges.Content.ToString() == item.ShowCharges.ToString()) {
                    ShowCharges.SelectedItem = showCharges;
		            break;
	            }
            }
            
            foreach (ComboBoxItem showAttributes in ShowAttributes.Items) {
	            if (item.ShowAttributes == null) {
		            if (showAttributes.Content.ToString() == "-") {
                        ShowAttributes.SelectedItem = showAttributes;
			            break;
		            }
	            } else if (showAttributes.Content.ToString() == item.ShowAttributes.ToString()) {
                    ShowAttributes.SelectedItem = showAttributes;
		            break;
	            }
            }
            
            foreach (ComboBoxItem invisible in Invisible.Items) {
	            if (item.Invisible == null) {
		            if (invisible.Content.ToString() == "-") {
                        Invisible.SelectedItem = invisible;
			            break;
		            }
	            } else if (invisible.Content.ToString() == item.Invisible.ToString()) {
                    Invisible.SelectedItem = invisible;
		            break;
	            }
            }
            
            foreach (ComboBoxItem manaShield in ManaShield.Items) {
	            if (item.ManaShield == null) {
		            if (manaShield.Content.ToString() == "-") {
                        ManaShield.SelectedItem = manaShield;
			            break;
		            }
	            } else if (manaShield.Content.ToString() == item.ManaShield.ToString()) {
                    ManaShield.SelectedItem = manaShield;
		            break;
	            }
            }
            
            foreach (ComboBoxItem replaceable in Replaceable.Items) {
	            if (item.Replaceable == null) {
		            if (replaceable.Content.ToString() == "-") {
                        Replaceable.SelectedItem = replaceable;
			            break;
		            }
	            } else if (replaceable.Content.ToString() == item.Replaceable.ToString()) {
                    Replaceable.SelectedItem = replaceable;
		            break;
	            }
            }
            
            foreach (ComboBoxItem walkStack in WalkStack.Items) {
	            if (item.WalkStack == null) {
		            if (walkStack.Content.ToString() == "-") {
                        WalkStack.SelectedItem = walkStack;
			            break;
		            }
	            } else if (walkStack.Content.ToString() == item.WalkStack.ToString()) {
                    WalkStack.SelectedItem = walkStack;
		            break;
	            }
            }
            
            foreach (ComboBoxItem blocking in Blocking.Items) {
	            if (item.Blocking == null) {
		            if (blocking.Content.ToString() == "-") {
                        Blocking.SelectedItem = blocking;
			            break;
		            }
	            } else if (blocking.Content.ToString() == item.Blocking.ToString()) {
                    Blocking.SelectedItem = blocking;
		            break;
	            }
            }
            
            foreach (ComboBoxItem distantRead in DistantRead.Items) {
	            if (item.DistanceRead == null) {
		            if (distantRead.Content.ToString() == "-") {
                        DistantRead.SelectedItem = distantRead;
			            break;
		            }
	            } else if (distantRead.Content.ToString() == item.DistanceRead.ToString()) {
                    DistantRead.SelectedItem = distantRead;
		            break;
	            }
            }

            SupressDrunk.IsChecked = item.SuppressDrunk;
            SupressEnergy.IsChecked = item.SuppressEnergy;
            SupressFire.IsChecked = item.SuppressFire;
            SupressPoison.IsChecked = item.SuppressPoison;
            SupressDrown.IsChecked = item.SuppressDrown;
            SupressPhysical.IsChecked = item.SuppressPhysical;
            SupressFreeze.IsChecked = item.SuppressFreeze;
            SupressDazzle.IsChecked = item.SuppressDazzle;
            SupressCurse.IsChecked = item.SuppressCurse;

            #endregion

            _hasChange = false;
            SaveItemButton.IsEnabled = false;
        }

        public void SaveItem()
        {
            Item item = GetItemByID((int)_selectionGrid.DataContext);

            if (item == null) {
                return;
            }

            #region Strings

            item.Name = ItemName.Text;
            item.Article = Article.Text;
            item.Plural = Plural.Text;
            item.Description = Description.Text;
            item.EditorSuffix = EditorSufix.Text;
            item.RuneSpellName = RuneSpell.Text;

            item.Type = ((ComboBox_t)Type.SelectedItem).Xml[0];
            item.FloorChange = ((ComboBox_t)FloorChange.SelectedItem).Xml[0];
            item.CorpseType = ((ComboBox_t)CorpseType.SelectedItem).Xml[0];
            item.FluidSource = ((ComboBox_t)FluidSource.SelectedItem).Xml[0];
            item.WeaponType = ((ComboBox_t)WeaponType.SelectedItem).Xml[0];
            item.SlotType = ((ComboBox_t)SlotType.SelectedItem).Xml[0];
            item.AmmoType = ((ComboBox_t)AmmoType.SelectedItem).Xml[0];
            item.ShootType = ((ComboBox_t)ShootType.SelectedItem).Xml[0];
            item.Effect = ((ComboBox_t)MagicEffect.SelectedItem).Xml[0];
            item.LootType = ((ComboBox_t)LootType.SelectedItem).Xml[0];
            item.Field_Type = ((ComboBox_t)FieldType.SelectedItem).Xml[0];
            item.PartnerDirection = ((ComboBox_t)PartnerDirection.SelectedItem).Xml[0];

            #endregion

            #region Integrer

            item.FromID = ValidateStringParseToInt(FromID.Text) ? int.Parse(FromID.Text) : item.FromID;
            item.ToID = ValidateStringParseToInt(ToID.Text) ? int.Parse(ToID.Text) : item.ToID;
            item.Weight = ParseStringToFinalInt(Weight.Text);
            item.Armor = ParseStringToFinalInt(Armor.Text);
            item.Defense = ParseStringToFinalInt(Defense.Text);
            item.ExtraDefense = ParseStringToFinalInt(ExtraDefense.Text);
            item.Attack = ParseStringToFinalInt(Attack.Text);
            item.RotateTo = ParseStringToFinalInt(RotateTo.Text);
            item.ImbuingSlots = ParseStringToFinalInt(ImbueSlots.Text);
            item.WrapableTo = ParseStringToFinalInt(WrapTo.Text);
            item.ContainerSize = ParseStringToFinalInt(ContainerSize.Text);
            item.MaxTextLenght = ParseStringToFinalInt(MaxTextLenght.Text);
            item.WriteOnceItemId = ParseStringToFinalInt(WritingID.Text);
            item.Range = ParseStringToFinalInt(Range.Text);
            item.DecayTo = ParseStringToFinalInt(DecayTo.Text);
            item.EquipTo = ParseStringToFinalInt(EquipTo.Text);
            item.DequipTo = ParseStringToFinalInt(DequipTo.Text);
            item.Duration = ParseStringToFinalInt(Duration.Text);
            item.Charges = ParseStringToFinalInt(Charges.Text);
            item.HitChance = ParseStringToFinalInt(HitChance.Text);
            item.MaxHitChance = ParseStringToFinalInt(MaxHitChance.Text);
            item.Speed = ParseStringToFinalInt(Speed.Text);

            item.HealthGain = ParseStringToFinalInt(HealthGain.Text);
            item.HealthTicks = ParseStringToFinalInt(HealthTicks.Text);
            item.ManaGain = ParseStringToFinalInt(ManaGain.Text);
            item.ManaTicks = ParseStringToFinalInt(ManaTicks.Text);

            item.SkillSword = ParseStringToFinalInt(SkillSword.Text);
            item.SkillAxe = ParseStringToFinalInt(SkillAxe.Text);
            item.SkillClub = ParseStringToFinalInt(SkillClub.Text);
            item.SkillDistance = ParseStringToFinalInt(SkillDistance.Text);
            item.SkillFish = ParseStringToFinalInt(SkillFish.Text);
            item.SkillShield = ParseStringToFinalInt(SkillShield.Text);
            item.SkillFist = ParseStringToFinalInt(SkillFist.Text);
            item.SkillCriticalChance = ParseStringToFinalInt(SkillCriticalChance.Text);
            item.SkillCriticalDamage = ParseStringToFinalInt(SkillCriticalDamage.Text);
            item.SkillLifeChance = ParseStringToFinalInt(SkillLifeLeechChance.Text);
            item.SkillLifeAmount = ParseStringToFinalInt(SkillLifeLeechAmount.Text);
            item.SkillManaChance = ParseStringToFinalInt(SkillManaLeechChance.Text);
            item.SkillManaAmount = ParseStringToFinalInt(SkillManaLeechAmount.Text);
            item.MaxHitPoints = ParseStringToFinalInt(SkillMaxHitPoints.Text);
            item.MaxHitPointsPercent = ParseStringToFinalInt(SkillMaxHitPointsPercent.Text);
            item.MaxManaPoints = ParseStringToFinalInt(SkillMaxManaPoints.Text);
            item.MaxManaPointsPercent = ParseStringToFinalInt(SkillMaxManaPointsPercent.Text);
            item.MagicLevel = ParseStringToFinalInt(SkillMagicLevelAmount.Text);
            item.MagicLevelPercent = ParseStringToFinalInt(SkillMagicLevelPercent.Text);

            item.AbsorbFieldEnergy = ParseStringToFinalInt(AbsorbFieldEnergy.Text);
            item.AbsorbFieldFire = ParseStringToFinalInt(AbsorbFieldFire.Text);
            item.AbsorbFieldPoison = ParseStringToFinalInt(AbsorbFieldPoison.Text);
            item.AbsorbAll = ParseStringToFinalInt(AbsorbAll.Text);
            item.AbsorbElements = ParseStringToFinalInt(AbsorbElements.Text);
            item.AbsorbMagic = ParseStringToFinalInt(AbsorbMagics.Text);
            item.AbsorbEnergy = ParseStringToFinalInt(AbsorbEnergy.Text);
            item.AbsorbFire = ParseStringToFinalInt(AbsorbFire.Text);
            item.AbsorbPoison = ParseStringToFinalInt(AbsorbEarth.Text);
            item.AbsorbIce = ParseStringToFinalInt(AbsorbIce.Text);
            item.AbsorbHoly = ParseStringToFinalInt(AbsorbHoly.Text);
            item.AbsorbDeath = ParseStringToFinalInt(AbsorbDeath.Text);
            item.AbsorbLifeDrain = ParseStringToFinalInt(AbsorbLifeDrain.Text);
            item.AbsorbManaDrain = ParseStringToFinalInt(AbsorbManaDrain.Text);
            item.AbsorbDrown = ParseStringToFinalInt(AbsorbDrown.Text);
            item.AbsorbPhysical = ParseStringToFinalInt(AbsorbPhysical.Text);
            item.AbsorbHealing = ParseStringToFinalInt(AbsorbHealing.Text);
            item.AbsorbMagic = ParseStringToFinalInt(AbsorbMagics.Text);

            item.FieldTicks = ParseStringToFinalInt(FieldTicks.Text);
            item.FieldCount = ParseStringToFinalInt(FieldCount.Text);
            item.FieldDamage = ParseStringToFinalInt(FieldDamage.Text);
            item.FieldStart = ParseStringToFinalInt(FieldStart.Text);

            item.LevelDoor = ParseStringToFinalInt(LevelDoor.Text);
            item.MaleTransformTo = ParseStringToFinalInt(MaleBed.Text);
            item.FemaleTransformTo = ParseStringToFinalInt(FemaleBed.Text);
            item.TransformTo = ParseStringToFinalInt(TransformTo.Text);
            item.DestroyTo = ParseStringToFinalInt(DestroyTo.Text);

            item.ElementIce = ParseStringToFinalInt(ElementIce.Text);
            item.ElementEarth = ParseStringToFinalInt(ElementEarth.Text);
            item.ElementFire = ParseStringToFinalInt(ElementFire.Text);
            item.ElementEnergy = ParseStringToFinalInt(ElementEnergy.Text);
            item.ElementDeath = ParseStringToFinalInt(ElementDeath.Text);
            item.ElementHoly = ParseStringToFinalInt(ElementHoly.Text);

            #endregion

            #region Boolean

            item.ShowCount = ParseComboBoxToFinalBool(((ComboBoxItem)ShowCount.SelectedItem).Content.ToString());
            item.WrapContainer = ParseComboBoxToFinalBool(((ComboBoxItem)WrapContainer.SelectedItem).Content.ToString());
            item.Moveable = ParseComboBoxToFinalBool(((ComboBoxItem)Moveable.SelectedItem).Content.ToString());
            item.IsPodium = ParseComboBoxToFinalBool(((ComboBoxItem)Podium.SelectedItem).Content.ToString());
            item.BlockProjectile = ParseComboBoxToFinalBool(((ComboBoxItem)BlockProjectile.SelectedItem).Content.ToString());
            item.Pickupable = ParseComboBoxToFinalBool(((ComboBoxItem)Pickupable.SelectedItem).Content.ToString());
            item.Readable = ParseComboBoxToFinalBool(((ComboBoxItem)Readable.SelectedItem).Content.ToString());
            item.Writeable = ParseComboBoxToFinalBool(((ComboBoxItem)Writeable.SelectedItem).Content.ToString());
            item.StopDuration = ParseComboBoxToFinalBool(((ComboBoxItem)StopDuration.SelectedItem).Content.ToString());
            item.ShowDuration = ParseComboBoxToFinalBool(((ComboBoxItem)ShowDuration.SelectedItem).Content.ToString());
            item.ShowCharges = ParseComboBoxToFinalBool(((ComboBoxItem)ShowCharges.SelectedItem).Content.ToString());
            item.ShowAttributes = ParseComboBoxToFinalBool(((ComboBoxItem)ShowAttributes.SelectedItem).Content.ToString());
            item.Invisible = ParseComboBoxToFinalBool(((ComboBoxItem)Invisible.SelectedItem).Content.ToString());
            item.ManaShield = ParseComboBoxToFinalBool(((ComboBoxItem)ManaShield.SelectedItem).Content.ToString());
            item.Replaceable = ParseComboBoxToFinalBool(((ComboBoxItem)Replaceable.SelectedItem).Content.ToString());
            item.WalkStack = ParseComboBoxToFinalBool(((ComboBoxItem)WalkStack.SelectedItem).Content.ToString());
            item.Blocking = ParseComboBoxToFinalBool(((ComboBoxItem)Blocking.SelectedItem).Content.ToString());
            item.DistanceRead = ParseComboBoxToFinalBool(((ComboBoxItem)DistantRead.SelectedItem).Content.ToString());

            item.SuppressDrunk = (bool)SupressDrunk.IsChecked;
            item.SuppressEnergy = (bool)SupressEnergy.IsChecked;
            item.SuppressFire = (bool)SupressFire.IsChecked;
            item.SuppressPoison = (bool)SupressPoison.IsChecked;
            item.SuppressDrown = (bool)SupressDrown.IsChecked;
            item.SuppressPhysical = (bool)SupressPhysical.IsChecked;
            item.SuppressFreeze = (bool)SupressFreeze.IsChecked;
            item.SuppressDazzle = (bool)SupressDazzle.IsChecked;
            item.SuppressCurse = (bool)SupressCurse.IsChecked;

            #endregion

            if (item.Tag.Length == 0) {
                item.Tag = _editedTag;
            }

            _hasChange = false;
            SaveItemButton.IsEnabled = false;

            ItemsList.BeginInit();
            ItemsList.Items.Refresh();
            ItemsList.EndInit();
        }

        public Item CreateNewItem(int itemId, string name, string description, bool sameThread = true, bool forceClient = false)
        {
            int finalId = itemId;
            if (forceClient && _itemConverterList.Count > 0) {
                finalId = GetItemServerIDByClientID(itemId);
            }

            Item item = new Item(name, finalId, finalId);
            Item previousItem = GetItemByID(item.FromID - 1);
            if (previousItem != null && previousItem.Name.ToLower() == name.ToLower() && previousItem.Description.ToLower() == description.ToLower()) {
                previousItem.ToID = item.FromID;
                if (previousItem.Tag.Length == 0) {
                    previousItem.Tag = _editedTag;
                }
                //AppendLog("[ID: " + item.FromID + "] Missing item inserted on existent item range.");
                return previousItem;
            } else {
                Item nextItem = GetItemByID(item.FromID + 1);
                if (nextItem != null && nextItem.Name.ToLower() == name.ToLower() && nextItem.Description.ToLower() == description.ToLower()) {
                    nextItem.FromID = item.FromID;
                    if (nextItem.Tag.Length == 0) {
                        nextItem.Tag = _editedTag;
                    }
                    //AppendLog("[ID: " + item.FromID + "] Missing item inserted on existent item range.");
                    return nextItem;
                }
            }

            if (name.Length == 0) {
                return null;
            }

            if (item.FromID > _lastItemId) {
                _lastItemId = item.FromID;
            }


            item.Tag = _newTag;
            item.Name = name;
            item.Description = description;
            if (sameThread) {
                ItemsList.Items.Add(item);
            }
            //AppendLog("[ID: " + item.FromID + "] Missing item created.");
            return item;
        }

        #endregion

        #region Boxes and enum

        private void InitializePartnerDir()
        {
            PartnerDirection.Items.Add(new ComboBox_t("-", String.Empty));

            ComboBox_t north = new ComboBox_t("North", "north");
            north.Xml.Add("n");
            north.Xml.Add("0");
            PartnerDirection.Items.Add(north);

            ComboBox_t east = new ComboBox_t("East", "east");
            east.Xml.Add("e");
            east.Xml.Add("1");
            PartnerDirection.Items.Add(east);

            ComboBox_t south = new ComboBox_t("South", "south");
            south.Xml.Add("s");
            south.Xml.Add("2");
            PartnerDirection.Items.Add(south);

            ComboBox_t west = new ComboBox_t("South", "west");
            west.Xml.Add("w");
            west.Xml.Add("3");
            PartnerDirection.Items.Add(west);

            ComboBox_t southwest = new ComboBox_t("South west", "southwest");
            southwest.Xml.Add("south west");
            southwest.Xml.Add("south-west");
            southwest.Xml.Add("sw");
            southwest.Xml.Add("4");
            PartnerDirection.Items.Add(southwest);

            ComboBox_t southeast = new ComboBox_t("South east", "southeast");
            southeast.Xml.Add("south east");
            southeast.Xml.Add("south-east");
            southeast.Xml.Add("se");
            southeast.Xml.Add("5");
            PartnerDirection.Items.Add(southeast);

            ComboBox_t northwest = new ComboBox_t("North west", "northwest");
            northwest.Xml.Add("north west");
            northwest.Xml.Add("north-west");
            northwest.Xml.Add("nw");
            northwest.Xml.Add("6");
            PartnerDirection.Items.Add(northwest);

            ComboBox_t northeast = new ComboBox_t("North east", "northeast");
            northeast.Xml.Add("north east");
            northeast.Xml.Add("north-east");
            northeast.Xml.Add("ne");
            northeast.Xml.Add("7");
            PartnerDirection.Items.Add(northeast);

            PartnerDirection.SelectedIndex = 0;

            PartnerDirection.Items.SortDescriptions.Clear();
            PartnerDirection.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeFieldType()
        {
            FieldType.Items.Add(new ComboBox_t("-", String.Empty));

            FieldType.Items.Add(new ComboBox_t("Fire", "fire"));
            FieldType.Items.Add(new ComboBox_t("Energy", "energy"));
            FieldType.Items.Add(new ComboBox_t("Poison", "poison"));
            FieldType.Items.Add(new ComboBox_t("Drown", "drown"));
            FieldType.Items.Add(new ComboBox_t("Physical", "physical"));

            FieldType.SelectedIndex = 0;

            FieldType.Items.SortDescriptions.Clear();
            FieldType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeLootType()
        {
            LootType.Items.Add(new ComboBox_t("-", String.Empty));

            LootType.Items.Add(new ComboBox_t("Armor", "armor"));
            LootType.Items.Add(new ComboBox_t("Amulet", "amulet"));
            LootType.Items.Add(new ComboBox_t("Boots", "boots"));
            LootType.Items.Add(new ComboBox_t("Container", "container"));
            LootType.Items.Add(new ComboBox_t("Decoration", "decoration"));
            LootType.Items.Add(new ComboBox_t("Food", "food"));
            LootType.Items.Add(new ComboBox_t("Helmet", "helmet"));
            LootType.Items.Add(new ComboBox_t("Legs", "legs"));
            LootType.Items.Add(new ComboBox_t("Other", "other"));
            LootType.Items.Add(new ComboBox_t("Potion", "potion"));
            LootType.Items.Add(new ComboBox_t("Ring", "ring"));
            LootType.Items.Add(new ComboBox_t("Rune", "rune"));
            LootType.Items.Add(new ComboBox_t("Shield", "shield"));
            LootType.Items.Add(new ComboBox_t("Tools", "tools"));
            LootType.Items.Add(new ComboBox_t("Valuable", "valuable"));
            LootType.Items.Add(new ComboBox_t("Ammo", "ammo"));
            LootType.Items.Add(new ComboBox_t("Axe", "axe"));
            LootType.Items.Add(new ComboBox_t("Club", "club"));
            LootType.Items.Add(new ComboBox_t("Distance", "distance"));
            LootType.Items.Add(new ComboBox_t("Sword", "sword"));
            LootType.Items.Add(new ComboBox_t("Wand", "wand"));
            LootType.Items.Add(new ComboBox_t("Creature product", "creatureproduct"));
            LootType.Items.Add(new ComboBox_t("Retrieve", "retrieve"));
            LootType.Items.Add(new ComboBox_t("Gold", "gold"));
            LootType.Items.Add(new ComboBox_t("Unnassigned", "unassigned"));

            LootType.SelectedIndex = 0;

            LootType.Items.SortDescriptions.Clear();
            LootType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeMagicEffect()
        {
            MagicEffect.Items.Add(new ComboBox_t("-", String.Empty));

            MagicEffect.Items.Add(new ComboBox_t("Assassin", "assassin"));
            MagicEffect.Items.Add(new ComboBox_t("Blue fireworks", "bluefireworks"));
            MagicEffect.Items.Add(new ComboBox_t("Blue bubble", "bluebubble"));
            MagicEffect.Items.Add(new ComboBox_t("Black spark", "blackspark"));
            MagicEffect.Items.Add(new ComboBox_t("Blue shimmer", "blueshimmer"));
            MagicEffect.Items.Add(new ComboBox_t("Blue note", "bluenote"));
            MagicEffect.Items.Add(new ComboBox_t("Bubbles", "bubbles"));
            MagicEffect.Items.Add(new ComboBox_t("Blue firework", "bluefirework"));
            MagicEffect.Items.Add(new ComboBox_t("Big clouds", "bigclouds"));
            MagicEffect.Items.Add(new ComboBox_t("Big plants", "bigplants"));
            MagicEffect.Items.Add(new ComboBox_t("Bloody steps", "bloodysteps"));
            MagicEffect.Items.Add(new ComboBox_t("Bats", "bats"));
            MagicEffect.Items.Add(new ComboBox_t("Blue energy spark", "blueenergyspark"));
            MagicEffect.Items.Add(new ComboBox_t("Blue ghost", "blueghost"));
            MagicEffect.Items.Add(new ComboBox_t("Black smoke", "blacksmoke"));
            MagicEffect.Items.Add(new ComboBox_t("Carniphila", "carniphila"));
            MagicEffect.Items.Add(new ComboBox_t("Cake", "cake"));
            MagicEffect.Items.Add(new ComboBox_t("Confetti horizontal", "confettihorizontal"));
            MagicEffect.Items.Add(new ComboBox_t("Confetti vertical", "confettivertical"));
            MagicEffect.Items.Add(new ComboBox_t("Critical damage", "criticaldagame"));
            MagicEffect.Items.Add(new ComboBox_t("Dice", "dice"));
            MagicEffect.Items.Add(new ComboBox_t("Dragon head", "dragonhead"));
            MagicEffect.Items.Add(new ComboBox_t("Explosion area", "explosionarea"));
            MagicEffect.Items.Add(new ComboBox_t("Explosion", "explosion"));
            MagicEffect.Items.Add(new ComboBox_t("Energy", "energy"));
            MagicEffect.Items.Add(new ComboBox_t("Energy area", "energyarea"));
            MagicEffect.Items.Add(new ComboBox_t("Early thunder", "earlythunder"));
            MagicEffect.Items.Add(new ComboBox_t("Fire", "fire"));
            MagicEffect.Items.Add(new ComboBox_t("Fire area", "firearea"));
            MagicEffect.Items.Add(new ComboBox_t("Fire attack", "fireattack"));
            MagicEffect.Items.Add(new ComboBox_t("Ferumbras", "ferumbras"));
            MagicEffect.Items.Add(new ComboBox_t("Green spark", "greenspark"));
            MagicEffect.Items.Add(new ComboBox_t("Green bubble", "greenbubble"));
            MagicEffect.Items.Add(new ComboBox_t("Green note", "greennote"));
            MagicEffect.Items.Add(new ComboBox_t("Green shimmer", "greenshimmer"));
            MagicEffect.Items.Add(new ComboBox_t("Gift wraps", "giftwraps"));
            MagicEffect.Items.Add(new ComboBox_t("Ground shaker", "groundshaker"));
            MagicEffect.Items.Add(new ComboBox_t("Giantice", "giantice"));
            MagicEffect.Items.Add(new ComboBox_t("Green smoke", "greensmoke"));
            MagicEffect.Items.Add(new ComboBox_t("Green energy spark", "greenenergyspark"));
            MagicEffect.Items.Add(new ComboBox_t("Green fireworks", "greenfireworks"));
            MagicEffect.Items.Add(new ComboBox_t("Hearts", "hearts"));
            MagicEffect.Items.Add(new ComboBox_t("Holy damage", "holydamage"));
            MagicEffect.Items.Add(new ComboBox_t("Holy area", "holyarea"));
            MagicEffect.Items.Add(new ComboBox_t("Ice area", "icearea"));
            MagicEffect.Items.Add(new ComboBox_t("Ice tornado", "icetornado"));
            MagicEffect.Items.Add(new ComboBox_t("Ice attack", "iceattack"));
            MagicEffect.Items.Add(new ComboBox_t("Insects", "insects"));
            MagicEffect.Items.Add(new ComboBox_t("Mortarea", "mortarea"));
            MagicEffect.Items.Add(new ComboBox_t("Mirror horizontal", "mirrorhorizontal"));
            MagicEffect.Items.Add(new ComboBox_t("Mirror vertical", "mirrorvertical"));
            MagicEffect.Items.Add(new ComboBox_t("Magic powder", "magicpowder"));
            MagicEffect.Items.Add(new ComboBox_t("Orc shaman", "orcshaman"));
            MagicEffect.Items.Add(new ComboBox_t("Orc shaman fire", "orcshamanfire"));
            MagicEffect.Items.Add(new ComboBox_t("Orange energy spark", "orangeenergyspark"));
            MagicEffect.Items.Add(new ComboBox_t("Orange fireworks", "orangefireworks"));
            MagicEffect.Items.Add(new ComboBox_t("Poff", "poff"));
            MagicEffect.Items.Add(new ComboBox_t("Poison", "poison"));
            MagicEffect.Items.Add(new ComboBox_t("Purple note", "purplenote"));
            MagicEffect.Items.Add(new ComboBox_t("Purple energy", "purpleenergy"));
            MagicEffect.Items.Add(new ComboBox_t("Plant attack", "plantattack"));
            MagicEffect.Items.Add(new ComboBox_t("Pluging fish", "plugingfish"));
            MagicEffect.Items.Add(new ComboBox_t("Purple smoke", "purplesmoke"));
            MagicEffect.Items.Add(new ComboBox_t("Pixie explosion", "pixieexplosion"));
            MagicEffect.Items.Add(new ComboBox_t("Pixie coming", "pixiecoming"));
            MagicEffect.Items.Add(new ComboBox_t("Pixie going", "pixiegoing"));
            MagicEffect.Items.Add(new ComboBox_t("Pink beam", "pinkbeam"));
            MagicEffect.Items.Add(new ComboBox_t("Pink vortex", "pinkvortex"));
            MagicEffect.Items.Add(new ComboBox_t("Pink energy spark", "pinkenergyspark"));
            MagicEffect.Items.Add(new ComboBox_t("Pink fireworks", "pinkfireworks"));
            MagicEffect.Items.Add(new ComboBox_t("Red spark", "redspark"));
            MagicEffect.Items.Add(new ComboBox_t("Red shimmer", "redshimmer"));
            MagicEffect.Items.Add(new ComboBox_t("Red note", "rednote"));
            MagicEffect.Items.Add(new ComboBox_t("Red firework", "redfirework"));
            MagicEffect.Items.Add(new ComboBox_t("Red smoke", "redsmoke"));
            MagicEffect.Items.Add(new ComboBox_t("Ragiaz bone capsule", "ragiazbonecapsule"));
            MagicEffect.Items.Add(new ComboBox_t("Stun", "stun"));
            MagicEffect.Items.Add(new ComboBox_t("Sleep", "sleep"));
            MagicEffect.Items.Add(new ComboBox_t("Small clouds", "smallclouds"));
            MagicEffect.Items.Add(new ComboBox_t("Stones", "stones"));
            MagicEffect.Items.Add(new ComboBox_t("Small plants", "smallplants"));
            MagicEffect.Items.Add(new ComboBox_t("Skull horizontal", "skullhorizontal"));
            MagicEffect.Items.Add(new ComboBox_t("Skull vertical", "skullvertical"));
            MagicEffect.Items.Add(new ComboBox_t("Steps horizontal", "stepshorizontal"));
            MagicEffect.Items.Add(new ComboBox_t("Steps vertical", "stepsvertical"));
            MagicEffect.Items.Add(new ComboBox_t("Smoke", "smoke"));
            MagicEffect.Items.Add(new ComboBox_t("Storm", "storm"));
            MagicEffect.Items.Add(new ComboBox_t("Stone storm", "stonestorm"));
            MagicEffect.Items.Add(new ComboBox_t("Teleport", "teleport"));
            MagicEffect.Items.Add(new ComboBox_t("Tutorial arrow", "tutorialarrow"));
            MagicEffect.Items.Add(new ComboBox_t("Tutorial square", "tutorialsquare"));
            MagicEffect.Items.Add(new ComboBox_t("Thunder", "thunder"));
            MagicEffect.Items.Add(new ComboBox_t("Treasure map", "treasuremap"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow spark", "yellowspark"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow bubble", "yellowbubble"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow note", "yellownote"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow firework", "yellowfirework"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow energy", "yellowenergy"));
            MagicEffect.Items.Add(new ComboBox_t("Yalahari ghost", "yalaharighost"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow smoke", "yellowsmoke"));
            MagicEffect.Items.Add(new ComboBox_t("Yellow energy spark", "yellowenergyspark"));
            MagicEffect.Items.Add(new ComboBox_t("White note", "whitenote"));
            MagicEffect.Items.Add(new ComboBox_t("Water creature", "watercreature"));
            MagicEffect.Items.Add(new ComboBox_t("Water splash", "watersplash"));
            MagicEffect.Items.Add(new ComboBox_t("White energy spark", "whiteenergyspark"));

            MagicEffect.SelectedIndex = 0;

            MagicEffect.Items.SortDescriptions.Clear();
            MagicEffect.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeShootType()
        {
            ShootType.Items.Add(new ComboBox_t("-", String.Empty));

            ShootType.Items.Add(new ComboBox_t("Arrow", "arrow"));
            ShootType.Items.Add(new ComboBox_t("Bolt", "bolt"));
            ShootType.Items.Add(new ComboBox_t("Burst arrow", "burstarrow"));
            ShootType.Items.Add(new ComboBox_t("Cake", "cake"));
            ShootType.Items.Add(new ComboBox_t("Crystalline arrow", "crystallinearrow"));
            ShootType.Items.Add(new ComboBox_t("Drill bolt", "drillbolt"));
            ShootType.Items.Add(new ComboBox_t("Death", "death"));
            ShootType.Items.Add(new ComboBox_t("Energy", "energy"));
            ShootType.Items.Add(new ComboBox_t("Enchanted spear", "enchantedspear"));
            ShootType.Items.Add(new ComboBox_t("Ethereal spear", "etherealspear"));
            ShootType.Items.Add(new ComboBox_t("Earth arrow", "eartharrow"));
            ShootType.Items.Add(new ComboBox_t("Explosion", "explosion"));
            ShootType.Items.Add(new ComboBox_t("Earth", "earth"));
            ShootType.Items.Add(new ComboBox_t("Energy ball", "energyball"));
            ShootType.Items.Add(new ComboBox_t("Envenomed arrow", "envenomedarrow"));
            ShootType.Items.Add(new ComboBox_t("Fire", "fire"));
            ShootType.Items.Add(new ComboBox_t("Flash arrow", "flasharrow"));
            ShootType.Items.Add(new ComboBox_t("Flamming arrow", "flammingarrow"));
            ShootType.Items.Add(new ComboBox_t("Green star", "greenstar"));
            ShootType.Items.Add(new ComboBox_t("Glooth spear", "gloothspear"));
            ShootType.Items.Add(new ComboBox_t("Hunting spear", "huntingspear"));
            ShootType.Items.Add(new ComboBox_t("Holy", "holy"));
            ShootType.Items.Add(new ComboBox_t("Infernal bolt", "infernalbolt"));
            ShootType.Items.Add(new ComboBox_t("Ice", "ice"));
            ShootType.Items.Add(new ComboBox_t("Large rock", "largerock"));
            ShootType.Items.Add(new ComboBox_t("Leaf star", "leafstar"));
            ShootType.Items.Add(new ComboBox_t("Onyx arrow", "onyxarrow"));
            ShootType.Items.Add(new ComboBox_t("Red star", "redstar"));
            ShootType.Items.Add(new ComboBox_t("Royal spear", "royalspear"));
            ShootType.Items.Add(new ComboBox_t("Spear", "spear"));
            ShootType.Items.Add(new ComboBox_t("Sniper arrow", "sniperarrow"));
            ShootType.Items.Add(new ComboBox_t("Small stone", "smallstone"));
            ShootType.Items.Add(new ComboBox_t("Small ice", "smallice"));
            ShootType.Items.Add(new ComboBox_t("Small holy", "smallholy"));
            ShootType.Items.Add(new ComboBox_t("Small earth", "smallearth"));
            ShootType.Items.Add(new ComboBox_t("Snowball", "snowball"));
            ShootType.Items.Add(new ComboBox_t("Sudden death", "suddendeath"));
            ShootType.Items.Add(new ComboBox_t("Shiver arrow", "shiverarrow"));
            ShootType.Items.Add(new ComboBox_t("Simple arrow", "simplearrow"));
            ShootType.Items.Add(new ComboBox_t("Poison arrow", "poisonarrow"));
            ShootType.Items.Add(new ComboBox_t("Power bolt", "powerbolt"));
            ShootType.Items.Add(new ComboBox_t("Poison", "poison"));
            ShootType.Items.Add(new ComboBox_t("Prismatic bolt", "prismaticbolt"));
            ShootType.Items.Add(new ComboBox_t("Piercing bolt", "piercingbolt"));
            ShootType.Items.Add(new ComboBox_t("Throwing star", "throwingstar"));
            ShootType.Items.Add(new ComboBox_t("Vortex bolt", "vortexbolt"));
            ShootType.Items.Add(new ComboBox_t("Throwing knife", "throwingknife"));
            ShootType.Items.Add(new ComboBox_t("Tarsal arrow", "tarsalarrow"));
            ShootType.Items.Add(new ComboBox_t("Whirlwind sword", "whirlwindsword"));
            ShootType.Items.Add(new ComboBox_t("Whirlwind axe", "whirlwindaxe"));
            ShootType.Items.Add(new ComboBox_t("Whirlwind club", "whirlwindclub"));
            ShootType.Items.Add(new ComboBox_t("Diamond arrow", "diamondarrow"));
            ShootType.Items.Add(new ComboBox_t("Spectral bolt", "spectralbolt"));
            ShootType.Items.Add(new ComboBox_t("Royal star", "royalstar"));

            ShootType.SelectedIndex = 0;

            ShootType.Items.SortDescriptions.Clear();
            ShootType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeAmmoType()
        {
            AmmoType.Items.Add(new ComboBox_t("-", String.Empty));

            AmmoType.Items.Add(new ComboBox_t("Arrow", "arrow"));
            AmmoType.Items.Add(new ComboBox_t("Bolt", "bolt"));
            AmmoType.Items.Add(new ComboBox_t("Poison arrow", "poisonarrow"));
            AmmoType.Items.Add(new ComboBox_t("Burst arrow", "burstarrow"));
            AmmoType.Items.Add(new ComboBox_t("Enchanted spear", "enchantedspear"));
            AmmoType.Items.Add(new ComboBox_t("Ethereal spear", "etherealspear"));
            AmmoType.Items.Add(new ComboBox_t("Earth arrow", "eartharrow"));
            AmmoType.Items.Add(new ComboBox_t("Flash arrow", "flasharrow"));
            AmmoType.Items.Add(new ComboBox_t("Flamming arrow", "flammingarrow"));
            AmmoType.Items.Add(new ComboBox_t("Hunting spear", "huntingspear"));
            AmmoType.Items.Add(new ComboBox_t("Infernal bolt", "infernalbolt"));
            AmmoType.Items.Add(new ComboBox_t("Large rock", "largerock"));
            AmmoType.Items.Add(new ComboBox_t("Onyx arrow", "onyxarrow"));
            AmmoType.Items.Add(new ComboBox_t("Power bolt", "powerbolt"));
            AmmoType.Items.Add(new ComboBox_t("Piercing bolt", "piercingbolt"));
            AmmoType.Items.Add(new ComboBox_t("Royal spear", "royalspear"));
            AmmoType.Items.Add(new ComboBox_t("Snow ball", "snowball"));
            AmmoType.Items.Add(new ComboBox_t("Small stone", "smallstone"));
            AmmoType.Items.Add(new ComboBox_t("Spear", "spear"));
            AmmoType.Items.Add(new ComboBox_t("Sniper arrow", "sniperarrow"));
            AmmoType.Items.Add(new ComboBox_t("Shiver arrow", "shiverarrow"));
            AmmoType.Items.Add(new ComboBox_t("Throwing star", "throwingstar"));
            AmmoType.Items.Add(new ComboBox_t("Throwing knife", "throwingknife"));
            AmmoType.Items.Add(new ComboBox_t("Diamond arrow", "diamondarrow"));
            AmmoType.Items.Add(new ComboBox_t("Spectral bolt", "spectralbolt"));

            AmmoType.SelectedIndex = 0;

            AmmoType.Items.SortDescriptions.Clear();
            AmmoType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeSlotType()
        {
            SlotType.Items.Add(new ComboBox_t("-", String.Empty));

            SlotType.Items.Add(new ComboBox_t("Head", "head"));
            SlotType.Items.Add(new ComboBox_t("Body", "body"));
            SlotType.Items.Add(new ComboBox_t("Legs", "legs"));
            SlotType.Items.Add(new ComboBox_t("Feet", "feet"));
            SlotType.Items.Add(new ComboBox_t("Backpack", "backpack"));
            SlotType.Items.Add(new ComboBox_t("Two handed", "two-handed"));
            SlotType.Items.Add(new ComboBox_t("Right hand", "right-hand"));
            SlotType.Items.Add(new ComboBox_t("Left hand", "left-hand"));
            SlotType.Items.Add(new ComboBox_t("Necklace", "necklace"));
            SlotType.Items.Add(new ComboBox_t("Ring", "ring"));
            SlotType.Items.Add(new ComboBox_t("Ammo", "ammo"));
            SlotType.Items.Add(new ComboBox_t("Any hand", "hand"));

            SlotType.SelectedIndex = 0;

            SlotType.Items.SortDescriptions.Clear();
            SlotType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeWeaponType()
        {
            WeaponType.Items.Add(new ComboBox_t("-", String.Empty));

            WeaponType.Items.Add(new ComboBox_t("Sword", "sword"));
            WeaponType.Items.Add(new ComboBox_t("Club", "club"));
            WeaponType.Items.Add(new ComboBox_t("Axe", "axe"));
            WeaponType.Items.Add(new ComboBox_t("Shield", "shield"));
            WeaponType.Items.Add(new ComboBox_t("Distance", "distance"));
            WeaponType.Items.Add(new ComboBox_t("Wand", "wand"));
            WeaponType.Items.Add(new ComboBox_t("Ammunition", "ammunition"));
            WeaponType.Items.Add(new ComboBox_t("Quiver", "quiver"));

            WeaponType.SelectedIndex = 0;

            WeaponType.Items.SortDescriptions.Clear();
            WeaponType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeFluidSource()
        {
            FluidSource.Items.Add(new ComboBox_t("-", String.Empty));

            FluidSource.Items.Add(new ComboBox_t("Water", "water"));
            FluidSource.Items.Add(new ComboBox_t("Blood", "blood"));
            FluidSource.Items.Add(new ComboBox_t("Beer", "beer"));
            FluidSource.Items.Add(new ComboBox_t("Slime", "slime"));
            FluidSource.Items.Add(new ComboBox_t("Lemonade", "lemonade"));
            FluidSource.Items.Add(new ComboBox_t("Milk", "milk"));
            FluidSource.Items.Add(new ComboBox_t("Mana", "mana"));
            FluidSource.Items.Add(new ComboBox_t("Life", "life"));
            FluidSource.Items.Add(new ComboBox_t("Oil", "oil"));
            FluidSource.Items.Add(new ComboBox_t("Urine", "urine"));
            FluidSource.Items.Add(new ComboBox_t("Coconut", "coconut"));
            FluidSource.Items.Add(new ComboBox_t("Wine", "wine"));
            FluidSource.Items.Add(new ComboBox_t("Mud", "mud"));
            FluidSource.Items.Add(new ComboBox_t("Fruit juice", "fruitjuice"));
            FluidSource.Items.Add(new ComboBox_t("Lava", "lava"));
            FluidSource.Items.Add(new ComboBox_t("Rum", "rum"));
            FluidSource.Items.Add(new ComboBox_t("Swamp", "swamp"));
            FluidSource.Items.Add(new ComboBox_t("Tea", "tea"));
            FluidSource.Items.Add(new ComboBox_t("Mead", "mead"));

            FluidSource.SelectedIndex = 0;

            FluidSource.Items.SortDescriptions.Clear();
            FluidSource.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeCorpseType()
        {
            CorpseType.Items.Add(new ComboBox_t("-", String.Empty));

            CorpseType.Items.Add(new ComboBox_t("Venom", "venom"));
            CorpseType.Items.Add(new ComboBox_t("Blood", "blood"));
            CorpseType.Items.Add(new ComboBox_t("Undead", "undead"));
            CorpseType.Items.Add(new ComboBox_t("Fire", "fire"));
            CorpseType.Items.Add(new ComboBox_t("Energy", "energy"));

            CorpseType.SelectedIndex = 0;

            CorpseType.Items.SortDescriptions.Clear();
            CorpseType.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeFloorChange()
        {
            FloorChange.Items.Add(new ComboBox_t("-", String.Empty));

            FloorChange.Items.Add(new ComboBox_t("Down", "down"));
            FloorChange.Items.Add(new ComboBox_t("North", "north"));
            FloorChange.Items.Add(new ComboBox_t("South", "south"));
            FloorChange.Items.Add(new ComboBox_t("South alt", "southalt"));
            FloorChange.Items.Add(new ComboBox_t("East", "east"));
            FloorChange.Items.Add(new ComboBox_t("East alt", "eastalt"));
            FloorChange.Items.Add(new ComboBox_t("West", "west"));

            FloorChange.SelectedIndex = 0;

            FloorChange.Items.SortDescriptions.Clear();
            FloorChange.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeItemType()
        {
            Type.Items.Add(new ComboBox_t("-", String.Empty));

            Type.Items.Add(new ComboBox_t("Key", "key"));
            Type.Items.Add(new ComboBox_t("Magic field", "magicfield"));
            Type.Items.Add(new ComboBox_t("Container", "container"));
            Type.Items.Add(new ComboBox_t("Depot", "depot"));
            Type.Items.Add(new ComboBox_t("Reward chest", "rewardchest"));
            Type.Items.Add(new ComboBox_t("Carpet", "carpet"));
            Type.Items.Add(new ComboBox_t("Mail box", "mailbox"));
            Type.Items.Add(new ComboBox_t("Trash holder", "trashholder"));
            Type.Items.Add(new ComboBox_t("Teleport", "teleport"));
            Type.Items.Add(new ComboBox_t("Door", "door"));
            Type.Items.Add(new ComboBox_t("Rune", "rune"));
            Type.Items.Add(new ComboBox_t("Supply", "supply"));
            Type.Items.Add(new ComboBox_t("Creature product", "creatureproduct"));
            Type.Items.Add(new ComboBox_t("Valuable", "valuable"));
            Type.Items.Add(new ComboBox_t("Potion", "potion"));

            Type.SelectedIndex = 0;

            Type.Items.SortDescriptions.Clear();
            Type.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeSearchMethod()
        {
            Filter.Items.Add(new ComboBox_t("ID", "FromID"));
            Filter.Items.Add(new ComboBox_t("Name", "Name"));

            Filter.SelectedIndex = 0;

            Filter.Items.SortDescriptions.Clear();
            Filter.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void InitializeSort()
        {
            Sort.Items.Add(new ComboBox_t("ID", "FromID"));
            Sort.Items.Add(new ComboBox_t("Name", "Name"));

            Sort.SelectedIndex = 0;

            Sort.Items.SortDescriptions.Clear();
            Sort.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        #endregion

        #region Callbacks
        private void OnTextChanged(object sender, TextCompositionEventArgs e)
        {
			if (_selectionGrid == null) {
				return;
			}
			
            _hasChange = true;
            SaveItemButton.IsEnabled = true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
			if (_selectionGrid == null) {
				return;
			}
			
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            _hasChange = true;
            SaveItemButton.IsEnabled = true;
        }

        private void OnSelectionCHanged(object sender, SelectionChangedEventArgs e)
        {
			if (_selectionGrid == null) {
				return;
			}
			
            _hasChange = true;
            SaveItemButton.IsEnabled = true;
        }

        private void OnCheckChanged(object sender, RoutedEventArgs e)
        {
			if (_selectionGrid == null) {
				return;
			}
			
            _hasChange = true;
            SaveItemButton.IsEnabled = true;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsList.Items.Count == 0) {
                return;
            }

            ComboBox_t sort = Sort.SelectedItem as ComboBox_t;
            if (sort != null) {
                ItemsList.Items.SortDescriptions.Clear();
                ItemsList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription(sort.Xml[0], System.ComponentModel.ListSortDirection.Ascending));
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (KeyWord.Text.Length == 0 || ItemsList.Items.Count == 0) {
                return;
            }

            ComboBox_t filter = Filter.SelectedItem as ComboBox_t;
            if (filter != null) {
                if (filter.Xml[0] == "FromID" && !ValidateStringParseToInt(KeyWord.Text)) {
                    MessageBox.Show("Your search keywork is invalid for '" + filter.Name + "' method type, duo that the search was aborted.", "Search error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                bool found = false;
                for (int i = 0; i < ItemsList.Items.Count; i++) {
                    Item item = ItemsList.Items[i] as Item;
                    if (item != null) {
                        if ((filter.Xml[0] == "Name" && item.Name.Contains(KeyWord.Text)) ||
                            (filter.Xml[0] == "FromID" && item.FromID <= int.Parse(KeyWord.Text) && item.ToID >= int.Parse(KeyWord.Text))) {
                            ItemsList.ScrollIntoView(item);
                            found = true;
                            break;
                        }
                    }
                }

                if (!found) {
                    MessageBox.Show("No item has been found that match '" + filter.Name + "' method with '" + KeyWord.Text + "' as keyword.", "Search info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            if (!_hasChange) {
                return;
            }

            SaveItem();
        }

        private void OnItemMouseDown(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null) {

                if (_selectionGrid != null && (int)_selectionGrid.DataContext == (int)grid.DataContext) {
                    return;
                }

                if (_hasChange) {
                    MessageBoxResult warnResult = MessageBox.Show(this, "You have unsaved changes, wan't to ignore it and discard your changes?", "Unsaved changes", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                    if (warnResult == MessageBoxResult.No)
                        return;
                }

                _hasChange = false;
                SaveItemButton.IsEnabled = false;
                Rectangle rectangle0 = grid.Children[0] as Rectangle;
                if (rectangle0 != null) {
                    rectangle0.Fill = _yellowBrush;
                }
                
                Rectangle rectangle1 = grid.Children[1] as Rectangle;
                if (rectangle1 != null) {
                    rectangle1.Opacity = 0.4;
                }
                
                if (_selectionGrid != null) {
                    Item selectionItem = GetItemByID((int)_selectionGrid.DataContext);
                    Rectangle selectionRectangle0 = _selectionGrid.Children[0] as Rectangle;
                    if (selectionRectangle0 != null) {
                        selectionRectangle0.Fill = _greenBrush;
                    }
                
                    Rectangle selectionRectangle1 = _selectionGrid.Children[1] as Rectangle;
                    if (selectionRectangle1 != null) {
                        selectionRectangle1.Opacity = 0;
                    }
                }

                _selectionGrid = grid;
                SelectItem();
            }
        }

        private void OnItemMouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null) {
                Rectangle rectangle = grid.Children[1] as Rectangle;
                if (rectangle != null) {
                    rectangle.Opacity += 0.25;
                }
            }
        }

        private void OnItemMouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null) {
                Rectangle rectangle = grid.Children[1] as Rectangle;
                if (rectangle != null) {
                    rectangle.Opacity -= 0.25;
                }
            }
        }

        private void LoadXML_Click(object sender, RoutedEventArgs e)
        {
            if (_message != null) {
                return;
            }

            _message = new Message("Item xml loader", this);

            _message.CreateTextOnLog("Load your items.xml file and start editing and updating it.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("How to use:");
            _message.CreateTextOnLog("- If your xml file is using serverID click 'Load as server ID'.");
            _message.CreateTextOnLog("- If your xml file is using clientID click 'Load as client ID'.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("Benefits:");
            _message.CreateTextOnLog("- Change all available data of your items.");
            _message.CreateTextOnLog("- Update and syncronize your items with assets and WIKI.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("* It's using tibiawiki.dev API.");

            Button clientIDButton = _message.CreateNewButton("Load as client ID");
            clientIDButton.Click += _message.LoadXMLClientID_Click;

            Button serverIDButton = _message.CreateNewButton("Load as server ID");
            serverIDButton.Click += _message.LoadXMLServerID_Click;

            Button closeButton = _message.CreateNewButton("Close");
            closeButton.Click += _message.Close_Click;
            closeButton.Margin = new Thickness(0, 0, 40, 0);

            _message.Show();
        }

        private void SaveXML_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsList.Items.Count == 0) {
                MessageBox.Show("There are no items regisreted on the program, try loading a new xml file first.", "Saving XML error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save XML file",
                Filter = "XML file (*.xml)|*.xml",
                FilterIndex = 1
            };

            if ((bool)saveFileDialog.ShowDialog()) {
                SaveXMLFile(saveFileDialog.FileName);
            }

        }

        private void LoadAssets_Click(object sender, RoutedEventArgs e)
        {
            if (_message != null) {
                return;
            }

            _message = new Message("Assets loader", this);

            Button assetsButton = _message.CreateNewButton("Load assets");
            assetsButton.Click += _message.LoadAssets_Click;

            Button closeButton = _message.CreateNewButton("Close");
            closeButton.Click += _message.Close_Click;
            closeButton.Margin = new Thickness(0, 0, 40, 0);

            _message.CreateTextOnLog("Load client 12 assets to insert missing items.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("How to use:");
            _message.CreateTextOnLog("- Click on 'Load otb' and load your client 12 assets.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("Benefits:");
            _message.CreateTextOnLog("- Insert missing items.");
            _message.CreateTextOnLog("- Reload items names and description.");

            _message.Show();
        }

        private void LoadWiki_Click(object sender, RoutedEventArgs e)
        {
            if (_message != null) {
                return;
            }

            _message = new Message("Wiki loader", this);

            _message.CreateTextOnLog("Synchronize your items data with the tibia WIKI.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("How to use:");
            _message.CreateTextOnLog("- (Recommended) Load client 12 assets to update your items.");
            _message.CreateTextOnLog("- Select the types of items you want to update.");
            _message.CreateTextOnLog("- Click 'load wiki'.");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("Benefits:");
            _message.CreateTextOnLog("- Update all values like attack, defense, armor, weight etc...");
            _message.CreateTextOnLog();
            _message.CreateTextOnLog("* It's using tibiawiki.dev API.");
            _message.CreateTextOnLog("* Need internet connection.");

            ComboBox comboBox = _message.CreateNewComboBox("Filter:");
            comboBox.Items.Add(new ComboBox_t("No filter", string.Empty));
            comboBox.Items.Add(new ComboBox_t("Armor", "armor"));
            comboBox.Items.Add(new ComboBox_t("Amulet", "amulet"));
            comboBox.Items.Add(new ComboBox_t("Boots", "boots"));
            comboBox.Items.Add(new ComboBox_t("Container", "container"));
            comboBox.Items.Add(new ComboBox_t("Decoration", "decoration"));
            comboBox.Items.Add(new ComboBox_t("Food", "food"));
            comboBox.Items.Add(new ComboBox_t("Helmet", "helmet"));
            comboBox.Items.Add(new ComboBox_t("Legs", "legs"));
            comboBox.Items.Add(new ComboBox_t("Other", "other"));
            comboBox.Items.Add(new ComboBox_t("Potion", "potion"));
            comboBox.Items.Add(new ComboBox_t("Ring", "ring"));
            comboBox.Items.Add(new ComboBox_t("Rune", "rune"));
            comboBox.Items.Add(new ComboBox_t("Shield", "shield"));
            comboBox.Items.Add(new ComboBox_t("Tools", "tools"));
            comboBox.Items.Add(new ComboBox_t("Valuable", "valuable"));
            comboBox.Items.Add(new ComboBox_t("Ammo", "ammo"));
            comboBox.Items.Add(new ComboBox_t("Axe", "axe"));
            comboBox.Items.Add(new ComboBox_t("Club", "club"));
            comboBox.Items.Add(new ComboBox_t("Distance", "distance"));
            comboBox.Items.Add(new ComboBox_t("Sword", "sword"));
            comboBox.Items.Add(new ComboBox_t("Wand", "wand"));
            comboBox.Items.Add(new ComboBox_t("Creature product", "creatureproduct"));
            comboBox.Items.Add(new ComboBox_t("Retrieve", "retrieve"));
            comboBox.Items.Add(new ComboBox_t("Gold", "gold"));

            Button wikiButton = _message.CreateNewButton("Load wiki");
            wikiButton.Click += _message.LoadWiki_Click;

            Button closeButton = _message.CreateNewButton("Close");
            closeButton.Click += _message.Close_Click;
            closeButton.Margin = new Thickness(0, 0, 40, 0);

            _message.Show();
        }

        private void MouseDownToDrag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion

        #region XML document
        public void SaveXMLFile(string path)
        {
            using (FileStream fs = File.Create(path)) {

                XmlDocument xml = new XmlDocument();

                XmlNode node;
                XmlNode itemNode;
                XmlNode attributeNode;
                XmlNode childAttributeNode;

                node = xml.AppendChild(xml.CreateXmlDeclaration(_xmlVersion, _xmlEncoding, null));

                node = xml.AppendChild(xml.CreateNode(XmlNodeType.Element, _itemsNode, null));

                foreach (Item item in ItemsList.Items) {
                    itemNode = xml.CreateNode(XmlNodeType.Element, _itemNode, null);

                    #region Comments

                    if (item.Comments.Count > 0) {
                        foreach (var comment in item.Comments) {
                            if (comment.inside) {
                                itemNode.AppendChild(xml.CreateNode(XmlNodeType.Comment, "", "")).Value = comment.text;
                            } else {
                                node.AppendChild(xml.CreateNode(XmlNodeType.Comment, "", "")).Value = comment.text;
                            }
                        }
                    }

                    #endregion

                    #region Attributes

                    if (item.FromID == item.ToID) {
                        itemNode.Attributes.Append(xml.CreateAttribute("id")).Value = item.FromID.ToString();
                    } else {
                        itemNode.Attributes.Append(xml.CreateAttribute("fromid")).Value = item.FromID.ToString();
                        itemNode.Attributes.Append(xml.CreateAttribute("toid")).Value = item.ToID.ToString();
                    }
                
                    if (item.Article.Length > 0) {
                        itemNode.Attributes.Append(xml.CreateAttribute("article")).Value = item.Article.ToString();
                    }

                    if (item.Name.Length > 0) {
                        itemNode.Attributes.Append(xml.CreateAttribute("name")).Value = item.Name.ToString();
                    }
                
                    if (item.Plural.Length > 0) {
                        itemNode.Attributes.Append(xml.CreateAttribute("plural")).Value = item.Plural.ToString();
                    }

                    if (item.EditorSuffix.Length > 0) {
                        itemNode.Attributes.Append(xml.CreateAttribute("editorsuffix")).Value = item.EditorSuffix.ToString();
                    }

                    #endregion

                    #region Childs

                    #region Strings

                    if (item.Type.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "type";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Type;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Description.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "description";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Description;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.RuneSpellName.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "runespellname";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.RuneSpellName;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.FloorChange.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "floorchange";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FloorChange;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.CorpseType.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "corpseType";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.CorpseType;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.FluidSource.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "fluidsource";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FluidSource;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.WeaponType.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "weaponType";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.WeaponType;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.SlotType.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "slotType";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SlotType;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.AmmoType.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "ammotype";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AmmoType;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.ShootType.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "shootType";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ShootType;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Effect.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "effect";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Effect;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.LootType.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "loottype";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.LootType;
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Field_Type.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "field";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Field_Type;
                                        
                        if (item.FieldTicks != int.MinValue) {
                            childAttributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "ticks";
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FieldTicks.ToString();
                            attributeNode.AppendChild(childAttributeNode);
                        }
                        
                        if (item.FieldCount != int.MinValue) {
                            childAttributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "count";
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FieldCount.ToString();
                            attributeNode.AppendChild(childAttributeNode);
                        }
                        
                        if (item.FieldDamage != int.MinValue) {
                            childAttributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "damage";
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FieldDamage.ToString();
                            attributeNode.AppendChild(childAttributeNode);
                        }
                        
                        if (item.FieldStart != int.MinValue) {
                            childAttributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "start";
                            childAttributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FieldStart.ToString();
                            attributeNode.AppendChild(childAttributeNode);
                        }

                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.PartnerDirection.Length > 0) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "partnerdirection";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.PartnerDirection;
                        itemNode.AppendChild(attributeNode);
                    }

                    #endregion

                    #region Boolean

                    if (item.DistanceRead != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "allowdistread";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.DistanceRead ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Blocking != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "blocking";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Blocking ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.WalkStack != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "walkstack";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.WalkStack ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Replaceable != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "replaceable";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Replaceable ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressCurse != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppresscurse";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressCurse ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressDazzle != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressdazzle";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressDazzle ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressFreeze != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressfreeze";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressFreeze ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressPhysical != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressphysical";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressPhysical ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressDrown != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressdrown";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressDrown ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressPoison != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppresspoison";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressPoison ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressFire != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressfire";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressFire ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressEnergy != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressenergy";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressEnergy ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SuppressDrunk != false) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "suppressdrunk";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SuppressDrunk ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ManaShield != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "manashield";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.ManaShield ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Invisible != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "invisible";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Invisible ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ShowCount != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "showCount";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.ShowCount ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.WrapContainer != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "wrapcontainer";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.WrapContainer ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Moveable != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "moveable";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Moveable ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.IsPodium != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "isPodium";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.IsPodium ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.BlockProjectile != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "blockProjectile";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.BlockProjectile ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Pickupable != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "allowpickUpAble";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Pickupable ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Readable != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "readable";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Readable ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.Writeable != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "writeable";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.Writeable ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.StopDuration != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "stopduration";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.StopDuration ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.ShowDuration != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "showduration";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.ShowDuration ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.ShowCharges != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "showCharges";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.ShowCharges ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }
                
                    if (item.ShowAttributes != null) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "showAttributes";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = (bool)item.ShowAttributes ? "1" : "0";
                        itemNode.AppendChild(attributeNode);
                    }

                    #endregion

                    #region Integrers
                
                    if (item.ElementHoly != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "elementholy";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ElementHoly.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ElementDeath != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "elementdeath";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ElementDeath.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ElementEnergy != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "elementenergy";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ElementEnergy.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ElementFire != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "elementfire";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ElementFire.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ElementEarth != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "elementearth";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ElementEarth.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ElementIce != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "elementice";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ElementIce.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.DestroyTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "destroyto";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.DestroyTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.TransformTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "transformto";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.TransformTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.FemaleTransformTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "femalesleeper";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.FemaleTransformTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaleTransformTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "malesleeper";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaleTransformTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.LevelDoor != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "levelDoor";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.LevelDoor.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbHealing != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercenthealing";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbHealing.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbPhysical != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentphysical";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbPhysical.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbDrown != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentdrown";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbDrown.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbManaDrain != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentmanadrain";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbManaDrain.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbLifeDrain != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentlifedrain";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbLifeDrain.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbDeath != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentdeath";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbDeath.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbHoly != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentholy";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbHoly.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbIce != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentice";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbIce.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbPoison != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentpoison";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbPoison.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbFire != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentfire";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbFire.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbEnergy != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentenergy";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbEnergy.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbMagic != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentmagic";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbMagic.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbElements != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentelements";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbElements.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbAll != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "absorbpercentall";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbAll.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbFieldPoison != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "fieldabsorbpercentpoison";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbFieldPoison.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbFieldFire != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "fieldabsorbpercentfire";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbFieldFire.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.AbsorbFieldEnergy != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "fieldabsorbpercentenergy";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.AbsorbFieldEnergy.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MagicLevelPercent != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "magicpointspercent";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MagicLevelPercent.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MagicLevel != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "magicLevelPoints";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MagicLevel.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaxManaPointsPercent != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "maxmanapointspercent";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaxManaPointsPercent.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaxManaPoints != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "maxmanapoints";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaxManaPoints.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaxHitPointsPercent != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "maxhitpointspercent";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaxHitPointsPercent.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaxHitPoints != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "maxhitpoints";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaxHitPoints.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillManaAmount != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillmanaamount";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillManaAmount.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillManaChance != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillmanachance";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillManaChance.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillLifeAmount != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skilllifeamount";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillLifeAmount.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillLifeChance != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skilllifechance";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillLifeChance.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillCriticalDamage != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillcriticaldamage";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillCriticalDamage.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillCriticalChance != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillcriticalchance";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillCriticalChance.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillFish != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillfish";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillFish.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillShield != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillshield";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillShield.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillFist != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillfist";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillFist.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillDistance != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skilldist";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillDistance.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillClub != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillclub";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillClub.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillAxe != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillaxe";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillAxe.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.SkillSword != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "skillsword";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.SkillSword.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ManaTicks != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "manaticks";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ManaTicks.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ManaGain != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "managain";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ManaGain.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.HealthTicks != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "healthticks";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.HealthTicks.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.HealthGain != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "healthgain";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.HealthGain.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Speed != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "speed";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Speed.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaxHitChance != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "maxhitchance";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaxHitChance.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.HitChance != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "hitchance";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.HitChance.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Charges != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "charges";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Charges.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Duration != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "duration";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Duration.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.DequipTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "transformdeequipto";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.DequipTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.EquipTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "transformequipto";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.EquipTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.DecayTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "decayTo";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.DecayTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Range != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "range";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Range.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.WriteOnceItemId != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "writeonceitemid";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.WriteOnceItemId.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.MaxTextLenght != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "maxtextlen";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.MaxTextLenght.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ContainerSize != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "containersize";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ContainerSize.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.WrapableTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "wrapableto"; // There is 'unwrapableto' tag on the OTBR item loader, but they end on the same place so i'm ignoring it here.
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.WrapableTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ImbuingSlots != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "imbuingslots";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ImbuingSlots.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.RotateTo != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "rotateto";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.RotateTo.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Attack != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "attack";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Attack.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.ExtraDefense != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "extradef";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.ExtraDefense.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Defense != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "defense";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Defense.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Armor != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "armor";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Armor.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    if (item.Weight != int.MinValue) {
                        attributeNode = xml.CreateNode(XmlNodeType.Element, _itemChildNode, null);
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childKey)).Value = "weight";
                        attributeNode.Attributes.Append(xml.CreateAttribute(_childValue)).Value = item.Weight.ToString();
                        itemNode.AppendChild(attributeNode);
                    }

                    #endregion

                    #endregion

                    node.AppendChild(itemNode);
                }

                xml.Save(fs);
            }
        }

        public bool LoadXMLFile()
        {
            FileDialog xmlDialog = new OpenFileDialog
            {
                Filter = "XML file (*.xml)|*.xml",
                Title = "Open XML File"
            };

            if ((bool)xmlDialog.ShowDialog() == false) {
                return false;
            }

            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(xmlDialog.FileName);

                XmlNode itemsNode = xml.LastChild;
                if (itemsNode == null || itemsNode.Name != _itemsNode || itemsNode.ChildNodes.Count == 0) {
                    throw new Exception("'" + _itemsNode + "' node could not be found or is empty.");
                }

                ClearLog();
                ItemsList.BeginInit();
                ItemsList.Items.Clear();
                string comment = string.Empty;
                foreach (XmlNode itemNode in itemsNode.ChildNodes) {
                    if (itemNode.NodeType == XmlNodeType.Comment) {
                        comment = itemNode.Value;
                        continue;
                    } else if (itemNode.Name != _itemNode) {
                        throw new Exception("'" + _itemNode + "' node was expected inside '" + _itemsNode + "', got '" + itemNode.Name + "'.");
                    }

                    Item item = new Item(string.Empty, -1, -1);

                    if (comment.Length > 0) {
                        item.Comments.Add((comment, false));
                        comment = string.Empty;
                    }

                    foreach (XmlAttribute attribute in itemNode.Attributes) {
                        if (attribute.NodeType == XmlNodeType.Comment) {
                            item.Comments.Add((attribute.InnerText, true));
                            continue;
                        }

                        string value = attribute.Value;
                        if (value.Length == 0) {
                            continue;
                        }

                        switch (attribute.Name) {
                            case "id": {
                                    item.FromID = int.Parse(value);
                                    item.ToID = int.Parse(value);
                                    break;
                                }
                            case "fromid": {
                                    item.FromID = int.Parse(value);
                                    break;
                                }
                            case "toid": {
                                    item.ToID = int.Parse(value);
                                    break;
                                }
                            case "name": {
                                    item.Name = value;
                                    break;
                                }
                            case "article": {
                                    item.Article = value;
                                    break;
                                }
                            case "plural": {
                                    item.Plural = value;
                                    break;
                                }
                            case "editorsuffix": {
                                    item.EditorSuffix = value;
                                    break;
                                }
                            default: {
                                    AppendLog("[ID: " + item.FromID + "] Unknown item attributte '" + attribute.Name + "'");
                                    continue;
                                }
                        }
                    }

                    if (item.FromID == -1 || item.ToID == -1) {
                        AppendLog("Item registered has invalid itemid: FromID: " + item.FromID + " ToID: " + item.ToID + " Name: " + item.Name);
                        continue;
                    }

                    if (item.ToID > _lastItemId) {
                        _lastItemId = item.ToID;
                    }

                    if (itemNode.ChildNodes.Count > 0) {
                        foreach (XmlNode itemChildNode in itemNode.ChildNodes) {
                            if (itemChildNode.NodeType == XmlNodeType.Comment) {
                                item.Comments.Add((itemChildNode.InnerText, true));
                                continue;
                            } else if (itemChildNode.Name != _itemChildNode) {
                                throw new Exception("'" + _itemChildNode + "' node was expected inside '" + _itemNode + "', got '" + itemChildNode.Name + "'.");
                            }

                            string childKey = string.Empty;
                            string childValue = string.Empty;
                            foreach (XmlAttribute childAttribute in itemChildNode.Attributes) {
                                if (childAttribute.NodeType == XmlNodeType.Comment) {
                                    item.Comments.Add((childAttribute.InnerText, true));
                                    continue;
                                } else if (childAttribute.Name == _childKey) {
                                    childKey = childAttribute.Value;
                                } else if (childAttribute.Name == _childValue) {
                                    childValue = childAttribute.Value;
                                } else {
                                    AppendLog("[ID: " + item.FromID + "] '" + _childKey + "' or '" + _childValue + "' node was expected inside '" + _itemChildNode + "', got '" + childAttribute.Name + "'.");
                                    continue;
                                }
                            }

                            bool error = true;
                            childKey = childKey.ToLower();

                            if (childValue.ToLower() == "true") {
                                childValue = "1";
                            } else if (childValue.ToLower() == "false") {
                                childValue = "0";
                            }

                            #region Strings
                            switch (childKey) {
                                case "type": {
                                        item.Type = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "description": {
                                        item.Description = childValue;
                                        error = false;
                                        break;
                                    }
                                case "runespellname": {
                                        item.RuneSpellName = childValue;
                                        error = false;
                                        break;
                                    }
                                case "floorchange": {
                                        item.FloorChange = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "corpsetype": {
                                        item.CorpseType = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "fluidsource": {
                                        item.FluidSource = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "weapontype": {
                                        item.WeaponType = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "slottype": {
                                        item.SlotType = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "ammotype": {
                                        item.AmmoType = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "shoottype": {
                                        item.ShootType = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "effect": {
                                        item.Effect = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "loottype": {
                                        item.LootType = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                case "field": {
                                        item.Field_Type = childValue.ToLower();
                                        error = false;
                                        if (itemChildNode.ChildNodes.Count > 0) {
                                            foreach (XmlNode fieldNode in itemChildNode.ChildNodes) {
                                                if (fieldNode.Name != _itemChildNode) {
                                                    throw new Exception("'" + _itemChildNode + "' node was expected inside '" + _itemNode + "', got '" + fieldNode.Name + "'.");
                                                }
                                                
                                                string fieldChildKey = string.Empty;
                                                string fieldChildValue = string.Empty;
                                                foreach (XmlAttribute fieldChildAttribute in fieldNode.Attributes) {
                                                    if (fieldChildAttribute.Name == _childKey) {
                                                        fieldChildKey = fieldChildAttribute.Value;
                                                    } else if (fieldChildAttribute.Name == _childValue) {
                                                        fieldChildValue = fieldChildAttribute.Value;
                                                    } else {
                                                        throw new Exception("'" + _childKey + "' or '" + _childValue + "' node was expected inside '" + _itemChildNode + "' on 'field', got '" + fieldChildAttribute.Name + "'.");
                                                    }
                                                }

                                                fieldChildKey = fieldChildKey.ToLower();
                                                switch (fieldChildKey) {
                                                    case "ticks": {
                                                            item.FieldTicks = int.Parse(fieldChildValue);
                                                            break;
                                                        }
                                                    case "count": {
                                                            item.FieldCount = int.Parse(fieldChildValue);
                                                            break;
                                                        }
                                                    case "start": {
                                                            item.FieldStart = int.Parse(fieldChildValue);
                                                            break;
                                                        }
                                                    case "damage": {
                                                            item.FieldDamage = int.Parse(fieldChildValue);
                                                            break;
                                                        }
                                                    default: {
                                                            throw new Exception("Unknown field attribute value inside '" + fieldChildKey + "' key, got '" + fieldChildKey + "'.");
                                                        }
                                                }
                                            }

                                        }
                                        break;
                                    }
                                case "partnerdirection": {
                                        item.PartnerDirection = childValue.ToLower();
                                        error = false;
                                        break;
                                    }
                                default: {
                                        break;
                                    }
                            }
                            #endregion

                            if (!error) {
                                continue;
                            }

                            if (!ValidateStringParseToInt(childValue)) {
                                AppendLog("[ID: " + item.FromID + "] Item invalid '" + _itemChildNode + "' value at '" + childKey + "' attribute, int or boolean value was expected, got '" + childValue + "'.");
                                continue;
                            }

                            int childValueInt = int.Parse(childValue);

                            #region Int
                            switch (childKey) {
                                case "weight": {
                                        item.Weight = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "armor": {
                                        item.Armor = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "defense": {
                                        item.Defense = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "extradef": {
                                        item.ExtraDefense = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "attack": {
                                        item.Attack = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "rotateto": {
                                        item.RotateTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "imbuingslots": {
                                        item.ImbuingSlots = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "wrapableto": {
                                        item.WrapableTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "unwrapableto": {
                                        item.WrapableTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "containersize": {
                                        item.ContainerSize = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maxtextlen": {
                                        item.MaxTextLenght = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "writeonceitemid": {
                                        item.WriteOnceItemId = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "range": {
                                        item.Range = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "decayto": {
                                        item.DecayTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "transformequipto": {
                                        item.EquipTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "transformdeequipto": {
                                        item.DequipTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "duration": {
                                        item.Duration = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "charges": {
                                        item.Charges = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "hitchance": {
                                        item.HitChance = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maxhitchance": {
                                        item.MaxHitChance = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "speed": {
                                        item.Speed = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "healthgain": {
                                        item.HealthGain = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "healthticks": {
                                        item.HealthTicks = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "managain": {
                                        item.ManaGain = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "manaticks": {
                                        item.ManaTicks = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillsword": {
                                        item.SkillSword = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillaxe": {
                                        item.SkillAxe = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillclub": {
                                        item.SkillClub = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skilldist": {
                                        item.SkillDistance = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillfish": {
                                        item.SkillFish = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillshield": {
                                        item.SkillShield = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillfist": {
                                        item.SkillFist = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillcriticalchance": {
                                        item.SkillCriticalChance = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillcriticaldamage": {
                                        item.SkillCriticalDamage = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skilllifechance": {
                                        item.SkillLifeChance = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skilllifeamount": {
                                        item.SkillLifeAmount = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillmanachance": {
                                        item.SkillManaChance = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "skillmanaamount": {
                                        item.SkillManaAmount = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maxhitpoints": {
                                        item.MaxHitPoints = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maxhitpointspercent": {
                                        item.MaxHitPointsPercent = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maxmanapoints": {
                                        item.MaxManaPoints = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maxmanapointspercent": {
                                        item.MaxManaPointsPercent = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "magicpoints": {
                                        item.MagicLevel = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "magiclevelpoints": {
                                        item.MagicLevel = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "magicpointspercent": {
                                        item.MagicLevelPercent = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "fieldabsorbpercentenergy": {
                                        item.AbsorbFieldEnergy = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "fieldabsorbpercentfire": {
                                        item.AbsorbFieldFire = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "fieldabsorbpercentpoison": {
                                        item.AbsorbFieldPoison = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "fieldabsorpercentearth": {
                                        item.AbsorbFieldPoison = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentall": {
                                        item.AbsorbAll = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentallelements": {
                                        item.AbsorbAll = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentelements": {
                                        item.AbsorbElements = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentmagic": {
                                        item.AbsorbMagic = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentenergy": {
                                        item.AbsorbEnergy = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentfire": {
                                        item.AbsorbFire = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentpoison": {
                                        item.AbsorbPoison = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentearth": {
                                        item.AbsorbPoison = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentice": {
                                        item.AbsorbIce = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentholy": {
                                        item.AbsorbHoly = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentdeath": {
                                        item.AbsorbDeath = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentlifedrain": {
                                        item.AbsorbLifeDrain = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentmanadrain": {
                                        item.AbsorbManaDrain = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentdrown": {
                                        item.AbsorbDrown = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercentphysical": {
                                        item.AbsorbPhysical = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "absorbpercenthealing": {
                                        item.AbsorbHealing = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "leveldoor": {
                                        item.LevelDoor = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "maletransformto": {
                                        item.MaleTransformTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "malesleeper": {
                                        item.MaleTransformTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "femaletransformto": {
                                        item.FemaleTransformTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "femalesleeper": {
                                        item.FemaleTransformTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "transformto": {
                                        item.TransformTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "destroyto": {
                                        item.DestroyTo = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "elementice": {
                                        item.ElementIce = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "elementearth": {
                                        item.ElementEarth = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "elementfire": {
                                        item.ElementFire = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "elementenergy": {
                                        item.ElementEnergy = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "elementdeath": {
                                        item.ElementDeath = childValueInt;
                                        error = false;
                                        break;
                                    }
                                case "elementholy": {
                                        item.ElementHoly = childValueInt;
                                        error = false;
                                        break;
                                    }
                            }
                            #endregion
                            
                            if (!error) {
                                continue;
                            }

                            bool childValueBool = childValueInt != 0;

                            #region Boolean
                            switch (childKey) {
                                case "manashield": {
                                        item.ManaShield = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "invisible": {
                                        item.Invisible = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "showcharges": {
                                        item.ShowCharges = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "showattributes": {
                                        item.ShowAttributes = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "stopduration": {
                                        item.StopDuration = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "readable": {
                                        item.Readable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "writeable": {
                                        item.Writeable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "moveable": {
                                        item.Moveable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "movable": {
                                        item.Moveable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "ispodium": {
                                        item.IsPodium = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "blockprojectile": {
                                        item.BlockProjectile = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "allowpickupable": {
                                        item.Pickupable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "pickupable": {
                                        item.Pickupable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "wrapcontainer": {
                                        item.WrapContainer = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "showduration": {
                                        item.ShowDuration = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressdrunk": {
                                        item.SuppressDrunk = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressenergy": {
                                        item.SuppressEnergy = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressfire": {
                                        item.SuppressFire = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppresspoison": {
                                        item.SuppressPoison = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressdrown": {
                                        item.SuppressDrown = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressphysical": {
                                        item.SuppressPhysical = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressfreeze": {
                                        item.SuppressFreeze = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppressdazzle": {
                                        item.SuppressDazzle = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "suppresscurse": {
                                        item.SuppressCurse = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "replaceable": {
                                        item.Replaceable = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "walkstack": {
                                        item.WalkStack = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "blocking": {
                                        item.Blocking = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "showcount": {
                                        item.ShowCount = childValueBool;
                                        error = false;
                                        break;
                                    }
                                case "allowdistread": {
                                        item.DistanceRead = childValueBool;
                                        error = false;
                                        break;
                                    }
                            }
                            #endregion

                            if (error) {
                                AppendLog("[ID: " + item.FromID + "] Item with unknown '" + _itemChildNode + "' attribute key, got '" + childKey + "'.");
                            }
                        }
                    }

                    ItemsList.Items.Add(item);
                }

                ItemsList.Items.SortDescriptions.Clear();
                ItemsList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FromID", System.ComponentModel.ListSortDirection.Ascending));
                ItemsList.EndInit();

                ShowLog();
            } catch (Exception ex) {
                MessageBox.Show("[ERROR] " + ex.Message);
                return false;
            }
            return true;
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            InitializeItemType();
            InitializeFloorChange();
            InitializeCorpseType();
            InitializeFluidSource();
            InitializeWeaponType();
            InitializeSlotType();
            InitializeAmmoType();
            InitializeShootType();
            InitializeMagicEffect();
            InitializeLootType();
            InitializePartnerDir();
            InitializeFieldType();
            InitializeSearchMethod();
            InitializeSort();

            _hasChange = false;
            SaveItemButton.IsEnabled = false;
        }

    }
}
