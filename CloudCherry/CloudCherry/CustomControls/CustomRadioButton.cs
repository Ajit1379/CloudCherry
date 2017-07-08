using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

namespace CloudCherry.CustomControls
{
    using System.Linq;

    using Microsoft.Practices.ObjectBuilder2;

    public class CustomRadioButton : View
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create<CustomRadioButton, bool>(p => p.Checked, false);

        public static readonly BindableProperty TextProperty = BindableProperty.Create<CustomRadioButton, string>(p => p.Text, string.Empty);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<CustomRadioButton, ICommand>(p => p.Command,null);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create<CustomRadioButton, Color>(p => p.TextColor, Color.Black);

        public static List<CustomRadioButton> GroupRadioButtonList = new List<CustomRadioButton>();

        public CustomRadioButton()
        {
            GroupRadioButtonList.Add(this);
        }

        public bool Checked
        {
            get => (bool)this.GetValue(CheckedProperty);
            set
            {
                this.SetValue(CheckedProperty, value);
                var eventHandler = this.Command;              
                if (value)
                {
                    eventHandler?.Execute(value);
                    GroupRadioButtonList.Where(x => x != this).ToList().ForEach(y => y.Checked = false);
                }
            }
        }

        public string Text
        {
            get => (string)this.GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }

        public Color TextColor
        {
            get => (Color)this.GetValue(TextColorProperty);
            set => this.SetValue(TextColorProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }
    }
}



