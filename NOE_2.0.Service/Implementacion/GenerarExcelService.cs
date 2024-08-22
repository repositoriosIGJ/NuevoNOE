using NUEVO.NOE.Service.Contrato;
using OfficeOpenXml;

namespace NUEVO.NOE.Service.Implementacion
{
    public class GenerarExcelService : IGenerarExcelService
    {
        public async Task<byte[]> GenerateExcelAsync<T>(List<T> items)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            // Obtener todas las propiedades del tipo genérico T.
            // Estas propiedades se utilizarán para crear los encabezados de las columnas y para obtener los valores de los objetos.
            var properties = typeof(T).GetProperties();

            //Encabezados

            for (int i = 0; i < properties.Length; i++)
            {
                // Establece el valor de la celda en la primera fila (fila 1) y la columna correspondiente (i + 1) con el nombre de la propiedad.
                worksheet.Cells[1, i + 1].Value = properties[i].Name;
            }


            // Datos

            for (int i = 0; i < items.Count; i++)
            {
                // Iterar a través de cada propiedad del objeto actual en la lista
                for (int j = 0; j < properties.Length; j++)
                {
                    // Obtener el valor de la propiedad 'properties[j]' del objeto 'items[i]'.

                    var value = properties[j].GetValue(items[i], null) ?? "N/A"; // Si el valor es null, se reemplaza con "N/A" para evitar celdas vacías
                    worksheet.Cells[i + 2, j + 1].Value = value;
                }
            }
            worksheet.Cells.AutoFitColumns(); // Ajusta automáticamente el ancho de las columnas


            var fileContents = package.GetAsByteArray();   // Guarda el Excel en un array de bytes
            return await Task.FromResult(fileContents);
        }
    }
}
