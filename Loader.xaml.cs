using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using static System.Globalization.CultureInfo;
using System.Net;
using System.ComponentModel;
using System.IO;
using Items.Protobuf.Appearances;
using System.Linq;

namespace Devm_items_editor
{
    /// <summary>
    /// Interaction logic for Loader.xaml
    /// </summary>
    public partial class Loader : Window
    {
        #region Enums and utils

        private ItemCollection _filters;

        private MainWindow _parent;

        private static string _assetsPath = "";

        private static string _otbPath = "";

        private Stopwatch _stopWatch;

        private BackgroundWorker _asyncWorker;

        private List<Item> _asyncItems = new List<Item>();

        class WikiObject
        {
            public WikiObject()
            {

            }

            #region Definitions and JSON Property
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("article")]
            public string Article { get; set; }

            [JsonProperty("actualname")]
            public string ActualName { get; set; }

            [JsonProperty("plural")]
            public string Plural { get; set; }

            [JsonProperty("implemented")]
            public string Implemented { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("history")]
            public string History { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("templateType")]
            public string TemplateType { get; set; }

            [JsonProperty("itemid")]
            public List<string> IDs { get; set; }

            [JsonProperty("primarytype")]
            public string PrimaryType { get; set; }

            [JsonProperty("sprites")]
            public string Sprites { get; set; }

            [JsonProperty("objectclass")]
            public string ObjectClass { get; set; }

            [JsonProperty("secondarytype")]
            public string SecondaryType { get; set; }

            [JsonProperty("tertiarytype")]
            public string TertiaryType { get; set; }

            [JsonProperty("flavortext")]
            public string FlavorText { get; set; }

            [JsonProperty("words")]
            public string Words { get; set; }

            [JsonProperty("sounds")]
            public List<string> Sounds { get; set; }

            [JsonProperty("lightradius")]
            public string LightRadius { get; set; }

            [JsonProperty("lightcolor")]
            public string LightColor { get; set; }

            [JsonProperty("volume")]
            public string Volume { get; set; }

            [JsonProperty("destructable")]
            public string Destructable { get; set; }

            [JsonProperty("immobile")]
            public string Immobile { get; set; }

            [JsonProperty("walkable")]
            public string Walkable { get; set; }

            [JsonProperty("walkingspeed")]
            public string WalkingSpeed { get; set; }

            [JsonProperty("unshootable")]
            public string Unshootable { get; set; }

            [JsonProperty("blockspath")]
            public string BlocksPath { get; set; }

            [JsonProperty("pickupable")]
            public string Pickupable { get; set; }

            [JsonProperty("holdsliquid")]
            public string HoldsLiquid { get; set; }

            [JsonProperty("usable")]
            public string Usable { get; set; }

            [JsonProperty("writable")]
            public string Writable { get; set; }

            [JsonProperty("rewritable")]
            public string ReWritable { get; set; }

            [JsonProperty("writechars")]
            public string WriteChars { get; set; }

            [JsonProperty("levelrequired")]
            public string LevelRequired { get; set; }

            [JsonProperty("vocrequired")]
            public string VocRequired { get; set; }

            [JsonProperty("mlrequired")]
            public string MagiclevelRequired { get; set; }

            [JsonProperty("hands")]
            public Hands_t Hand { get; set; }

            [JsonProperty("weapontype")]
            public Weapon_t WeaponType { get; set; }

            [JsonProperty("attack")]
            public string Attack { get; set; }

            [JsonProperty("fire_attack")]
            public string FireAttack { get; set; }

            [JsonProperty("earth_attack")]
            public string EarthAttack { get; set; }

            [JsonProperty("ice_attack")]
            public string IceAttack { get; set; }

            [JsonProperty("energy_attack")]
            public string EnergyAttack { get; set; }

            [JsonProperty("death_attack")]
            public string DeathAttack { get; set; }

            [JsonProperty("defense")]
            public string Defense { get; set; }

            [JsonProperty("defensemod")]
            public string DefenseMod { get; set; }

            [JsonProperty("imbueslots")]
            public string ImbueSlot { get; set; }

            [JsonProperty("imbuements")]
            public string Imbuements { get; set; }

