using CheckPointApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        static List<Point> Points { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Points = new List<Point>
            {
                new Point { Id = 1, Latitude = "11.432882°", Longitude = "-3.538624°" },
                new Point { Id = 2, Latitude = "11.432723°", Longitude = "-3.537226°°" }
            };
        }

        public static List<Point> GetAll() => Points;

        public static Point Get(int id) => Points.FirstOrDefault(p => p.Id == id);

        public static void Add(Point point)
        {
            point.Id = nextId++;
            Points.Add(point);
        }

        public static void Delete(int id)
        {
            var point = Get(id);
            if(point is null)
                return;

            Points.Remove(point);
        }

        public static void Update(Point point)
        {
            var index = Points.FindIndex(p => p.Id == point.Id);
            if(index == -1)
                return;

            Points[index] = point;
        }
    }
}