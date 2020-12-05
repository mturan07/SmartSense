using EvlaSmartSense.Web.Data;
using EvlaSmartSense.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.Models
{
    public class Kayit : Kalitim
    {
        public List<SelectListItem> SensorListesi()
        {
            List<SelectListItem> sensorler = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Please Select",
                    Value = "0"
                }
            };

            foreach (var item in Dbc.sensors.ToList())
            {
                sensorler.Add(new SelectListItem
                {
                    Text = item.DEVICEID,
                    Value = item.ID.ToString()
                });
            }

            return sensorler;
        }

        public List<SelectListItem> AlanListesi()
        {
            List<SelectListItem> alanlar = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Please Select",
                    Value = "0"
                }
            };

            foreach (var item in Dbc.fields.ToList())
            {
                alanlar.Add(new SelectListItem
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            return alanlar;
        }

        public VmReadingsSensors KayitListesi(string CihazID, int KayitSayisi = 100)
        {
            VmReadingsSensors model = new VmReadingsSensors();

            List<readings> degerler = new List<readings>();

            if (CihazID.Equals(String.Empty) | CihazID.Equals("0"))
                degerler = Dbc.readings.OrderByDescending(t => t.RECORDTIME).Take(KayitSayisi).ToList();
            else
                degerler = Dbc.readings.Where(t => t.DEVICEID.Equals(CihazID)).OrderByDescending(t => t.RECORDTIME).Take(KayitSayisi).ToList();

            model.Sensors = new Kayit().SensorListesi();
            model.Readings = degerler;

            return model;
        }

        public readings SonOkuma(string CihazID)
        {
            readings tablo = new readings();

            if (!CihazID.Equals(String.Empty))
                tablo = Dbc.readings.Where(t => t.DEVICEID.Equals(CihazID) &
                    (((DateTime)t.RECORDTIME).DayOfYear - DateTime.Now.DayOfYear) == 0)
                    .OrderByDescending(t => t.RECORDTIME).First();

            return tablo;
        }

        public SensorReadings SensorOku(string CihazID)
        {
            List<readings> tablo = new List<readings>();

            if (!CihazID.Equals(String.Empty))
            {
                tablo = Dbc.readings.Where(t => t.DEVICEID.Equals(CihazID))
                    .OrderByDescending(t => t.RECORDTIME).Take(10).ToList();
            }

            List<SensorReadings> sensorReadList = new List<SensorReadings>();

            foreach (readings item in tablo)
            {
                sensorReadList.Add(new SensorReadings()
                {
                    DeviceID = item.DEVICEID,
                    Humidity = (double)item.AIR_HUMIDITY,
                    Temperature = (double)item.AIR_TEMPERATURE,
                    ReadingDate = (DateTime)item.RECORDTIME
                });
            }

            SensorReadings sensor = new SensorReadings();

            int say = sensorReadList
                .OrderByDescending(s => s.ReadingDate)
                .Where(s => s.ReadingDate.ToShortDateString() == DateTime.Now.ToShortDateString()
                    & DateTime.Now.Subtract(s.ReadingDate).Minutes <= 5)
                .Take(1).Count();

            if (say > 0)
            {
                sensor = sensorReadList
                    .OrderByDescending(s => s.ReadingDate)
                    .Where(s => s.ReadingDate.ToShortDateString() == DateTime.Now.ToShortDateString()).First();
                sensor.State = "Online";
            }
            else
            {
                sensor.DeviceID = CihazID;
                sensor.Temperature = 0;
                sensor.Humidity = 0;
                //sensor.ReadingDate = null;
                sensor.State = "Offline";
            }

            return sensor;
        }

        #region Sensors
        public sensors SensorEkle(sensors model)
        {
            int YeniId = Dbc.sensors.Count() + 1;
            sensors Sensors = new sensors
            {
                ID = YeniId,
                DEVICEID = model.DEVICEID,
                FIELDID = model.FIELDID,
                DESCRIPTION = model.DESCRIPTION
            };

            Dbc.sensors.Add(Sensors);
            Dbc.SaveChanges();

            return Sensors;
        }

        public sensors SensorDuzenle(sensors model)
        {
            sensors sensors = SensorGoster(model.ID);
            sensors.DEVICEID = model.DEVICEID;
            sensors.FIELDID = model.FIELDID;
            sensors.DESCRIPTION = model.DESCRIPTION;

            Dbc.Entry(sensors).State = System.Data.Entity.EntityState.Modified;
            Dbc.SaveChanges();

            return sensors;
        }

        public IEnumerable<sensors> SensorListele()
        {
            return Dbc.sensors.ToList();
        }

        public sensors SensorGoster(int? id)
        {
            return Dbc.sensors.Find(id);
        }

        public bool SensorSil(int? id)
        {
            try
            {
                Dbc.sensors.Remove(Dbc.sensors.Find(id));
                Dbc.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Fields
        public fields FieldEkle(fields model)
        {
                int YeniId = Dbc.fields.Count() + 1;
                fields Fields = new fields
                {
                    ID = YeniId,
                    NAME = model.NAME,
                    ALARMTEMP = model.ALARMTEMP,
                    DESCRIPTION = model.DESCRIPTION
                };

                Dbc.fields.Add(Fields);
                Dbc.SaveChanges();

            return Fields;
        }

        public fields FieldDuzenle(fields model)
        {
            fields fields = FieldGoster(model.ID);
            fields.NAME = model.NAME;
            fields.ALARMTEMP = model.ALARMTEMP;
            fields.DESCRIPTION = model.DESCRIPTION;

            Dbc.Entry(fields).State = System.Data.Entity.EntityState.Modified;
            Dbc.SaveChanges();

            return fields;
        }

        public IEnumerable<fields> FieldListele()
        {
            return Dbc.fields.ToList();
        }

        public fields FieldGoster(int? id)
        {
            return Dbc.fields.Find(id);
        }

        public bool FieldSil(int? id)
        {
            try
            {
                Dbc.fields.Remove(Dbc.fields.Find(id));
                Dbc.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Settings
        public List<SelectListItem> DilListesi()
        {
            List<SelectListItem> langsList = new List<SelectListItem>();
            //{
            //    new SelectListItem
            //    {
            //        Text = "Please Select",
            //        Value = "0"
            //    }
            //};

            foreach (var item in Dbc.langs.ToList())
            {
                langsList.Add(new SelectListItem
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }

            return langsList;
        }

        public settings SettingsDuzenle(settings model)
        {
            settings settings = SettingsGoster(model.ID);
            settings.FIRSTNAME = model.FIRSTNAME;
            settings.LASTNAME = model.LASTNAME;
            settings.PHONE = model.PHONE;
            settings.GSM = model.GSM;
            settings.FAX = model.FAX;
            settings.EMAIL = model.EMAIL;
            settings.ADDRESS = model.ADDRESS;
            settings.LANGSID = model.LANGSID;

            Dbc.Entry(settings).State = System.Data.Entity.EntityState.Modified;
            Dbc.SaveChanges();

            return settings;
        }

        public settings SettingsGoster(int? id)
        {
            return Dbc.settings.Find(id);
        }
        #endregion
    }
}