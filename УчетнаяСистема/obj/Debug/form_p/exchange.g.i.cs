﻿#pragma checksum "..\..\..\form_p\exchange.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "78A3EE2A0675A9A80733799F99FAFAB130F839400EC98FB26937457BFA9F069E"
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
    /// exchange
    /// </summary>
    public partial class exchange : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 23 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Close;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_client_btn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text2;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button view_product_btn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox1;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\form_p\exchange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button registr_btn;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\form_p\exchange.xaml"
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
            System.Uri resourceLocater = new System.Uri("/УчетнаяСистема;component/form_p/exchange.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\form_p\exchange.xaml"
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
            
            #line 9 "..\..\..\form_p\exchange.xaml"
            ((УчетнаяСистема.form_p.exchange)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_Close = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\form_p\exchange.xaml"
            this.Button_Close.Click += new System.Windows.RoutedEventHandler(this.Button_Clic);
            
            #line default
            #line hidden
            return;
            case 3:
            this.text1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.view_client_btn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\form_p\exchange.xaml"
            this.view_client_btn.Click += new System.Windows.RoutedEventHandler(this.view_client_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.text2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.view_product_btn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\form_p\exchange.xaml"
            this.view_product_btn.Click += new System.Windows.RoutedEventHandler(this.view_product_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ComboBox1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.registr_btn = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\form_p\exchange.xaml"
            this.registr_btn.Click += new System.Windows.RoutedEventHandler(this.registr_btn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dataGridView1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 110 "..\..\..\form_p\exchange.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.x1_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

