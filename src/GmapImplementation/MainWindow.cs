using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GmapImplementation.Data;

namespace GmapImplementation
{
    public partial class MainWindow : Form
    {
        private MapModel mapModel;

        private Dictionary<GMapMarker, Marker> mapMarkers;

        private GMapMarker selectedMarker;
        private bool leftMouseButtonDown = false;

        public MainWindow()
        {
            InitializeComponent();

            mapModel = new MapModel();
            mapMarkers = new Dictionary<GMapMarker, Marker>();
        }

        private void MainMapControl_Load(object sender, EventArgs e)
        {
            MainMapControl.Bearing = 0;
            MainMapControl.MarkersEnabled = true;
            MainMapControl.MaxZoom = 18;
            MainMapControl.MinZoom = 2;
            MainMapControl.Zoom = 10;
            MainMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            MainMapControl.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            MainMapControl.Position = new PointLatLng(54.974141, 82.924312);

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            MainMapControl.Overlays.Add(markersOverlay);

            foreach (Marker marker in mapModel.GetMarkers())
            {
                GMarkerGoogle gMarker = new GMarkerGoogle(marker.Coordinates, GMarkerGoogleType.red);
                gMarker.ToolTip = new GMapRoundedToolTip(gMarker);
                gMarker.ToolTipText = marker.Name;

                mapMarkers.Add(gMarker, marker);
                markersOverlay.Markers.Add(gMarker);
            }
        }

        private void MainMapControl_OnMarkerEnter(GMapMarker item)
        {
            selectedMarker = item;
        }

        private void MainMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedMarker == null) return;

            mapModel.SetMarker(mapMarkers[selectedMarker]);

            selectedMarker = null;
        }


        private void MainMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedMarker != null)
            {
                PointLatLng point = MainMapControl.FromLocalToLatLng(e.X, e.Y);

                selectedMarker.Position = point;
                mapMarkers[selectedMarker].Coordinates = selectedMarker.Position;
            } 
        }
    }
}
