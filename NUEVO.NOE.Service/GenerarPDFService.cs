using DinkToPdf;
using DinkToPdf.Contracts;

namespace NUEVO.NOE.Service
{
    public class GenerarPDFService
    {
        private readonly IConverter _converter;

        public GenerarPDFService(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> GeneratePDFHtmlAsync<T>(List<T> items)
        {
            var html = GenerateHTML(items);
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            },
                Objects = {
                new ObjectSettings() {
                    HtmlContent = html,
                    WebSettings = { DefaultEncoding = "utf-8" },
                },
            }
            };

            var pdf = _converter.Convert(doc);
            // Asegurar que el directorio existe
            var directoryPath = Path.Combine("wwwroot", "pdfs");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Guardar PDF en archivo
            var fileName = $"TipoTramite_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            var filePath = Path.Combine(directoryPath, fileName);
            await File.WriteAllBytesAsync(filePath, pdf);

            return pdf; // Devolver el PDF como byte[]

        }

        private string GenerateHTML<T>(List<T> items)
        {
            // Obtener las propiedades del tipo T
            var properties = typeof(T).GetProperties();

            // Iniciar el HTML
            string html = "<h1>Listado</h1><table>";
            html += "<tr>";

            // Crear encabezados de la tabla con los nombres de las propiedades
            foreach (var prop in properties)
            {
                html += $"<th>{prop.Name}</th>";
            }
            html += "</tr>";

            // Rellenar las filas con los valores de las propiedades
            foreach (var item in items)
            {
                html += "<tr>"; // Inicia una nueva fila en la tabla
                foreach (var prop in properties)
                {
                    // Obtiene el valor de la propiedad actual del objeto item
                    var value = prop.GetValue(item, null) ?? "N/A"; // Si el valor es null, usa "N/A"
                    html += $"<td>{value}</td>";
                }
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }
    }
}


