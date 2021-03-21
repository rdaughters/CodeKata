using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeKata.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
    }
}
