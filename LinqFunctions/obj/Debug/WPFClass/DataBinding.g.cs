﻿#pragma checksum "..\..\..\WPFClass\DataBinding.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6CEC33D955BC0C620C9A8E5386C1CB38"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using LinqFunctions.WPFClass;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LinqFunctions.WPFClass {
    
    
    /// <summary>
    /// DataBinding
    /// </summary>
    public partial class DataBinding : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SliderFont;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbTag;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbZiel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressbar;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbOutput;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemove;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\WPFClass\DataBinding.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSize;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LinqFunctions;component/wpfclass/databinding.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WPFClass\DataBinding.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.StackPanel = ((System.Windows.Controls.StackPanel)(target));
            
            #line 15 "..\..\..\WPFClass\DataBinding.xaml"
            this.StackPanel.Loaded += new System.Windows.RoutedEventHandler(this.StackPanel_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SliderFont = ((System.Windows.Controls.Slider)(target));
            return;
            case 3:
            this.lbTag = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.tbZiel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.progressbar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 6:
            this.tbOutput = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 34 "..\..\..\WPFClass\DataBinding.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\WPFClass\DataBinding.xaml"
            this.btnRemove.Click += new System.Windows.RoutedEventHandler(this.btnRemove_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtSize = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

