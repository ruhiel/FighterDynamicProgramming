using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FighterDynamicProgramming.Controls
{
	/// <summary>
	/// BindableNumericUpDown.xaml の相互作用ロジック
	/// </summary>
	public partial class BindableNumericUpDown : WindowsFormsHost, INotifyPropertyChanged
	{
		#region 依存関係プロパティ
		public static readonly DependencyProperty ValueProperty;
		static BindableNumericUpDown()
		{
			ValueProperty = DependencyProperty.Register(
				"Value",
				typeof(decimal),
				typeof(BindableNumericUpDown),
				new FrameworkPropertyMetadata(0m,
											  FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
											  new PropertyChangedCallback(OnValueChanged)));
		}
		public Decimal Value
		{
			// このプロパティはコンパイル時に参照されるが、実行時には参照されない。
			// そのためこの.NETプロパティラッパにロジックを入れてはいけない。
			get { return (Decimal)GetValue(ValueProperty); }
			set
			{
				SetValue(ValueProperty, value);
				NotifyPropertyChanged("Value");
			}
		}
		#endregion

		private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			BindableNumericUpDown control = sender as BindableNumericUpDown;
			if (control == null)
			{
				return;
			}
			if (e.Property == ValueProperty)
			{
				control.Value = (decimal)e.NewValue;
			}
		}

		public BindableNumericUpDown()
		{
			InitializeComponent();
			SetUpBind();
		}

		#region 表示と依存関係プロパティの同期
		/// <summary>
		/// bypassData と NumericUpDown.Value のバインド
		/// </summary>
		private void SetUpBind()
		{
			var binding2 = new BindingSource();
			((ISupportInitialize)binding2).BeginInit();
			NumericUpDown child = Child as NumericUpDown;
			child.DataBindings.Add(new Binding("Value", binding2, "Value", true, DataSourceUpdateMode.OnPropertyChanged));
			binding2.DataSource = typeof(BindableNumericUpDown);
			((ISupportInitialize)binding2).EndInit();
			binding2.DataSource = this;
		}
		private void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };
		#endregion
	}
}