            [JsonProperty("enchantable")]
            public string Enchantable { get; set; }

            [JsonProperty("enchanted")]
            public string Enchanted { get; set; }

            [JsonProperty("range")]
            public string Range { get; set; }

            [JsonProperty("atk_mod")]
            public string AttackModification { get; set; }

            [JsonProperty("hit_mod")]
            public string HitPostringsModification { get; set; }

            [JsonProperty("crithit_ch")]
            public string CriticalHitChange { get; set; }

            [JsonProperty("critextra_dmg")]
            public string CriticalHitDamage { get; set; }

            [JsonProperty("manaleech_ch")]
            public string ManaLeechChance { get; set; }

            [JsonProperty("manaleech_am")]
            public string ManaLeechAmount { get; set; }

            [JsonProperty("hpleech_ch")]
            public string LifeLeechChance { get; set; }

            [JsonProperty("hpleech_am")]
            public string LifeLeechAmount { get; set; }

            [JsonProperty("manacost")]
            public string ManaCost { get; set; }

            [JsonProperty("damagetype")]
            public DamageElement_t Element { get; set; }

            [JsonProperty("damagerange")]
            public string DamageRange { get; set; }

            [JsonProperty("attrib")]
            public string Attribute { get; set; }

            [JsonProperty("charges")]
            public string Charges { get; set; }

            [JsonProperty("armor")]
            public string Armor { get; set; }

            [JsonProperty("resist")]
            public string Resist { get; set; }

            [JsonProperty("weight")]
            public string Weight { get; set; } // Need to format it to remove the dot '.' on it.

            [JsonProperty("stackable")]
            public string Stackable { get; set; }

            [JsonProperty("marketable")]
            public string Marketable { get; set; }

            [JsonProperty("consumable")]
            public string Consumable { get; set; }

            [JsonProperty("regenseconds")]
            public string RegenPerSeconds { get; set; }

            [JsonProperty("hangable")]
            public string Hangable { get; set; }

            [JsonProperty("duration")]
            public string Duration { get; set; }

            [JsonProperty("destructible")]
            public string Destructible { get; set; }

            [JsonProperty("rotatable")]
            public string Rotatable { get; set; }

            [JsonProperty("mapcolor")]
            public string ColorOnMap { get; set; }

            [JsonProperty("droppedby")]
            public List<string> DropFrom { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("storevalue")]
            public string StoreValue { get; set; }

            [JsonProperty("npcvalue")]
            public string NpcValue { get; set; }

            [JsonProperty("npcprice")]
            public string NpcPrice { get; set; }

            [JsonProperty("npcvaluerook")]
            public string NpcValueRook { get; set; }

            [JsonProperty("npcpricerook")]
            public string NpcPriceRook { get; set; }

            [JsonProperty("buyfrom")]
            public string BuyFrom { get; set; }

            [JsonProperty("sellto")]
            public string SellTo { get; set; }

            [JsonProperty("fansite")]
            public string FanSite { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("notes2")]
            public string Notes2 { get; set; }
            #endregion
        }

        #endregion

        #region Async wiki worker
        public void InitializeWikiLoader()
        {
            TitleName.Text = "Loading item data from tibia wiki.";
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

            _asyncWorker = new BackgroundWorker();
            _asyncWorker.WorkerReportsProgress = true;
            _asyncWorker.ProgressChanged += WikiLoaderWorkerChanged;
            _asyncWorker.DoWork += WikiLoaderWorkerAction;
            _asyncWorker.RunWorkerCompleted += WikiLoaderWorkerCompleted;
            _asyncWorker.WorkerSupportsCancellation = true;
            if (_asyncWorker.IsBusy != true)
                _asyncWorker.RunWorkerAsync();
        }

