using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinqFunctions.WPFClass.Dependency
{
    public class PersonDependency: DependencyObject
    {
        public static readonly DependencyProperty nameProperty;

        static PersonDependency()
        {
            nameProperty = DependencyProperty.Register("Name", typeof(string), typeof(PersonDependency), new PropertyMetadata("Learning Hard", OnValueChanged));
        }

        public string Name
        {
            get { return (string)GetValue(nameProperty); }
            set { SetValue(nameProperty, value); }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
