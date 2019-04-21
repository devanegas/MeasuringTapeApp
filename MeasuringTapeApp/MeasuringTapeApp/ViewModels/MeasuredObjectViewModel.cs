using System;
using System.Collections.Generic;
using System.Text;
using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace MeasuringTapeApp.ViewModels
{
    public class MeasuredObjectViewModel : MvxViewModel<MeasuredObject>
    {
        MeasuredObject obj;
        private IMeasuringStorageService _measuringStorageService;
        private IMvxNavigationService _mvxNavigationService;

        public MeasuredObjectViewModel(IMeasuringStorageService measuringStorageService, IMvxNavigationService mvxNavigationService)
        {
            _measuringStorageService = measuringStorageService;
            _mvxNavigationService = mvxNavigationService;
            DeleteObject = new MvxAsyncCommand(Delete);
        }

        public IMvxAsyncCommand DeleteObject { get; }

        async Task Delete()
        {
            await _measuringStorageService.DeleteObject(obj);
        }

        public override void Prepare(MeasuredObject parameter)
        {
            obj = parameter;
        }
    }
}
