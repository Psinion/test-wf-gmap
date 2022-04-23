using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;

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

            return markers.ToArray();
        }
    }
}
