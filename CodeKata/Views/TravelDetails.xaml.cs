using System;
using System.Collections.Generic;
using CodeKata.ViewModels;
using Xamarin.Forms;

namespace CodeKata.Views
{
    public partial class TravelDetails : ContentPage
    {
        private TravelDetailsViewModel _viewModel;

        public TravelDetails(TravelDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = _viewModel;

            InitializeComponent();
        }
    }
}
