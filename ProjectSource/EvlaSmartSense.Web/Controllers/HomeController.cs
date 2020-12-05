using EvlaSmartSense.Web.Data;
using EvlaSmartSense.Web.Models;
using EvlaSmartSense.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.Controllers
{
    [LoginControl]

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SensorReadings> sensorList = new List<SensorReadings>();
            SensorReadings sensor1 = new Kayit().SensorOku("ESS_CS001_BX01");
            sensorList.Add(sensor1);
            SensorReadings sensor2 = new Kayit().SensorOku("ESS_CS001_BX02");
            sensorList.Add(sensor2);
            SensorReadings sensor3 = new Kayit().SensorOku("ESS_CS001_BX03");
            sensorList.Add(sensor3);
            SensorReadings sensor4 = new Kayit().SensorOku("ESS_CS001_BX04");
            sensorList.Add(sensor4);
            SensorReadings sensor5 = new Kayit().SensorOku("ESS_CS001_BX05");
            sensorList.Add(sensor5);

            ViewBag.FieldsList = new Kayit().FieldListele();
            ViewBag.SensorsList = new Kayit().SensorListele();

            //ViewBag.SonOkuma = new Kayit().SonOkuma("");
            //return View(new Kayit().KayitListesi(""));
            return View(sensorList);
        }

        //[HttpPost]
        //public ActionResult Index(string CihazID)
        //{
        //    ViewBag.SonOkuma = new Kayit().SonOkuma(CihazID);
        //    ViewBag.CihazID = CihazID;
        //    return View(new Kayit().KayitListesi(CihazID));
        //}

        //public ActionResult GetSensors()
        //{
        //    return View(new Kayit().SonOkuma("ESS_CS001_BX04"));
        //}

        public ActionResult LastMeasurements()
        {
            return View(new Kayit().KayitListesi(""));
        }

        [HttpPost]
        public ActionResult LastMeasurements(string CihazID)
        {
            ViewBag.CihazID = CihazID;
            return View(new Kayit().KayitListesi(CihazID));
        }
        public ActionResult Charts()
        {
            return View(new Kayit().KayitListesi("", 10));
        }

        [HttpPost]
        public ActionResult Charts(string CihazID)
        {
            ViewBag.CihazID = CihazID;
            return View(new Kayit().KayitListesi(CihazID, 10));
        }

        // Sensors
        public ActionResult AddSensor()
        {
            VmSensorField model = new VmSensorField()
            {
                AlanListesi = new Kayit().AlanListesi(),
                Sensors = new sensors()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSensor(VmSensorField model)
        {
            VmSensorField yeniModel = new VmSensorField()
            {
                AlanListesi = new Kayit().AlanListesi(),
                Sensors = new Kayit().SensorEkle(model.Sensors)
            };
            return View(yeniModel);
        }

        public ActionResult EditSensor(int? id)
        {
            VmSensorField model = new VmSensorField
            {
                AlanListesi = new Kayit().AlanListesi(),
                Sensors = new Kayit().SensorGoster(id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditSensor(VmSensorField model)
        {
            model.AlanListesi = new Kayit().AlanListesi();
            model.Sensors = new Kayit().SensorDuzenle(model.Sensors);
            return View(model);
        }

        public ActionResult SensorsList()
        {
            ViewBag.FieldsList = new Kayit().FieldListele();
            return View(new Kayit().SensorListele());
        }

        // Fields
        public ActionResult AddField()
        {
            VmFieldSensor model = new VmFieldSensor()
            {
                SensorListesi = new Kayit().SensorListesi(),
                Fields = new fields()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddField(VmFieldSensor model)
        {
            VmFieldSensor yeniModel = new VmFieldSensor()
            {
                SensorListesi = new Kayit().SensorListesi(),
                Fields = new Kayit().FieldEkle(model.Fields)
            };
            return View(yeniModel);
        }

        public ActionResult EditField(int? id)
        {
            VmFieldSensor model = new VmFieldSensor
            {
                SensorListesi = new Kayit().SensorListesi(),
                Fields = new Kayit().FieldGoster(id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditField(VmFieldSensor model)
        {
            model.SensorListesi = new Kayit().SensorListesi();
            model.Fields = new Kayit().FieldDuzenle(model.Fields);
            return View(model);
        }

        public ActionResult FieldsList()
        {
            ViewBag.SensorsList = new Kayit().SensorListele();
            return View(new Kayit().FieldListele());
        }

        public ActionResult EditSettings()
        {
            ViewBag.LangsList = new Kayit().DilListesi();
            return View(new Kayit().SettingsGoster(1));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditSettings(settings model)
        {
            ViewBag.LangsList = new Kayit().DilListesi();
            return View(new Kayit().SettingsDuzenle(model));
        }
    }
}