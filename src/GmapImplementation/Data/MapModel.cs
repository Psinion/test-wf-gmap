using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace GmapImplementation.Data
{
    internal class Marker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PointLatLng Coordinates { get; set; }
    }

    internal class MapModel : IDisposable
    {
        private SqlConnection connection;

        public MapModel()
        {
            connection = new SqlConnection("Data Source=(local);Database=gmapdb;User Id=sa;Password=root;");

            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных.");
            }
        }

        public void Dispose()
        {
            connection.Close();
            connection?.Dispose();
        }

        public Marker[] GetMarkers()
        {
            List<Marker> markers = new List<Marker>();

            SqlCommand command = new SqlCommand(@"SELECT id, name, lat, lng
                                                  FROM markers", connection);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    markers.Add(new Marker()
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Coordinates = new PointLatLng(
                            dataReader.GetDouble(2),
                            dataReader.GetDouble(3))
                    });
                }
            }

            dataReader.Close();

            return markers.ToArray();
        }

        public void SetMarker(Marker marker)
        {
            if (marker == null)
                return;

            string expression = "UPDATE markers " +
                                "SET name = @name, lat = @lat, lng = @lng " +
                                "WHERE id = @id";

            SqlCommand command = new SqlCommand(expression, connection);

            command.Parameters.Add(new SqlParameter("@name", marker.Name));
            command.Parameters.Add(new SqlParameter("@lat", marker.Coordinates.Lat));
            command.Parameters.Add(new SqlParameter("@lng", marker.Coordinates.Lng));
            command.Parameters.Add(new SqlParameter("@id", marker.Id));

            command.ExecuteNonQuery();
        }
    }
}
