using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Destinations.Models;
using System.IO;

namespace Destinations.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index(string FirstName, String LastName , String Designation)
        {
            //int success = 0;
            try
            {
                FirstName = (FirstName == null) ? FirstName : FirstName.ToUpper();
                LastName = (LastName == null) ? LastName : LastName.ToUpper();
                Designation = (Designation == null) ? Designation : Designation.ToUpper();
                if (FirstName!= null && LastName != null && Designation != null)
                {
                    WriteToTextFile(FirstName + "|" + LastName + "|" + Designation);
                }
                                
                ViewData["Message"] = "You entered ...First Name: " + FirstName + " Last Name: " + LastName + " Designation:  " + Designation;
                //success = 1;
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Exception Occurred: " + ex.ToString();
                return View();
            }
        }

        public IActionResult About(string valueINeed)
        {
            ViewData["Message"] = "Your application description page for destinations digitals. " + valueINeed;

            return View();
        }
        public void WriteToTextFile(string message)
        {
           StreamWriter sw = System.IO.File.AppendText("./Data/Data.txt");
           sw.WriteLine(message);
           sw.Flush();
           sw.Close();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowGrid()
        {
            /*ShowGrid mShowGrid = new ShowGrid();
            mShowGrid.PageNumber = (pageNumber == null ? 1 : Convert.ToInt32(pageNumber));
            mShowGrid.PageSize = 4;*/
            List<ShowGrid> mShowGrid = new List<ShowGrid>();
            List<String[]> DataList = GetData();
            foreach(var item in DataList)
            {

                mShowGrid.Add(new ShowGrid(item[0].ToString(), item[1].ToString(), item[2].ToString()));
            }

            return View(mShowGrid);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public static List<String[]> GetData()
        {
            List<String[]> fileContent = new List<string[]>();
            System.IO.StreamReader file = new System.IO.StreamReader("./Data/Data.txt");
            String line;
            while((line = file.ReadLine())!= null)
            {
                String[] splitline = line.ToString().Split('|');
                fileContent.Add(splitline);
            }
            file.Close();
            return fileContent;
        }


    }
}
