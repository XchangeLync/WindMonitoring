using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GM.Business.Entity;
using GM.Business.Layer;

namespace RoshanProject.Controllers
{
    [RoutePrefix("api")]
    public class AppAPIController : ApiController
    {
        MonitoringLayer monitoringLayer = new MonitoringLayer();

        [Route("State")]
        public IEnumerable<StateModel> GetState()
        {
            return monitoringLayer.GetStates();
        }
        [Route("City")]
        public IEnumerable<CityModel> GetCity()
        {
            return monitoringLayer.GetCities();
        }
        [Route("Station")]
        public IEnumerable<StationModel> GetStation()
        {
            return monitoringLayer.GetStations();
        }
        [Route("PredictedSpeed")]
        public int GetPredictedSpeed(string station)
        {
            return monitoringLayer.GetPredictedSpeed(station);
        }
    }
}
