﻿#pragma checksum "..\..\..\User Control\ucChangePrice.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1740245D397211B97CDF1DB43891AB7E9C41EC98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Minh_C3_B1;
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


namespace Minh_C3_B1 {
    
    
    /// <summary>
    /// ucChangePrice
    /// </summary>
    public partial class ucChangePrice : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackepanel;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnElec;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPorcelain;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFood;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgProduct;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\User Control\ucChangePrice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Minh_C3_B1;component/user%20control/ucchangeprice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\User Control\ucChangePrice.xaml"
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
            this.stackepanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.btnElec = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\User Control\ucChangePrice.xaml"
            this.btnElec.Click += new System.Windows.RoutedEventHandler(this.btnElec_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPorcelain = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\User Control\ucChangePrice.xaml"
            this.btnPorcelain.Click += new System.Windows.RoutedEventHandler(this.btnPorcelain_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnFood = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\User Control\ucChangePrice.xaml"
            this.btnFood.Click += new System.Windows.RoutedEventHandler(this.btnFood_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dtgProduct = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 128 "..\..\..\User Control\ucChangePrice.xaml"
            this.txtPrice.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtPrice_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 137 "..\..\..\User Control\ucChangePrice.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\User Control\ucChangePrice.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

