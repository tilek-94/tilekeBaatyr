﻿#pragma checksum "..\..\Kurs.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "580A26A0B102C5D01C46BE5A881EBA523EEF6FD1F9CED9F1171CB95AF2EB8FD5"
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
using УчетнаяСистема;


namespace УчетнаяСистема {
    
    
    /// <summary>
    /// Kurs
    /// </summary>
    public partial class Kurs : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox USD;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EUR;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RUB;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVal;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Connect;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nusd;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock neur;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nrub;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\Kurs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNbkr;
        
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
            System.Uri resourceLocater = new System.Uri("/УчетнаяСистема;component/kurs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Kurs.xaml"
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
            
            #line 9 "..\..\Kurs.xaml"
            ((УчетнаяСистема.Kurs)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.USD = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.EUR = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.RUB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnVal = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\Kurs.xaml"
            this.btnVal.Click += new System.Windows.RoutedEventHandler(this.btnVal_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Connect = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.nusd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.neur = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.nrub = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.btnNbkr = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\Kurs.xaml"
            this.btnNbkr.Click += new System.Windows.RoutedEventHandler(this.btnNbkr_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 98 "..\..\Kurs.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

