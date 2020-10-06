using WorkingWithFiles.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.IO;
using System.Linq;
using System.IO.Compression;
using Ionic.Zip;
//using ZipFile = System.IO.Compression.ZipFile;


namespace WorkingWithFiles.Controllers
{
    public class ProductsController : Controller
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        static String connectionString = @"Data Source=DESKTOP-H78M1KL\SQLEXPRESS;Initial Catalog=FillesDb;Integrated Security=True;";
        // GET: Products
        public ActionResult Index()
        {
            Products products = GetProducts();
            ViewBag.Message = "";
            return View(products);
        }

        [HttpPost]
        public ActionResult Index(Products obj)
        {
            try
            {
                string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
                string finalPath = "\\UploadedFile\\" + strDateTime + obj.UploadFile.FileName;

                obj.UploadFile.SaveAs(Server.MapPath("~") + finalPath);
                obj.FilePath = strDateTime + obj.UploadFile.FileName;
                ViewBag.Message = SaveToDB(obj);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }

            Products products = GetProducts();
            return View(products);
        }


        public void DownloadFile(String file)
        {
            try
            {
                String filename = file;
                String filepath = Server.MapPath("~/UploadedFile/" + filename);

                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.Flush();

                Response.TransmitFile(filepath);
                Response.End();
                //  HttpContext.ApplicationInstance.CompleteRequest();
                ViewBag.Message = "";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }

        }

      

        public string SaveToDB(Products obj)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_AddFiles";
                cmd.Parameters.AddWithValue("@FileN", obj.FileN);
                cmd.Parameters.AddWithValue("@FilePath", obj.FilePath);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Dispose();
                con.Close();

                return "Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public Products GetProducts()
        
        {
            Products products = new Products();
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand("Select * from tblFiles", con);
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                adapter.Dispose();
                cmd.Dispose();
                con.Close();

                products.lstProducts = new List<Products>();

                foreach (DataRow dr in dt.Rows)
                {
                    products.lstProducts.Add(new Products
                    {
                        FileN = dr["FileN"].ToString(),
                        FilePath = dr["FilePath"].ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                adapter.Dispose();
                cmd.Dispose();
                con.Close();
            }

            if (products == null || products.lstProducts == null || products.lstProducts.Count == 0)
            {
                products = new Products();
                products.lstProducts = new List<Products>();
            }

            return products;
        }


        //[HttpPost]
        public ActionResult DownloadStaffDocuments()
        {
            string path = Server.MapPath("~/UploadedFile/");
            bool exists = Directory.Exists(path);//check folder exsit or not
            string[] Filenames = Directory.GetFiles(path);
            List<string> directoryFileNames = Directory.GetFiles(path).ToList();
            string staffName = "Tayyab";


            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                if (exists)
                {
                    if (directoryFileNames.Count != 0)
                    {
                        zip.AddFiles(directoryFileNames, "");
                        //Generate zip file folder into loation
                        zip.Save(path + staffName + ".zip");//Folder where we want to save zip file
                    }
                }
            }
            return RedirectToAction("Index","Product");
        }


    }
}