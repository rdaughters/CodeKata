using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CodeKata.Models;
using CodeKata.Services;
using CodeKata.Views;
using Xamarin.Forms.Internals;

namespace CodeKata.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ITravelLogStore _travelLogStore;
        private IPageService _pageService;
        private TravelLog _selectedLog = null;
        private bool _isDataLoaded = false;

        /// <summary>
        /// A list of <see cref="TravelLog"/> objects.
        /// </summary>
        public ObservableCollection<TravelLog> TravelLogs { get; private set; } = new ObservableCollection<TravelLog>();

        /// <summary>
        /// Currently selected TravelLog.
        /// </summary>
        public TravelLog SelectedLog
        {
            get { return _selectedLog; }
            set
            {
                if (value == null)
                    return;

                OnSelectedLog(value);
                OnPropertyChanged(nameof(SelectedLog));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="traveLogStore">ITravelLogStore for providing travel logs.</param>
        /// <param name="pageService">IPageService for providing page navigation.</param>
        public MainPageViewModel(ITravelLogStore traveLogStore, IPageService pageService)
        {
            _travelLogStore = traveLogStore;
            _pageService = pageService;

            LoadTravelLogs(_travelLogStore);
        }

        /// <summary>
        /// Load list of travel logs.
        /// </summary>
        /// <param name="traveLogStore">ITravelLogStore used to retrieve travel logs.</param>
        public async void LoadTravelLogs(ITravelLogStore traveLogStore)
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var logs = await traveLogStore.GetTravelLogs();
            foreach (TravelLog log in logs)
                TravelLogs.Add(log);
        }

        /// <summary>
        /// Handle a TravelLog being selected. Navigates to <see cref="TravelDetails"/> page.
        /// </summary>
        /// <param name="selectedLog">The selected travel log.</param>
        private async void OnSelectedLog(TravelLog selectedLog)
        {
            await _pageService.PushAsync(new TravelDetails(new TravelDetailsViewModel(selectedLog, new TravelLogProcessor())));
        }
    }
}
