﻿#pragma checksum "..\..\..\Threading\ThreadWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "32FE640A5217FE3D78D1B8F5A50E79A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using LinqFunctions;
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


namespace LinqFunctions {
    
    
    /// <summary>
    /// ThreadWindow
    /// </summary>
    public partial class ThreadWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_output;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProcess;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThreadpool;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLock;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelegateInvoke;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCallBack;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStartThread;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEndThread;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbProducts;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUsers;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Threading\ThreadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbManualWait;
        
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
            System.Uri resourceLocater = new System.Uri("/LinqFunctions;component/threading/threadwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Threading\ThreadWindow.xaml"
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
            this.tb_output = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnProcess = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnProcess.Click += new System.Windows.RoutedEventHandler(this.btnProcess_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnThreadpool = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnThreadpool.Click += new System.Windows.RoutedEventHandler(this.btnThreadpool_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLock = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnLock.Click += new System.Windows.RoutedEventHandler(this.btnLock_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDelegateInvoke = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnDelegateInvoke.Click += new System.Windows.RoutedEventHandler(this.btnDelegateInvoke_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCallBack = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnCallBack.Click += new System.Windows.RoutedEventHandler(this.btnCallBack_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnStartThread = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnStartThread.Click += new System.Windows.RoutedEventHandler(this.btnStartThread_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnEndThread = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Threading\ThreadWindow.xaml"
            this.btnEndThread.Click += new System.Windows.RoutedEventHandler(this.btnEndThread_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbProducts = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbUsers = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tbManualWait = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

