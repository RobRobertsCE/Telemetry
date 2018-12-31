using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
namespace Infragistics.Models
{
    public abstract class ObservableModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
    public class EnergyProductionData : ObservableCollection<EnergyProduction>
    {
    }
    public class EnergyProduction
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Year { get; set; }
        // Non-Renewable Energy Sources
        private double _nuclear;
        public double Nuclear { get { return _nuclear; } set { _nuclear = value; UpdateValues(); } }
        private double _coal;
        public double Coal { get { return _coal; } set { _coal = value; UpdateValues(); } }
        private double _oil;
        public double Oil { get { return _oil; } set { _oil = value; UpdateValues(); } }
        private double _gas;
        public double Gas { get { return _gas; } set { _gas = value; UpdateValues(); } }
        // Renewable Energy Sources
        private double _hydro;
        public double Hydro { get { return _hydro; } set { _hydro = value; UpdateValues(); } }
        private double _geoThermal;
        public double GeoThermal { get { return _geoThermal; } set { _geoThermal = value; UpdateValues(); } }
        private double _solar;
        public double Solar { get { return _solar; } set { _solar = value; UpdateValues(); } }
        private double _wind;
        public double Wind { get { return _wind; } set { _wind = value; UpdateValues(); } }
        public double Total { get; set; }
        public double Renewable { get; set; }
        public double NonRenewable { get; set; }
        public void UpdateValues()
        {
            this.Renewable = Hydro + GeoThermal + Wind + Solar;
            this.NonRenewable = Coal + Oil + Gas + Nuclear;
            this.Total = this.Renewable + this.NonRenewable;
        }
    }

    public class EnergyProductionDataSample : EnergyProductionData
    {
        public EnergyProductionDataSample()
        {
            this.Add(new EnergyProduction { Region = "America", Country = "Canada", Coal = 400, Oil = 100, Gas = 175, Nuclear = 225, Hydro = 350 });
            this.Add(new EnergyProduction { Region = "Asia", Country = "China", Coal = 925, Oil = 200, Gas = 350, Nuclear = 400, Hydro = 625 });
            this.Add(new EnergyProduction { Region = "Europe", Country = "Russia", Coal = 550, Oil = 200, Gas = 250, Nuclear = 475, Hydro = 425 });
            this.Add(new EnergyProduction { Region = "Asia", Country = "Australia", Coal = 450, Oil = 100, Gas = 150, Nuclear = 175, Hydro = 350 });
            this.Add(new EnergyProduction { Region = "America", Country = "United States", Coal = 800, Oil = 250, Gas = 475, Nuclear = 575, Hydro = 750 });
            this.Add(new EnergyProduction { Region = "Europe", Country = "France", Coal = 375, Oil = 150, Gas = 350, Nuclear = 275, Hydro = 325 });
        }
    }
    public class EnergyProductionDataHistory : EnergyProductionData
    {
        public EnergyProductionDataHistory()
        {
            this.Add(new EnergyProduction { Year = "2000", Country = "Canada", Coal = 400, Oil = 100, Gas = 175, Nuclear = 225, Hydro = 350 });
            this.Add(new EnergyProduction { Year = "2010", Country = "Canada", Coal = 450, Oil = 150, Gas = 225, Nuclear = 255, Hydro = 400 });
            this.Add(new EnergyProduction { Year = "2020", Country = "Canada", Coal = 300, Oil = 200, Gas = 275, Nuclear = 325, Hydro = 450 });
            this.Add(new EnergyProduction { Year = "2000", Country = "China", Coal = 825, Oil = 200, Gas = 350, Nuclear = 400, Hydro = 625 });
            this.Add(new EnergyProduction { Year = "2010", Country = "China", Coal = 925, Oil = 250, Gas = 400, Nuclear = 420, Hydro = 685 });
            this.Add(new EnergyProduction { Year = "2020", Country = "China", Coal = 975, Oil = 300, Gas = 450, Nuclear = 450, Hydro = 725 });
            this.Add(new EnergyProduction { Year = "2000", Country = "Russia", Coal = 550, Oil = 200, Gas = 250, Nuclear = 475, Hydro = 425 });
            this.Add(new EnergyProduction { Year = "2010", Country = "Russia", Coal = 600, Oil = 220, Gas = 280, Nuclear = 525, Hydro = 485 });
            this.Add(new EnergyProduction { Year = "2020", Country = "Russia", Coal = 650, Oil = 250, Gas = 350, Nuclear = 575, Hydro = 525 });
            this.Add(new EnergyProduction { Year = "2000", Country = "Australia", Coal = 450, Oil = 100, Gas = 150, Nuclear = 175, Hydro = 350 });
            this.Add(new EnergyProduction { Year = "2010", Country = "Australia", Coal = 480, Oil = 120, Gas = 250, Nuclear = 225, Hydro = 400 });
            this.Add(new EnergyProduction { Year = "2020", Country = "Australia", Coal = 550, Oil = 180, Gas = 350, Nuclear = 275, Hydro = 450 });
            this.Add(new EnergyProduction { Year = "2000", Country = "United States", Coal = 800, Oil = 250, Gas = 475, Nuclear = 575, Hydro = 750 });
            this.Add(new EnergyProduction { Year = "2010", Country = "United States", Coal = 850, Oil = 300, Gas = 525, Nuclear = 625, Hydro = 800 });
            this.Add(new EnergyProduction { Year = "2020", Country = "United States", Coal = 900, Oil = 350, Gas = 575, Nuclear = 675, Hydro = 850 });
            this.Add(new EnergyProduction { Year = "2000", Country = "France", Coal = 375, Oil = 150, Gas = 350, Nuclear = 275, Hydro = 325 });
            this.Add(new EnergyProduction { Year = "2010", Country = "France", Coal = 425, Oil = 200, Gas = 400, Nuclear = 325, Hydro = 385 });
            this.Add(new EnergyProduction { Year = "2020", Country = "France", Coal = 455, Oil = 250, Gas = 450, Nuclear = 375, Hydro = 425 });
        }
    }
}