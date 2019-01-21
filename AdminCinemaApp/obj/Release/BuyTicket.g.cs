﻿#pragma checksum "..\..\BuyTicket.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7B70BF6E7C8F6454F07C12A4F32E847C31313415"
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


namespace AdminCinemaApp {
    
    
    /// <summary>
    /// BuyTicket
    /// </summary>
    public partial class BuyTicket : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AdminCinemaApp.BuyTicket BuyTicketWindow;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Title;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameOfRoom;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeOfFilmShow;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SeatNumber;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\BuyTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeOfTicket;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\BuyTicket.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AdminCinemaApp;component/buyticket.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BuyTicket.xaml"
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
            this.BuyTicketWindow = ((AdminCinemaApp.BuyTicket)(target));
            return;
            case 2:
            this.Title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.NameOfRoom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TimeOfFilmShow = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SeatNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TypeOfTicket = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Save_Button = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\BuyTicket.xaml"
            this.Save_Button.Click += new System.Windows.RoutedEventHandler(this.Save_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
