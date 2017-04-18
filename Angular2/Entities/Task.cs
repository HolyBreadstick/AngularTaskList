using Angular2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2.Entities
{
    public class Task
    {
        public int ID { get; set; }
        public virtual object EmployeePk { get; set; }
        public String Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.New;
        public double CalculateDistance(double inLat, double inLong, Unit unit = Unit.Miles) {

            double rlat1 = Math.PI * Latitude / 180;
            double rlat2 = Math.PI * inLat / 180;
            double theta = Longitude - inLong;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case Unit.Kilometers: //Kilometers -> default
                    return dist * 1.609344;
                case Unit.Nautical: //Nautical Miles 
                    return dist * 0.8684;
                case Unit.Miles: //Miles
                    return dist;
                default:
                    return dist;
            }
            
        }
    }


    
}
