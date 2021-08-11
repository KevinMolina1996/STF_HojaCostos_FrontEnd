using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Services
{
    public class SincService
    {
        public List<TBL_REF_SINC> ConsultarRefSinc(string TipoInv)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.TBL_REF_SINC.Where(x => x.RsTipoInventarioS == TipoInv).ToList();
            }
        }

        public void ActualizarReferencias(HttpPostedFileBase file)
        {
            try
            {
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    int data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (ExcelPackage package = new ExcelPackage(file.InputStream))
                    {
                        ExcelWorksheets currentSheet = package.Workbook.Worksheets;
                        ExcelWorksheet workSheet = currentSheet.First();
                        int noOfCol = workSheet.Dimension.End.Column;
                        int noOfRow = workSheet.Dimension.End.Row;
                        TBL_REF_SINC param;

                        using (DataBaseContext db = new DataBaseContext())
                        {
                            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [TBL_REF_SINC]");
                        }

                        for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                            {
                                param = new TBL_REF_SINC
                                {
                                    RsReferenciaS = workSheet.Cells[rowIterator, 1].Value.ToString(),
                                    RsTipoInventarioS = workSheet.Cells[rowIterator, 2].Value.ToString()
                                };

                                using (DataBaseContext db = new DataBaseContext())
                                {
                                    db.Entry(param).State = EntityState.Added;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SincronizarReferencia(string Inventario, string Referencia)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (Inventario == "PN")
                {
                    db.Database.ExecuteSqlCommand("", "");
                }
                else
                {
                    
                }
            }
        }
    }
}