﻿using CarAppControlPanelMAUI.MVVM.ViewModels;
using CarAppControlPanelMAUI.Pages;


namespace CarAppControlPanelMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel viewmModel)
        {
            InitializeComponent();  
            BindingContext = viewmModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            MainCarImage.TranslationY = 600;
            btn1.TranslationY = 500;
            btn2.TranslationY = 500;
            MainCarImage.Opacity = 0;
            btn1.Opacity = 0;
            btn2.Opacity = 0;


            var moveUpAnimation = MainCarImage.TranslateTo(0, 0, 1000);
            _ = btn1.TranslateTo(0, 0, 1000);
            _ = btn2.TranslateTo(0, 0, 1000);
            var fadeInAnimation = MainCarImage.FadeTo(1, 1000);
            _ = btn1.FadeTo(1, 1000);
            _ = btn2.FadeTo(1, 1000);

        }
        
    }
}