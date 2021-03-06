﻿#pragma checksum "..\..\..\Views\TemperatureHistoryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3B1AD08FAAF8FFA15295B09A8D805348C236F872"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Logic.TemperatureController;
using NationalInstruments.Controls;
using NationalInstruments.Controls.Rendering;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using UI.TemperatureController.Converters;
using UI.TemperatureController.Views;


namespace UI.TemperatureController.Views {
    
    
    /// <summary>
    /// TemperatureHistoryView
    /// </summary>
    public partial class TemperatureHistoryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Views\TemperatureHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UI.TemperatureController.Views.TemperatureHistoryView Self;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Views\TemperatureHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isYAxisManual;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Views\TemperatureHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NationalInstruments.Controls.NumericTextBoxDouble yAxisMin;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Views\TemperatureHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NationalInstruments.Controls.NumericTextBoxDouble yAxisMax;
        
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
            System.Uri resourceLocater = new System.Uri("/UI.TemperatureController;component/views/temperaturehistoryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TemperatureHistoryView.xaml"
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
            this.Self = ((UI.TemperatureController.Views.TemperatureHistoryView)(target));
            return;
            case 2:
            this.isYAxisManual = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.yAxisMin = ((NationalInstruments.Controls.NumericTextBoxDouble)(target));
            return;
            case 4:
            this.yAxisMax = ((NationalInstruments.Controls.NumericTextBoxDouble)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

