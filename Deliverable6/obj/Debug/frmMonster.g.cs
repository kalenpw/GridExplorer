﻿#pragma checksum "..\..\frmMonster.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5736AE0DEB6B7AC59E028DD316C9FE4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Deliverable6;
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


namespace Deliverable6 {
    
    
    /// <summary>
    /// frmMonster
    /// </summary>
    public partial class frmMonster : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAttack;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRunAway;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMonster;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHero;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMonsterDisplay;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPlayerDisplay;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\frmMonster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDisplayMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/Deliverable6;component/frmmonster.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\frmMonster.xaml"
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
            
            #line 9 "..\..\frmMonster.xaml"
            ((Deliverable6.frmMonster)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAttack = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\frmMonster.xaml"
            this.btnAttack.Click += new System.Windows.RoutedEventHandler(this.btnAttack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnRunAway = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\frmMonster.xaml"
            this.btnRunAway.Click += new System.Windows.RoutedEventHandler(this.btnRunAway_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblMonster = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblHero = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tbMonsterDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tbPlayerDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.lblDisplayMessage = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
