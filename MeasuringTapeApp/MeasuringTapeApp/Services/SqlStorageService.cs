using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MeasuringTapeApp.Models;
using SQLite;

namespace MeasuringTapeApp.Services
{
    public class SqlStorageService : IMeasuringStorageService
    {

        private readonly string filePath;
        SQLiteAsyncConnection connection;

        public SqlStorageService()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            filePath = Path.Combine(path, "measuredObjects.db3");

            connection = new SQLiteAsyncConnection(filePath);
            connection.GetConnection().CreateTable<MeasuredObject>();
        }

        public async Task<bool> AddMeasuredObject(MeasuredObject obj)
        {
            if (obj == null)
            {
                throw new Exception("Cannot add null computer");
            }
            await connection.InsertAsync(obj);
            return true;
        }

        public async Task<ObservableCollection<MeasuredObject>> getAllMeasuredObjects()
        {
            return new ObservableCollection<MeasuredObject>(await connection.Table<MeasuredObject>().ToListAsync());
        }

        public async Task<bool> Reset()
        {
            await connection.DeleteAllAsync<MeasuredObject>();
            return true;
        }

        public Task<bool> UpdateMeasuredObject(MeasuredObject comp)
        {
            throw new NotImplementedException();
        }
    }
}
