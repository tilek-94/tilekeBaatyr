﻿#pragma checksum "..\..\..\form_p\AnalisCars.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D969BE359E2B4C10E0120FB051922C00295319ED5CD45F5197750A545427EBD2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using УчетнаяСистема.form_p;


namespace УчетнаяСистема.form_p {
    
    
    /// <summary>
    /// AnalisCars
    /// </summary>
    public partial class AnalisCars : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\form_p\AnalisCars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox x11;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\form_p\AnalisCars.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridView1;
        
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
            System.Uri resourceLocater = new System.Uri("/УчетнаяСистема;component/form_p/analiscars.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\form_p\AnalisCars.xaml"
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
            
            #line 9 "..\..\..\form_p\AnalisCars.xaml"
            ((УчетнаяСистема.form_p.AnalisCars)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.x11 = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\form_p\AnalisCars.xaml"
            this.x11.KeyDown += new System.Windows.Input.KeyEventHandler(this.x11_KeyDown);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\form_p\AnalisCars.xaml"
            this.x11.KeyUp += new System.Windows.Input.KeyEventHandler(this.x11_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dataGridView1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 38 "..\..\..\form_p\AnalisCars.xaml"
            this.dataGridView1.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGridView1_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

