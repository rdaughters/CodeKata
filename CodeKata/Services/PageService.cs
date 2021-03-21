using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeKata.Services
{
    public class PageService : IPageService
    {
        /// <summary>
        /// Pushes a page onto the <see cref="MainPage"/> navigation stack.
        /// </summary>
        /// <param name="page">Page to push onto the stack.</param>
        /// <returns>A task that represents the async push operation.</returns>
        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
