using FighterDynamicProgramming.Models;
using FighterDynamicProgramming.Models.Equipment;
using FighterDynamicProgramming.Models.Ships;
using FighterDynamicProgramming.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FighterDynamicProgramming
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			this.DataContext = new MainWindowViewModel();
		}
	}
}
