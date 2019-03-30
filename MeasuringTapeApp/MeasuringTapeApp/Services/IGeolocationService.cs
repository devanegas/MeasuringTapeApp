using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MeasuringTapeApp.Services
{
    public interface IGeolocationService
    {
        Task<Location> GetLocationAsync();
    }
}
