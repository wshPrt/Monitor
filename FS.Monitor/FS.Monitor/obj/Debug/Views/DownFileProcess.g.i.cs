﻿#pragma checksum "..\..\..\Views\DownFileProcess.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9FAE573E7CC6A7AB7279F1BB07C5E257F12FB685037389D092863352FF5BD18B"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using FS.Monitor.Common.WindowClose;
using FS.Monitor.Views;
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
using System.Windows.Interactivity;
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


namespace FS.Monitor.Views {
    
    
    /// <summary>
    /// DownFileProcess
    /// </summary>
    public partial class DownFileProcess : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FS.Monitor.Views.DownFileProcess w;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_ver;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtDes;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancle;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ProgressBar;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\..\Views\DownFileProcess.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtProcess;
        
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
            System.Uri resourceLocater = new System.Uri("/FS.Monitor;component/views/downfileprocess.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\DownFileProcess.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.w = ((FS.Monitor.Views.DownFileProcess)(target));
            
            #line 16 "..\..\..\Views\DownFileProcess.xaml"
            this.w.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.W_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_ver = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtDes = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnCancle = ((System.Windows.Controls.Button)(target));
            
            #line 212 "..\..\..\Views\DownFileProcess.xaml"
            this.btnCancle.Click += new System.Windows.RoutedEventHandler(this.btnCancle_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ProgressBar = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.txtProcess = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

