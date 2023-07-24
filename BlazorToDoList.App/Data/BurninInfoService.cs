using MsgLibrary;

using MyProject;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BlazorToDoList.App.Data
{


    /// <summary>
    /// 
    /// </summary>
    public class BurninInfoService
    {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        //const string filename = @".\data\demo.db";
        const string filename = @"S:\05_Production_Documents\500W burnin data\consoletest071723\net6.0\demo.db";
        private List<string> _serialNumebrs = new List<string>();

        public List<string>  serials { get=> _serialNumebrs; }

        public BurninInfoService()
        {
            Debug.Print("##burninfoService##");
        }



        public async Task<double[]> GetPowerAsync()
        {
            logger.Info("GetPowerAsync");

            try
            {
                SaveToSqlite.ConnectionString = filename;
                //make sure the file exist.
                if (!File.Exists(filename))
                    throw new FileNotFoundException("File not found", filename);

                // get all the serials.
                List<string> serialNumbers = SaveToSqlite.GetSerialsMsg4();

                double[] doubleArray = new double[serialNumbers.Count];
                const int arraysize = 5;

                for (int i = 0; i < serialNumbers.Count; i++)
                {

                    doubleArray[i] = SaveToSqlite.GetLastPwr(serialNumbers[i]);
                }

                _serialNumebrs = serialNumbers;
                return doubleArray;
            }
            catch (Exception ex)
            {

                logger.Error(ex, "GetPowerAsync");
                throw;
            }
            
            

        }

        /// <summary>
        /// Gets the laser information asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<laserInfo>> GetLaserInfoAsync()
        {
            logger.Info("GetLaserInfoAsync");

            SaveToSqlite.ConnectionString = filename;
            List<laserInfo> laserInfos = SaveToSqlite.GetLaserInfos();
            return laserInfos;
            
        }



        
    }
}
