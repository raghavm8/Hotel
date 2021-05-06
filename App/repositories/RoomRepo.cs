using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Models;

namespace App.repositories
{
    public class RoomRepo
    {
        public Dictionary<string, int> GetCountOfType(IEnumerable<Room> rooms)
        {
            Dictionary<string, int> TypeCount = new Dictionary<string, int>();

            foreach (var x in rooms)
            {
                if (TypeCount.ContainsKey(x.RoomType))
                {
                    TypeCount[x.RoomType] += 1;
                }
                else
                {
                    TypeCount.Add(x.RoomType, 0);
                }
            }
            return TypeCount;
        }
    }
}