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
        Task<bool> AddMeasuredObject(MeasuredObject obj);
        Task<bool> UpdateMeasuredObject(MeasuredObject obj);
        Task<bool> Reset();
        Task<bool> DeleteObject(MeasuredObject obj);
    }
}
