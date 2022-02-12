using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bivaa_server_new.Interfaces
{
    public interface IDeviceService
    {
        List<devices> GetDevices();
        devices PostDevice(devices requestDevice);
        devices PutDevice(int id, devices requestDevice);
        void DeleteDevice(int id);
    }
}
