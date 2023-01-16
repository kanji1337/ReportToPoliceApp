using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReportPoliceSite.Model;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Magnum.FileSystem;

namespace ReportPoliceSite.ViewModel
{
    public class Core : BaseViewModel
    {
        public ObservableCollection<User> Users = new ObservableCollection<User>();

        public ObservableCollection<Report> Reports = new ObservableCollection<Report>();

        public void SaveToFileData()
        {
            SerialzieObject("UsersDataBase.xml", Users);
        }
        public void SaveToFileReports()
        {
            SerialzieObject("ReportsDataBase.xml", Reports);
        }

        private void SerialzieObject<T>(string filename, T objectToSerialize)
        {
            XmlSerializer x = new XmlSerializer(typeof(T));
            TextWriter writter = new StreamWriter(filename);
            x.Serialize(writter, objectToSerialize);
        }

        public void LoadFromDB()
        {
            Users = DeseriolizeData<ObservableCollection<User>>("UsersDataBase.xml");
        }
        public void LoadReportsFromDB()
        {
            Reports = DeseriolizeData<ObservableCollection<Report>>("ReportsDataBase.xml");
        }

        private T DeseriolizeData<T>(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) { return default(T); }

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
