using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MeasuringTapeApp.Data;
using MeasuringTapeApp.Models;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace MeasuringTapeApp.Services
{
    public class SqlStorageService : IMeasuringStorageService
    {

        private readonly string filePath;
        MeasureDbContext connection;
        DbContextOptions<MeasureDbContext> options;

        public SqlStorageService()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            filePath = Path.Combine(path, "measuredObjects.db3");
            var optionsBuilder = new DbContextOptionsBuilder<MeasureDbContext>();
            optionsBuilder.UseSqlite($"Data Source={filePath}");

            options = optionsBuilder.Options;
//            connection = new MeasureDbContext(options);
          
        }

        public async Task<bool> AddMeasuredObject(MeasuredObject obj)
        {
            if (obj == null)
            {
                throw new Exception("Cannot add null measured Object");
            }
            try
            {
                connection = new MeasureDbContext(options);
                await connection.MeasuredObjects.AddAsync(obj);
                await connection.SaveChangesAsync();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
     
            return true;
        }

        public async Task<ObservableCollection<MeasuredObject>> GetAllMeasuredObjects()
        {
            return new ObservableCollection<MeasuredObject>(await connection.MeasuredObjects.ToListAsync());
        }

        public bool UpdateMeasuredObject(MeasuredObject obj)
        {
            connection.MeasuredObjects.Update(obj);
            return true;
        }

        //public async Task<MeasuredObject> getLastMeasuredObject()
        //{
        //    //TODO
        //}

        public async Task<bool> Reset()
        {
            connection.MeasuredObjects.RemoveRange(await connection.MeasuredObjects.ToArrayAsync());
            return true;
        }

    }
}
