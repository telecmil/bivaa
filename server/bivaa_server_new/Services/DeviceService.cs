using bivaa_server_new.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bivaa_server_new.Services
{
    public class DeviceService : IDeviceService
    {
        public List<devices> GetDevices()
        {
            using (var db = new DbModel())
            {
                var devices = (from d in db.devices select d).ToList();
                return devices;
            }
        }

        public devices PostDevice(devices requestDevice)
        {
            using (var db = new DbModel())
            {
                db.devices.Add(requestDevice);
                db.SaveChanges();
                return requestDevice;
            }
        }

        public devices PutDevice(int id, devices requestDevice)
        {
            using (var db = new DbModel())
            {
                var device = (from d in db.devices where d.device_ID == id select d).SingleOrDefault();
                if (device != null)
                {
                    device.device_name = requestDevice.device_name;
                    device.last_inspection = requestDevice.last_inspection;
                    db.SaveChanges();
                    return device;
                }
                else
                {
                    return null;
                }
            }
        }

        public void DeleteDevice(int id)
        {
            using (var db = new DbModel())
            {
                var device = new devices { device_ID = id };
                db.devices.Attach(device);
                db.devices.Remove(device);
                db.SaveChanges();
            }
        }

    }
}