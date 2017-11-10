using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Log
{
    public class DatabaseLogger
    {
        public void WriteLog(string message)
        {
            System.Windows.Forms.MessageBox.Show("Database Loglama Yapıldı\n"+message);
        }
    }
}
