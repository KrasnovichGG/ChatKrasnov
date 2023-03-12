using ChatKrasnov.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatKrasnov
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string ConfigFilePath = Path.GetTempPath() + "config.ini";
        public static ChatEntities chatEntitiesDB = new ChatEntities();
        public static Employee emp;
        public static ChatRoom room;
    }
}
