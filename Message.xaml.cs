using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Devm_items_editor
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        #region Enum and utils
        public MainWindow _parent;

        public ComboBox _filterBox;

        #endregion

        #region Callbacks

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            OnClosed(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            _parent._message = null;
            Close();
        }

        public void LoadAssets_Click(object sender, RoutedEventArgs e)
        {
            FileDialog dialog = new OpenFileDialog
            {
                Filter = "DAT file (*.dat)|*.dat",
                Title = "Open appearance dat file"
            };

            if ((bool)dialog.ShowDialog()) {
                _parent._asyncLoader = new Loader(_parent, null, dialog.FileName);
                _parent.ClearLog();
                _parent.Hide();
                OnClosed(e);

                _parent._asyncLoader.InitializeAssetsLoader();
                _parent._asyncLoader.Show();
            }
        }
        
        public void LoadWiki_Click(object sender, RoutedEventArgs e)
        {
            if (_filterBox == null) {
                return;
            }

            _parent._asyncLoader = new Loader(_parent, _filterBox.Items, string.Empty);
            _parent.ClearLog();
            _parent.Hide();
            OnClosed(e);

            _parent._asyncLoader.InitializeWikiLoader();
            _parent._asyncLoader.Show();
        }
                
        public void LoadXMLServerID_Click(object sender, RoutedEventArgs e)
        {
            FileDialog otbDialog = new OpenFileDialog
            {
                Filter = "OTB file (*.otb)|*.otb",
                Title = "Open OTB File"
            };

            if ((bool)otbDialog.ShowDialog()) {
                _parent._asyncLoader = new Loader(_parent, null, otbDialog.FileName);
                _parent._asyncLoader.InitializeOTBLoader();
                _parent._asyncLoader.Show();
                _parent.ClearLog();
                _parent.Hide();
                OnClosed(e);
            }
        }
        
        public void LoadXMLClientID_Click(object sender, RoutedEventArgs e)
        {
            if (_parent.LoadXMLFile()) {
                _parent._itemConverterList = new List<(int ClientID, int ServerID)>();
            }
            OnClosed(e);
            _parent.ShowLog();
        }

        private void MouseDownToDrag(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion

        #region Constructors
        public Button CreateNewButton(string text)
        {
            Button button = new Button()
            {
                Margin = new Thickness(0, 0, 10, 0),
                Content = text
            };
            Buttons.Children.Add(button);
            return button;
        }

        public TextBlock CreateTextOnLog(string text = "")
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = text,
                FontSize = 10,
            };

            MessagePanel.Children.Add(textBlock);
            return textBlock;
        }

        public ComboBox CreateNewComboBox(string text)
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = text,
                Margin = new Thickness(0, 0, 5, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            Buttons.Children.Add(textBlock);
            _filterBox = new ComboBox()
            {
                Margin = new Thickness(0, 0, 10, 0),
                Text = text,
                Width = 143
            };

            FrameworkElementFactory checkBoxFactory = new FrameworkElementFactory(typeof(CheckBox));

            checkBoxFactory.SetValue(ContentProperty, new Binding("Name"));

            checkBoxFactory.SetValue(FlowDirectionProperty, FlowDirection.RightToLeft);

            Binding isChecked = new Binding("FilterChecked");
            isChecked.Mode = BindingMode.TwoWay;
            checkBoxFactory.SetValue(System.Windows.Controls.Primitives.ToggleButton.IsCheckedProperty, isChecked);

            _filterBox.ItemTemplate = new DataTemplate
            {
                VisualTree = checkBoxFactory
            };

            Buttons.Children.Add(_filterBox);
            return _filterBox;
        }

        #endregion

        public Message(string title, MainWindow parent)
        {
            InitializeComponent();

            Title = title;
            TitleText.Text = title;

            _parent = parent;
            Focus();
        }

    }
}
