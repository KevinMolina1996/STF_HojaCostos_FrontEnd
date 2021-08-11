﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AppWebHojaCosto.Controllers.Helpers
{
    public static class CombinePDF
    {
        public static void CombineMultiplePDFs(List<string> fileNames, string outFile)
        {
            try
            {
                // step 1: creation of a document-object
                Document document = new Document();
                //create newFileStream object which will be disposed at the end
                using (FileStream newFileStream = new FileStream(outFile, FileMode.Create))
                {
                    // step 2: we create a writer that listens to the document
                    PdfCopy writer = new PdfCopy(document, newFileStream);
                    if (writer == null)
                    {
                        return;
                    }

                    // step 3: we open the document
                    document.Open();

                    foreach (string fileName in fileNames)
                    {
                        // we create a reader for a certain document
                        PdfReader reader = new PdfReader(fileName);
                        reader.ConsolidateNamedDestinations();

                        // step 4: we add content
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            PdfImportedPage page = writer.GetImportedPage(reader, i);
                            writer.AddPage(page);
                        }

                        PRAcroForm form = reader.AcroForm;
                        if (form != null)
                        {
                            writer.CopyDocumentFields(reader);
                        }

                        reader.Close();
                    }

                    // step 5: we close the document and writer
                    writer.Close();
                    document.Close();
                }//disposes the newFileStream object
            }
            catch (Exception)
            {

            }
        }
    }
}