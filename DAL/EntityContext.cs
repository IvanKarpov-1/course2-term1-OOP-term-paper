using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DAL.Exceptions;

namespace DAL
{
    public class EntityContext<T> where T : class, IEntity
    {
        public static void Write(string connection, T data)
        {
            using (var file = new FileStream(connection, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                var temp = new List<T>();
                if (file.Length != 0)
                {
                    temp = (List<T>)formatter.Deserialize(file);
                    file.SetLength(0);
                }
                temp.Add(data);
                try
                {
                    formatter.Serialize(file, temp);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static List<T> ReadFile(string connection)
        {
            using (var file = new FileStream(connection, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                List<T> deserialized;
                try
                {
                    deserialized = (List<T>)formatter.Deserialize(file);
                }
                catch (Exception)
                {
                    throw new TheFileIsEmptyException();
                }

                return deserialized;
            }
        }

        public static void ClearFile(string connection)
        {
            using (var file = new FileStream(connection, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                file.SetLength(0);
            }
        }
    }
}