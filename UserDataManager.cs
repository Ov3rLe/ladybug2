using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ladybug
{
    public enum DataProcessingResult
    {
        Success,
        Duplicate
    }

    public class UserDataManager
    {
        public event Action UserDataUpdatedEvent;

        private string DataFilePath;

        public UserDataManager(string dataFilePath)
        {
            DataFilePath = dataFilePath;
        }

        public DataProcessingResult AddUser(UserData newUser)
        {
            if (!File.Exists(DataFilePath))
                CreateFile(DataFilePath);

            List<UserData> userDataList = RestoreData();
            using (Stream fs = File.OpenWrite(DataFilePath))
            {
                BinaryFormatter serializer = new BinaryFormatter();

                newUser.Id = userDataList.Count == 0 ? 1 : userDataList[userDataList.Count - 1].Id + 1;
                userDataList.Add(newUser);
                serializer.Serialize(fs, userDataList);
            }

            UserDataUpdatedEvent?.Invoke();
            return DataProcessingResult.Success;
        }

        public List<UserData> RestoreData()
        {
            if (File.Exists(DataFilePath))
            {
                using (Stream fs = File.OpenRead(DataFilePath))
                {
                    if (fs.Length == 0)
                        return new List<UserData>();

                    else
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        return (List<UserData>)deserializer.Deserialize(fs);
                    }
                }
            }

            else
            {
                CreateFile(DataFilePath);
                return new List<UserData>();
            }
        }

        private void CreateFile(string path)
        {
            var f = File.Create(path);
            f.Close();
        }
    }
}
