using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;

namespace kk4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct coord
        {
            public double lat;
            public double lon;
        }
        public class Us
        {
            public string id;
            public coord[] сoordinates;
        }
        
        private GMarkerGoogle GetMarker(PointLatLng loc, string id, GMarkerGoogleType gMarkerGoogleType= GMarkerGoogleType.lightblue_pushpin)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(loc, gMarkerGoogleType);//широта, долгота, тип маркера
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);//всплывающее окно с инфой к маркеру
            mapMarker.ToolTipText = id; // текст внутри всплывающего окна
            mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver; //отображение всплывающего окна (при наведении)
            return mapMarker;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            map.MapProvider = GMap.NET.MapProviders.WikiMapiaMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            map.MinZoom = 2; //минимальный зум
            map.MaxZoom = 18; //максимальный зум
            map.Zoom = 4; // какой используется зум при открытии
            map.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// точка в центре карты при открытии (центр России)
            map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            map.CanDragMap = true; // перетаскивание карты мышью
            map.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            map.ShowCenter = false; //показывать или скрывать красный крестик в центре
            map.ShowTileGridLines = false; //показывать или скрывать тайлы
            map.NegativeMode = false;
            map.ShowTileGridLines = false;
        }
        static PointLatLng GetLocationByIP(string ipAddress)
        {
            IPAddress address;
            if (IPAddress.TryParse(ipAddress, out address))
            {
                var request = WebRequest.Create($"https://ipinfo.io/{ipAddress}/json");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    dynamic data = null;
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    }

                    if (data != null && data.loc != null)
                    {
                        var coords = data.loc.ToString().Split(',');
                        double lat = double.Parse(coords[0], System.Globalization.CultureInfo.InvariantCulture);
                        double lng = double.Parse(coords[1], System.Globalization.CultureInfo.InvariantCulture);
                        return new PointLatLng(lat, lng);
                    }
                }
            }
            return PointLatLng.Empty;
        }
        
        static dynamic GetLocationByIPApi(IPAddress ipAddress)
        {
            string url = $"http://api.ipapi.com/api/{ipAddress}?access_key=e690a9c67b8ee75a5be4334c115349f3"; 

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            try
            {
                string json = client.DownloadString(url);
                return JObject.Parse(json);
            }
            catch (Exception ex)
            {
                return null;
            }
            

            

            /*string city = (string)data["city"];
            string country = (string)data["country_name"];
            double latitude = (double)data["latitude"];
            double longitude = (double)data["longitude"];

            Console.WriteLine($"Город: {city}");
            Console.WriteLine($"Страна: {country}");
            Console.WriteLine($"Координаты: {latitude}, {longitude}");*/
        }
        
        static dynamic GetLocation(IPAddress ipAddress)
        {
            var request = WebRequest.Create($"https://ipinfo.io/{ipAddress}/json");
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                    dynamic data = null;
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    }

                    return data;
            }
        }
        private void butOk_Click(object sender, EventArgs e)
        {
            map.Overlays.Clear();
            IPAddress address;
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            if (IPAddress.TryParse(tbIP.Text, out address))
            {
                GMapOverlay gMapMarkers = new GMapOverlay("route");// создание именованного слоя
                string targetIP = tbIP.Text;
                var pingSender = new Ping();
                var options = new PingOptions();
                options.DontFragment = true;
                options.Ttl = 1;
                const int timeout = 1000;
                string dat = "pingdata";
                byte[] buffer = Encoding.ASCII.GetBytes(dat);
                var sw = new Stopwatch();
                while (true)
                {
                    sw.Reset();
                    sw.Start();
                    PingReply reply = null;
                    try
                    {
                        reply = pingSender.Send(targetIP, timeout, buffer, options);
                    }
                    catch (Exception ex)
                    {
                        tbOut.AppendText(ex.Message);
                        break;
                    }
                    sw.Stop();

                    if (reply.Status == IPStatus.TimedOut)
                    {
                        tbOut.AppendText("Request timed out.\r\n");
                        break;
                    }

                    if (reply.Address == null)
                    {
                        options.Ttl++;
                        continue;
                    }
                    //dynamic data = GetLocation(reply.Address);
                    dynamic d = GetLocationByIPApi(reply.Address);
                    PointLatLng location;
                    tbOut.AppendText($"Hop {options.Ttl}: {reply.Address} ({sw.ElapsedMilliseconds} ms)\r\n");
                    /*if (data.loc != null)
                    {
                        var coords = data.loc.ToString().Split(',');
                        double lat = double.Parse(coords[0], System.Globalization.CultureInfo.InvariantCulture);
                        double lng = double.Parse(coords[1], System.Globalization.CultureInfo.InvariantCulture);
                        location = new PointLatLng(lat, lng);
                    }*/
                    if (d.continent_code != null)
                    {
                        double lat = double.Parse(d.latitude.ToString());
                        double lng = double.Parse(d.longitude.ToString());
                        tbOut.AppendText($"{d.latitude}");
                        location = new PointLatLng(lat, lng);
                    }
                    else
                    {
                        options.Ttl++;
                        continue;
                    }
                    points.Add(location);
                    //string[] str = {$"{options.Ttl}", $"{data.ip}", $"{sw.ElapsedMilliseconds}",$"{data.hostname}",$"{data.city}",$"{data.region}", $"{data.org}"};
                    string[] str = {$"{options.Ttl}", $"{d.ip}", $"{sw.ElapsedMilliseconds}",$"{reply.Address}",$"{d.city}",$"{d.region_name}", $"{d.country_name}"};
                    grid.Rows.Add(str);
                    gMapMarkers.Markers.Add(GetMarker(location, $"{d.ip}"));
                    options.Ttl++;
                    if (reply.Address.ToString() == targetIP)
                    {
                        tbOut.AppendText("Trace complete.\r\n");
                        map.Position = location;
                        MessageBox.Show("Trace complete");
                        GMapRoute route = new GMapRoute(points, "route");
                        route.Stroke = new Pen(Color.Red, 3);
                        routes.Routes.Add(route);
                        map.Overlays.Add(routes);
                        map.Overlays.Add(gMapMarkers);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong ip");
            }
        }
    }
}