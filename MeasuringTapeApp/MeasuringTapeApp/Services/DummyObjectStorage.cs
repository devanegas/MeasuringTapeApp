//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Text;
//using System.Threading.Tasks;
//using MeasuringTapeApp.Models;

//namespace MeasuringTapeApp.Services
//{
//    public class DummyObjectStorage : IMeasuringStorageService
//    {
//        public Task<bool> AddMeasuredObject(MeasuredObject comp)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<ObservableCollection<MeasuredObject>> GetAllMeasuredObjects()
//        {
//            var list = new ObservableCollection<MeasuredObject>();
//            var obj = new MeasuredObject();

//            obj.Id = 0;
//            obj.Name = "Meter Stick";
//            obj.Measurement = 1;
//            obj.Type = "Straight Line";
//            obj.Units = "SI Units";
//            list.Add(obj);

//            obj.Id = 1;
//            obj.Name = "Yard Stick";
//            obj.Measurement = 1;
//            obj.Type = "Straight Line";
//            obj.Units = "Imperial";
//            list.Add(obj);

//            return list;
//        }

//        public Task<bool> Reset()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> UpdateMeasuredObject(MeasuredObject comp)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
