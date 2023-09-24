using System;
using System.Text.RegularExpressions;
internal class Program
{
    private static void Main(string[] args)
    {
        // Datos a Ingresar
        Console.WriteLine("Ingrese una cadena alfanumérica:");
        string input = Console.ReadLine();

        if (EsAlfanumerico(input))
        {
            Console.WriteLine("La cadena es alfanumérica.");
        }
        else
        {
            Console.WriteLine("La cadena NO es alfanumérica.");
        }

        Console.WriteLine("Ingrese una fecha en el formato dd/mm/yyyy:");
        string fecha = Console.ReadLine();

        if (EsFormatoFechaCorrecto(fecha))
        {
            Console.WriteLine("El formato de fecha es correcto.");
        }
        else
        {
            Console.WriteLine("El formato de fecha NO es correcto.");
        }

        Console.WriteLine("Ingrese un párrafo:");
        string parrafo = Console.ReadLine();

        string[] palabrasMayusculas = EncontrarPalabrasMayusculas(parrafo);

        if (palabrasMayusculas.Length > 0)
        {
            Console.WriteLine("Palabras en mayúsculas encontradas:");
            foreach (string palabra in palabrasMayusculas)
            {
                Console.WriteLine(palabra);
            }
        }
        else
        {
            Console.WriteLine("No se encontraron palabras en mayúsculas.");
        }

        Console.WriteLine("Ingrese un fragmento de código HTML:");
        string codigoHTML = Console.ReadLine();

        string[] etiquetasApertura = EncontrarEtiquetasApertura(codigoHTML);

        if (etiquetasApertura.Length > 0)
        {
            Console.WriteLine("Etiquetas de apertura encontradas:");
            foreach (string etiqueta in etiquetasApertura)
            {
                Console.WriteLine(etiqueta);
            }
        }
        else
        {
            Console.WriteLine("No se encontraron etiquetas de apertura.");
        }

        //// Funciones con expresiones regulares..!

        static bool EsAlfanumerico(string cadena)
        {
            // Expresión regular para validar alfanuméricos.
            // ^ indica el inicio de la cadena.
            // [a-zA-Z0-9] representa cualquier letra mayúscula o minúscula y cualquier dígito.
            // * indica que puede haber 0 o más repeticiones de los caracteres alfanuméricos.
            // $ indica el final de la cadena.
            string patron = "^[a-zA-Z0-9]*$";

            // Utilizamos Regex.IsMatch para verificar si la cadena cumple con el patrón.
            return Regex.IsMatch(cadena, patron);
        }

        static bool EsFormatoFechaCorrecto(string fecha)
        {
            // Expresión regular para validar el formato dd/mm/yyyy.
            // ^ indica el inicio de la cadena.
            // \d{2} representa dos dígitos para el día (dd).
            // / es el separador de día y mes.
            // \d{2} representa dos dígitos para el mes (mm).
            // / es el separador de mes y año.
            // \d{4} representa cuatro dígitos para el año (yyyy).
            // $ indica el final de la cadena.
            string patron = @"^\d{2}/\d{2}/\d{4}$";

            // Utilizamos Regex.IsMatch para verificar si la cadena cumple con el patrón.
            return Regex.IsMatch(fecha, patron);
        }

        static string[] EncontrarPalabrasMayusculas(string texto)
        {
            // Expresión regular para encontrar palabras en mayúsculas completas.
            // \b indica una frontera de palabra, asegurando que coincida con palabras completas.
            // [A-Z]+ representa una o más letras mayúsculas.
            // \b asegura que la palabra en mayúsculas esté completa y no parte de otra palabra.
            // \s* indica que puede haber cero o más espacios entre las palabras.
            string patron = @"\b[A-Z]+\b";

            // Utilizamos Regex.Matches para encontrar todas las coincidencias en el texto.
            MatchCollection matches = Regex.Matches(texto, patron);

            // Convertimos las coincidencias a un arreglo de strings.
            string[] palabrasMayusculas = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                palabrasMayusculas[i] = matches[i].Value;
            }

            return palabrasMayusculas;
        }

        static string[] EncontrarEtiquetasApertura(string codigoHTML)
        {
            // Expresión regular para encontrar etiquetas HTML de apertura.
            // < indica el comienzo de una etiqueta.
            // [^\s<>]+ representa uno o más caracteres que no son espacios en blanco ni < > (nombre de etiqueta).
            // > indica el final de una etiqueta de apertura.
            string patron = @"<[^<>\s]+>";

            // Utilizamos Regex.Matches para encontrar todas las coincidencias en el código HTML.
            MatchCollection matches = Regex.Matches(codigoHTML, patron);

            // Creamos un arreglo para almacenar las etiquetas de apertura encontradas.
            string[] etiquetasApertura = new string[matches.Count];
            int i = 0;

            // Iteramos sobre las coincidencias y almacenamos las etiquetas de apertura.
            foreach (Match match in matches)
            {
                etiquetasApertura[i++] = match.Value;
            }

            // Devolvemos el arreglo con las etiquetas de apertura.
            return etiquetasApertura;
        }
    }
}