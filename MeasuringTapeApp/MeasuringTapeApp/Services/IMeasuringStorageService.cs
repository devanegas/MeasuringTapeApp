using MeasuringTapeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringTapeApp.Services
{
    public interface IMeasuringStorageService
    {
        Task<ObservableCollection<MeasuredObject>> getAllMeasuredObjects();
        Task<bool> AddMeasuredObject(MeasuredObject comp);
        Task<bool> UpdateMeasuredObject(MeasuredObject comp);
        Task<bool> Reset();
    }
}
