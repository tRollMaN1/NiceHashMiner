﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NHM.Wpf.Views.PluginsNew.PluginItem
{
    /// <summary>
    /// Interaction logic for PluginItem.xaml
    /// </summary>
    public partial class PluginItem : UserControl
    {
        public PluginItem()
        {
            InitializeComponent();
            Collapse();
        }

        private void Collapse()
        {
            DetailsGrid.Visibility = Visibility.Collapsed;
            DetailsToggleButton.IsChecked = false;
            DetailsToggleButtonText.Text = "Details";
        }

        private void Expand()
        {
            DetailsGrid.Visibility = Visibility.Visible;
            DetailsToggleButton.IsChecked = true;
            DetailsToggleButtonText.Text = "Less Details";
        }

        private void ToggleDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetailsToggleButton.IsChecked.Value)
            {
                Expand();
            }
            else
            {
                Collapse();
            }
        }

        private readonly HashSet<ToggleButton> _toggleButtonsGuard = new HashSet<ToggleButton>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton tButton && !_toggleButtonsGuard.Contains(tButton))
            {
                _toggleButtonsGuard.Add(tButton);
                PluginActionsButtonContext.IsOpen = true;
                RoutedEventHandler closedHandler = null;
                closedHandler += (s, e2) => {
                    _toggleButtonsGuard.Remove(tButton);
                    tButton.IsChecked = false;
                    PluginActionsButtonContext.Closed -= closedHandler;
                };
                PluginActionsButtonContext.Closed += closedHandler;
            }
            
        }
    }
}
