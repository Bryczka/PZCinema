﻿#pragma checksum "..\..\AddFilmShow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EF2AFB3CAB511096B30F82442F5C1159185B030C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using AdminCinemaApp;
using DevExpress.Xpf.DXBinding;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using Xceed.Wpf.Toolkit;


namespace AdminCinemaApp {
    
    
    /// <summary>
    /// AddFilmShow
    /// </summary>
    public partial class AddFilmShow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\AddFilmShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AdminCinemaApp.AddFilmShow AddFilmShowWindow;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddFilmShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker TimeOfFilmShow;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddFilmShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddFilmShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilmShowTitle;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddFilmShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberOfSeats;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AddFilmShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/AdminCinemaApp;component/addfilmshow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddFilmShow.xaml"
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
            this.AddFilmShowWindow = ((AdminCinemaApp.AddFilmShow)(target));
            return;
            case 2:
            this.TimeOfFilmShow = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 3:
            this.RoomName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\AddFilmShow.xaml"
            this.RoomName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RoomName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FilmShowTitle = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.NumberOfSeats = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Save_Button = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\AddFilmShow.xaml"
            this.Save_Button.Click += new System.Windows.RoutedEventHandler(this.Save_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
