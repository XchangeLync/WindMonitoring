using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GM.Business.Layer.UnitOfWork;
using GM.Business.Entity;
using AutoMapper;
using DBModel = Project.Data.Model;
using System.Globalization;

namespace GM.Business.Layer
{
    public class MonitoringLayer
    {
        private UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork();

        public IEnumerable<StateModel> GetStates()
        {
            var stateList = new List<StateModel>
            {
                new StateModel{ Code="AP", Name="Andhra Pradesh"},
                new StateModel{ Code="AS", Name="Assam"},
                new StateModel{ Code="BI", Name="Bihar"},
                new StateModel{ Code="GO", Name="Goa"},
                new StateModel{ Code="GU", Name="Gujrat"},
                new StateModel{ Code="HR", Name="Haryana"},
                new StateModel{ Code="MH", Name="Maharashtra"}
            };
            return stateList;
        }

        public IEnumerable<CityModel> GetCities()
        {
            var cityList = new List<CityModel>
            {
                new CityModel{ StateCode="AP", Code="HD", Name="Hyderabad"},
                new CityModel{ StateCode="AP", Code="KU", Name="Kunnur"},
                new CityModel{ StateCode="AS", Code="GW", Name="Guwahati"},
                new CityModel{ StateCode="AS", Code="DB", Name="Dibrugadh"},
                new CityModel{ StateCode="BI", Code="MZ", Name="Muzaffarpur"},
                new CityModel{ StateCode="BI", Code="PA", Name="Patna"},
                new CityModel{ StateCode="GO", Code="PN", Name="Panji"},
                new CityModel{ StateCode="GU", Code="SU", Name="Surat"},
                new CityModel{ StateCode="GU", Code="AH", Name="Ahmedabad"},
                new CityModel{ StateCode="HR", Code="HI", Name="Hisar"},
                new CityModel{ StateCode="HR", Code="GN", Name="Gurgaon"},
                new CityModel{ StateCode="MH", Code="MU", Name="Mumbai"},
                new CityModel{ StateCode="MH", Code="PU", Name="Pune"}
            };
            return cityList;
        }

        public IEnumerable<StationModel> GetStations()
        {
            var stationList = new List<StationModel>
            {
                new StationModel{ StationCode="01", StateCode="AP", CityCode="HD"},
                new StationModel{ StationCode="02", StateCode="AP", CityCode="KU"},
                new StationModel{ StationCode="01", StateCode="AS", CityCode="GW"},
                new StationModel{ StationCode="02", StateCode="AS", CityCode="DB"},
                new StationModel{ StationCode="01", StateCode="BI", CityCode="MZ"},
                new StationModel{ StationCode="02", StateCode="BI", CityCode="PA"},
                new StationModel{ StationCode="01", StateCode="GO", CityCode="PN"},
                new StationModel{ StationCode="01", StateCode="GU", CityCode="SU"},
                new StationModel{ StationCode="02", StateCode="GU", CityCode="AH"},
                new StationModel{ StationCode="01", StateCode="HR", CityCode="HI"},
                new StationModel{ StationCode="02", StateCode="HR", CityCode="GN"},
                new StationModel{ StationCode="01", StateCode="MH", CityCode="MU"},
                new StationModel{ StationCode="02", StateCode="MH", CityCode="PU"}
            };
            return stationList;
        }

        public int GetPredictedSpeed(string station)
        {
            var data = station.Split('-');
            string stateCode = data[0];
            string cityCode = data[1];
            string stationCode = data[2];

            int speed = default(int);
            if (stateCode == "AP" && cityCode == "HD" && stationCode == "01")
                speed = 15;
            else if (stateCode == "AP" && cityCode == "KU" && stationCode == "02")
                speed = 16;
            else if (stateCode == "AS" && cityCode == "GW" && stationCode == "01")
                speed = 17;
            else if (stateCode == "AS" && cityCode == "DB" && stationCode == "02")
                speed = 18;
            else if (stateCode == "BI" && cityCode == "MZ" && stationCode == "01")
                speed = 19;
            else if (stateCode == "BI" && cityCode == "PA" && stationCode == "02")
                speed = 20;
            else if (stateCode == "GO" && cityCode == "PN" && stationCode == "01")
                speed = 11;
            else if (stateCode == "GU" && cityCode == "SU" && stationCode == "01")
                speed = 10;
            else if (stateCode == "GU" && cityCode == "AH" && stationCode == "02")
                speed = 9;
            else if (stateCode == "HR" && cityCode == "HI" && stationCode == "01")
                speed = 8;
            else if (stateCode == "HR" && cityCode == "GN" && stationCode == "02")
                speed = 7;
            else if (stateCode == "MH" && cityCode == "MU" && stationCode == "01")
                speed = 6;
            else if (stateCode == "MH" && cityCode == "PU" && stationCode == "02")
                speed = 5;
            else
                speed = -1;

            return speed;
        }
    }
}