        private void WikiLoaderWorkerChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            LoadBar.Value = progress;
            LoadNumber.Text = progress.ToString() + "%";
        }

        private void WikiLoaderWorkerAction(object sender, DoWorkEventArgs e)
        {
            int errors = 0;
            int success = 0;
            int ignored = 0;
            int exceptions = 0;
            int totalItems = _parent.ItemsList.Items.Count;
            _parent.ItemsList.BeginInit();
            WebClient client = new WebClient();
            try
            {
                client.Proxy = null;
                var info = GetCultureInfo("en-gb").TextInfo;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                int proggress = 0;
                foreach (Item item in _parent.ItemsList.Items) {
                    if (_asyncWorker.CancellationPending) {
                        break;
                    }

                    bool allItems = false;
                    bool ignoreType = true;
                    foreach (ComboBox_t box in _filters) {
                        if (box.FilterChecked) {
                            if (box.Xml[0].Length == 0) {
                                // This one include all items. This can take realy long time to finish.
                                allItems = true;
                                break;
                            } else if (item.Type.Length > 0 && box.Xml.Contains(item.LootType)) {
                                ignoreType = false;
                                break;
                            }
                        }
                    }


                    if (!allItems && ignoreType) {
                        //ignored++;
                        --totalItems;
                        continue;
                    }
                    
                    if (item.Name.Length == 0) {
                        ignored++;
                        --totalItems;
                        continue;
                    }
                    
                    _asyncWorker.ReportProgress((int)Math.Floor(((double)proggress / totalItems) * 100));
                    proggress++;

                    WikiObject wikiObject;
                    try {
                        string content = client.DownloadString(_parent._wikiUri + info.ToTitleCase(item.Name).Replace(' ', '_'));

                        // This validation ignore JSON that is irrelevant
                        if (content.Length <= 5) {
                            throw new Exception();
                        }

                        wikiObject = JsonConvert.DeserializeObject<WikiObject>(content, settings);
                    } catch {
                        // This exception can happen more than you thing. Some errors for it can be:
                        // - Item is not registered on WIKI.
                        // - Item data on wiki is irrelevant.
                        // - No internet connection.
                        // - Host refused connection.
                        // - Host could not find the item by it's name.
                        // Breaking the entire iteratior is not a good idea here because this can happen a lot.
                        exceptions++;
                        continue;
                    }

                    if (wikiObject != null) {
                        if (wikiObject.TemplateType == null || wikiObject.TemplateType != "Object" || wikiObject.ActualName == null) {
                            ignored++;
                            continue;
                        }

                        if (wikiObject.Article != null && wikiObject.Article.Length > 0) {
                            item.Article = wikiObject.Article;
                        }

                        // Empty plural are '?' char.
                        if (wikiObject.Plural != null && wikiObject.Plural.Length > 1) {
                            item.Plural = wikiObject.Plural;
                        }

                        if (wikiObject.FlavorText != null && wikiObject.FlavorText.Length > 0) {
                            item.Description = wikiObject.FlavorText;
                        }

                        if (wikiObject.Words != null && wikiObject.Words.Length > 0) {
                            item.RuneSpellName = wikiObject.Words;
                        }

                        item.ContainerSize = _parent.ParseStringToFinalInt(wikiObject.Volume, item.ContainerSize);
                        item.Attack = _parent.ParseStringToFinalInt(wikiObject.Attack, item.Attack);
                        item.ElementFire = _parent.ParseStringToFinalInt(wikiObject.FireAttack, item.ElementFire);
                        item.ElementDeath = _parent.ParseStringToFinalInt(wikiObject.DeathAttack, item.ElementDeath);
                        item.ElementEarth = _parent.ParseStringToFinalInt(wikiObject.EarthAttack, item.ElementEarth);
                        item.ElementEnergy = _parent.ParseStringToFinalInt(wikiObject.EnergyAttack, item.ElementEnergy);
                        item.ElementIce = _parent.ParseStringToFinalInt(wikiObject.IceAttack, item.ElementIce);
                        // Holy
                        item.Defense = _parent.ParseStringToFinalInt(wikiObject.Defense, item.Defense);
                        item.ExtraDefense = _parent.ParseStringToFinalInt(wikiObject.DefenseMod, item.ExtraDefense);
                        item.ImbuingSlots = _parent.ParseStringToFinalInt(wikiObject.ImbueSlot, item.ImbuingSlots);
                        item.Range = _parent.ParseStringToFinalInt(wikiObject.Range, item.Range);
                        item.SkillCriticalChance = _parent.ParseStringToFinalInt(wikiObject.CriticalHitChange, item.SkillCriticalChance);
                        item.SkillCriticalDamage = _parent.ParseStringToFinalInt(wikiObject.CriticalHitDamage, item.SkillCriticalDamage);
                        item.SkillManaChance = _parent.ParseStringToFinalInt(wikiObject.ManaLeechChance, item.SkillManaChance);
                        item.SkillManaAmount = _parent.ParseStringToFinalInt(wikiObject.ManaLeechAmount, item.SkillManaAmount);
                        item.SkillLifeChance = _parent.ParseStringToFinalInt(wikiObject.LifeLeechChance, item.SkillLifeChance);
                        item.SkillLifeAmount = _parent.ParseStringToFinalInt(wikiObject.LifeLeechAmount, item.SkillLifeAmount);
                        item.Charges = _parent.ParseStringToFinalInt(wikiObject.Charges, item.Charges);
                        item.Armor = _parent.ParseStringToFinalInt(wikiObject.Armor, item.Armor);
                        if (wikiObject.Weight != null) {
                            item.Weight = (int)(double.Parse(wikiObject.Weight, InvariantCulture) * 100);
                        }
                        item.Duration = _parent.ParseStringToFinalInt(wikiObject.Duration, item.Duration);
                        success++;

                        if (item.Tag.Length == 0) {
                            item.Tag = _parent._editedTag;
                        }
                    } else {
                        errors++;
                    }
                }

            } catch (Exception ex) {
                _parent.AppendLog("[WIKI ERROR]:");
                _parent.AppendLog(ex.Message);
                _parent.AppendLog("Rrror tracer:");
                _parent.AppendLog(ex.StackTrace);
            }

            _parent.AppendLog("Wiki API: (" + totalItems + " outdated items)");
            _parent.AppendLog("- " + success + " items updated.");
            _parent.AppendLog("- " + errors + " items failed.");
            _parent.AppendLog("- " + exceptions + " exceptions.");
            _parent.AppendLog("- " + ignored + " ignored.");
            _parent.AppendLog("");
            _parent.AppendLog("Time elapsed: " + TimeSpan.FromSeconds(_stopWatch.Elapsed.TotalSeconds).ToString(@"hh\:mm\:ss"));
            _parent.AppendLog("");
            _parent.AppendLog("* Exceptions can happen due to:");
            _parent.AppendLog("- Internet connection has failed.");
            _parent.AppendLog("- API refused connection.");
            _parent.AppendLog("- API could not find the item by it's name.");
            _parent.AppendLog("- Item not registered on wiki.");
            _parent.AppendLog("- Items with custom names.");
            client.Dispose();
        }

        private void WikiLoaderWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _parent.ItemsList.EndInit();
            _stopWatch.Stop();
            _parent.Show();
            _parent.ShowLog();
            Close();
            _parent._asyncLoader = null;
        }
        #endregion

        #region Async assets worker
        public void InitializeAssetsLoader()
        {
            TitleName.Text = "Loading your client 12 assets file.";
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

            _asyncWorker = new BackgroundWorker();
            _asyncWorker.WorkerReportsProgress = true;
            _asyncWorker.ProgressChanged += AssetsLoaderWorkerChanged;
            _asyncWorker.DoWork += AssetsLoaderWorkerAction;
            _asyncWorker.RunWorkerCompleted += AssetsLoaderWorkerCompleted;
            _asyncWorker.WorkerSupportsCancellation = true;
            if (_asyncWorker.IsBusy != true)
                _asyncWorker.RunWorkerAsync();
        }

        private void AssetsLoaderWorkerChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            LoadBar.Value = progress;
            LoadNumber.Text = progress.ToString() + "%";
        }

        private void AssetsLoaderWorkerAction(object sender, DoWorkEventArgs e)
        {
            int ignored = 0;
            int created = 0;
            int changed = 0;

            _parent.ItemsList.BeginInit();
            try
            {
                using (FileStream fs = File.Open(_assetsPath, FileMode.Open))
                {
                    Appearances appearances = Appearances.Parser.ParseFrom(fs);
                    if (appearances == null || appearances.Object.Count == 0) {
                        throw new Exception("Invalid protobuf file.");
                    }

                    int proggress = 0;
                    foreach (Appearance itemObject in appearances.Object) {
                        if (_asyncWorker.CancellationPending) {
                            break;
                        }

                        _asyncWorker.ReportProgress((int)Math.Floor(((double)proggress / appearances.Object.Count) * 100));
                        proggress++;

                        Item item = _parent.GetItemByID((int)itemObject.Id, true);
                        if (item == null) {
                            item = _parent.CreateNewItem((int)itemObject.Id, itemObject.Name, itemObject.Description, false, true);
                            if (item == null) {
                                ignored++;
                                continue;
                            }
                            _asyncItems.Add(item);
                            created++;
                        } else {
                            bool isChanged = false;
                            if (itemObject.Name.Length > 0 && itemObject.Name.ToLower() != item.Name.ToLower()) {
                                item.Name = itemObject.Name;
                                isChanged = true;
                            }

                            if (itemObject.Description.Length > 0 && itemObject.Description.ToLower() != item.Description.ToLower()) {
                                item.Description = itemObject.Description;
                                isChanged = true;
                            }

                            if (itemObject.Flags != null) {
                                if (itemObject.Flags.Market != null) {
                                    string lootType = _parent.ParseProtobufItemCategoryToLootType(itemObject.Flags.Market.Category);
                                    if (lootType.ToLower() != item.LootType.ToLower()) {
                                        item.LootType = lootType;
                                        isChanged = true;
                                    }
                                }

                                if (itemObject.Flags.ShowOffSocket) {
                                    item.IsPodium = true;
                                }

                                if (itemObject.Flags.Upgradeclassification != null) {
                                    item.UpgradeClassification = (int)(itemObject.Flags.Upgradeclassification.UpgradeClassification);
                                }

                            }

                            if (isChanged) {
                                changed++;
                                if (item.Tag.Length == 0) {
                                    item.Tag = _parent._editedTag;
                                }
                            } else {
                                ignored++;
                            }
                        }
                    }
                }

                _asyncItems = _asyncItems.Distinct().ToList();
            } catch (Exception ex) {
                _parent.AppendLog("[PROTOBUFF ERROR]:");
                _parent.AppendLog(ex.Message);
                _parent.AppendLog("Rrror tracer:");
                _parent.AppendLog(ex.StackTrace);
            }

            _parent.AppendLog("Assets loader:");
            _parent.AppendLog("- " + created + " items created.");
            _parent.AppendLog("- " + changed + " items updated.");
            _parent.AppendLog("- " + ignored + " items ignored.");
            _parent.AppendLog("");
            _parent.AppendLog("* Items on assets can be ignored due to:");
            _parent.AppendLog("- Empty name or description.");
            _parent.AppendLog("- Item on xml is already up-to-date.");
        }

        private void AssetsLoaderWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_asyncItems.Count > 0) {
                foreach (Item item in _asyncItems) {
                    _parent.ItemsList.Items.Add(item);
                }
            }
            _parent.ItemsList.Items.Refresh();
            _parent.ItemsList.EndInit();
            _stopWatch.Stop();
            _parent.Show();
            _parent.ShowLog();
            Close();
            _parent._asyncLoader = null;
        }
        #endregion
        
        #region Async otb worker
        public void InitializeOTBLoader()
        {
            TitleName.Text = "Loading your items.otb file.";
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

            _asyncWorker = new BackgroundWorker();
            _asyncWorker.WorkerReportsProgress = true;
            _asyncWorker.ProgressChanged += OTBLoaderWorkerChanged;
            _asyncWorker.DoWork += OTBLoaderWorkerAction;
            _asyncWorker.RunWorkerCompleted += OTBLoaderWorkerCompleted;
            _asyncWorker.WorkerSupportsCancellation = true;
            if (_asyncWorker.IsBusy != true)
                _asyncWorker.RunWorkerAsync();
        }

        private void OTBLoaderWorkerChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            LoadBar.Value = progress;
            LoadNumber.Text = progress.ToString() + "%";
        }

        private void OTBLoaderWorkerAction(object sender, DoWorkEventArgs e)
        {
            try {
                _parent._itemConverterList = new List<(int ClientID, int ServerID)>();
                using (BinaryTreeReader reader = new BinaryTreeReader(_otbPath))
                {
                    // get root node
                    BinaryReader node = reader.GetRootNode();
                    if (node == null) {
                        throw new Exception("Error while parsing .otb file. #001");
                    }

                    // first byte of otb is 0
                    node.ReadByte();

                    // 4 bytes flags, unused
                    node.ReadUInt32();

                    byte attr = node.ReadByte();
                    if ((RootAttribute)attr == RootAttribute.Version) {
                        ushort datalen = node.ReadUInt16();
                        if (datalen != 140) { // 4 + 4 + 4 + 1 * 128
                            throw new Exception("Error while parsing .otb file. #002");
                        }

                        // major, file version
                        node.ReadUInt32();

                        // minor, client version
                        node.ReadUInt32();

                        // build number, revision
                        node.ReadUInt32();

                        node.BaseStream.Seek(128, SeekOrigin.Current);
                    }

                    node = reader.GetChildNode();
                    if (node == null) {
                        throw new Exception("Error while parsing .otb file. #003");
                    }

                    _asyncWorker.ReportProgress(50);
                    do {
                        if (_asyncWorker.CancellationPending) {
                            break;
                        }

                        // Group
                        ItemGroup group = (ItemGroup)node.ReadByte();

                        // Flags
                        node.ReadUInt32();

                        ushort serverID = 0;
                        ushort clientID = 0;
                        while (node.PeekChar() != -1) {
                            ItemAttribute attribute = (ItemAttribute)node.ReadByte();
                            ushort datalen = node.ReadUInt16();

                            switch (attribute) {
                                case ItemAttribute.ServerID: {
                                    serverID = node.ReadUInt16();
                                    break;
                                    }
                                case ItemAttribute.ClientID: {
                                        clientID = node.ReadUInt16();
                                        break;
                                    }
                                case ItemAttribute.GroundSpeed: {
                                        node.ReadUInt16();
                                        break;
                                    }
                                case ItemAttribute.Name: {
                                        node.ReadBytes(datalen);
                                        break;
                                    }
                                case ItemAttribute.SpriteHash: {
                                        node.ReadBytes(datalen);
                                        break;
                                    }
                                case ItemAttribute.MinimaColor: {
                                        node.ReadUInt16();
                                        break;
                                    }
                                case ItemAttribute.MaxReadWriteChars: {
                                        node.ReadUInt16();
                                        break;
                                    }
                                case ItemAttribute.MaxReadChars: {
                                    node.ReadUInt16();
                                    break;
                                    }
                                case ItemAttribute.Light: {
                                        node.ReadUInt16();
                                        node.ReadUInt16();
                                        break;
                                    }
                                case ItemAttribute.StackOrder: {
                                        node.ReadByte();
                                        break;
                                    }
                                case ItemAttribute.TradeAs: {
                                        node.ReadUInt16();
                                        break;
                                    }
                                default: {
                                        node.BaseStream.Seek(datalen, SeekOrigin.Current);
                                        break;
                                    }
                            }
                        }

                        _parent._itemConverterList.Add((clientID, serverID));
                        node = reader.GetNextNode();
                    } while (node != null);
                }

                _parent.AppendLog("OTB File succesfully loaded: " + _otbPath);
            } catch (Exception ex) {
                _parent.AppendLog("[ERROR::OTB] \n    Message: " + ex.Message +
                    "\n    Tracer: " + ex.StackTrace);
            }
        }

        private void OTBLoaderWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _parent.LoadXMLFile();
            _stopWatch.Stop();
            _parent.Show();
            _parent.ShowLog();
            Close();
            _parent._asyncLoader = null;
        }

        #endregion

        #region Callbacks
        private void Abort_Click(object sender, RoutedEventArgs e)
        {
            if (_asyncWorker.IsBusy) {
                _asyncWorker.CancelAsync();
            }
        }

        private void MouseDownToDrag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion

        public Loader(MainWindow parent, ItemCollection filters, string path)
        {
            InitializeComponent();

            _parent = parent;
            _filters = filters;
            _assetsPath = path;
        }
    }
}
