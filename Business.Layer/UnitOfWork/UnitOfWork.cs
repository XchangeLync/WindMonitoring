using System;
using GM.Business.Entity;
using Project.Data.Model;
using GM.Business.Layer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace GM.Business.Layer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        private GaleEntities context = new GaleEntities();
        private GenericRepository<StateModel> stateRepository;
        private GenericRepository<CityModel> cityRepository;
        private GenericRepository<StationModel> stationRepository;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    context.Dispose();
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save() { context.SaveChanges(); }

        #region App Repositories

        public GenericRepository<StateModel> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                    this.stateRepository = new GenericRepository<StateModel>(context);

                return stateRepository;
            }
        }

        public GenericRepository<CityModel> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                    this.cityRepository = new GenericRepository<CityModel>(context);

                return cityRepository;
            }
        }

        public GenericRepository<StationModel> StationRepository
        {
            get
            {
                if (this.stationRepository == null)
                    this.stationRepository = new GenericRepository<StationModel>(context);

                return stationRepository;
            }
        }

        #endregion
    }
}
