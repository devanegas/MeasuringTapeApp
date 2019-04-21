using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MeasuringTapeApp.ViewModels
{
    public class EntryViewModel : MvxViewModel
    {
        //private ByteArrayToImageValueConverter converter;
        private IMvxNavigationService _navigationService;
        private IMeasuringStorageService _measuringStorageService;
        private IGeolocationService _geolocationService;

        public EntryViewModel(IMeasuringStorageService measuringStorageService,
                                IMvxNavigationService navigationService, IGeolocationService geolocationService)
        {
            _navigationService = navigationService;
            _measuringStorageService = measuringStorageService;
            _geolocationService = geolocationService;
           // converter = new ByteArrayToImageValueConverter();
        }

        public string[] StatusList => Models.Type.StatusList;
        public string[] Unit => Models.Type.Units;

        private string _myDrawable;
        public string MyDrawable
        {
            get { return _myDrawable; }
            set
            {
                _myDrawable = value;
                RaisePropertyChanged(() => MyDrawable);
            }
        }

        //private byte[] _rawImage;
        //public byte[] RawImage
        //{
        //    get { return _rawImage; }
        //    set
        //    {
        //        _rawImage = value;
        //        if (_rawImage == null)
        //            return;

        //        var bitmap = BitmapFactory.DecodeByteArray(_rawImage, 0, _rawImage.Length);
        //    }
        //}


        private MeasuredObject obj;
        private MvxCommand next;

        public MeasuredObject Obj => obj ?? (obj = new MeasuredObject());

        public MvxCommand NextButton => next ?? (next = new MvxCommand(() =>
        {
            
            _measuringStorageService.AddMeasuredObject(obj);
        //_navigationService.Navigate<MeasuringViewModel>();
            if (obj.Type.Equals("Linear"))
            {
                _navigationService.Navigate(typeof(MeasuringViewModel), obj);
            }
            else if (obj.Type.Equals("Multi-Linear"))
            {
                _navigationService.Navigate(typeof(MeasuringMultiLevelViewModel), obj);
            }
            else if (obj.Type.Equals("Walking"))
            {
                _navigationService.Navigate(typeof(MeasuringContinuousViewModel), obj);
            }
            else
                _navigationService.Navigate<MeasuringViewModel>();
        }));

    }
}


//public class ByteArrayToImageValueConverter : MvxValueConverter<byte[], Bitmap>
//{
    
//    protected override Bitmap Convert(byte[] value, System.Type targetType, object parameter, CultureInfo culture)
//    {
//        if (value == null || value.Length == 0) { return null; }
//        return BitmapFactory.DecodeByteArray(value, 0, value.Length);
//    }

//}