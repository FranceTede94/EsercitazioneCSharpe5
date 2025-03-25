using CsvHelper.Configuration;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSV_CONVERT
{
    internal class CONVERTI
    {
        // Definisce un metodo statico che restituisce un CsvReader
        static CsvReader CsvRead(string InputFileCsv)
        {
            // Crea una configurazione per il CsvReader, impostando il delimitatore e come gestire i campi mancanti
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";", // Imposta il delimitatore di campo come punto e virgola
                MissingFieldFound = null // Ignora i campi mancanti durante la lettura
            };

            // Apre il file CSV in lettura tramite StreamReader
            StreamReader reader = new StreamReader(InputFileCsv);

            // Restituisce un oggetto CsvReader con il lettore e la configurazione specificata
            return new CsvReader(reader, config);
        }



        // Metodo pubblico e statico per correggere e scrivere un file CSV
        public static void SistemaFileCsv(string InputFileCsv, string OutputFileCsv)
        {
            // Numero atteso di punti e virgola per una riga corretta 
            int numeropuntievirgola = 10;
            // Creazione di una stringa vuota
            string buffer = "";
            int Conteggiopuntievirgola = 0;

            // Apre il file di input (per la lettura) e quello di output (per la scrittura)
            using (var reader = new StreamReader(InputFileCsv))  // Apre il file di input
            using (var writer = new StreamWriter(OutputFileCsv)) // Apre il file di output
            {
                // Ciclo che legge il file riga per riga finché non è finito
                while (!reader.EndOfStream)  // Continua finché non siamo alla fine del file
                {
                    // Legge una riga dal file di input
                    string RigaLetta = reader.ReadLine();  // Legge una riga del file CSV

                    // Aggiunge la riga letta alla stringa buffer (per memorizzare il contenuto)
                    buffer += RigaLetta;  // Aggiunge la riga letta al buffer

                    // Conta quanti punti e virgola ci sono nella riga letta
                    Conteggiopuntievirgola += RigaLetta.Count(f => (f == ';'));  // Conta i punti e virgola nella riga

                    // Se la riga ha il numero corretto di punti e virgola (è completa), la scriviamo nel file di output
                    if (Conteggiopuntievirgola == numeropuntievirgola)  // Verifica se la riga ha il numero giusto di punti e virgola
                    {
                        // Scrive la riga completa nel file di output
                        writer.WriteLine(buffer);  // Scrive la riga nel file di output

                        // Reset dei contatori e del buffer per la prossima riga
                        Conteggiopuntievirgola = 0;  // Resetta il contatore dei punti e virgola
                        buffer = "";  // Resetta il buffer (che contiene la riga)
                    }
                }
            }
        }

        // Metodo pubblico e statico che converte un file CSV in formato JSON
        public static void ConvertiInJson(string OutputFileCsv, string OutPutFileJson)
        {
            // Log di inizio per la lettura del CSV
            Console.WriteLine($"Inizio lettura del CSV: {OutputFileCsv}");

            // Legge il file CSV usando il metodo CsvRead e lo converte in una lista di oggetti 'TestImport'
            CsvReader csvtest = CsvRead(OutputFileCsv);
            List<TESTIMPORT> list = csvtest.GetRecords<TESTIMPORT>().ToList();

            List<BITWARDEN> listBitW = new List<BITWARDEN>();

            foreach (var item in list)
            {
                var x = new BITWARDEN();

                // Inizializza login se è null
                if (x.login == null)
                {
                    x.login = new Login();
                }
                string[] TotaleStringhe = item.GetPathItems();
                x.passwordHistory = null;
                x.revisionDate = DateTime.Now;
                x.creationDate = DateTime.Now;
                x.deletedDate = null;
                x.id = Guid.NewGuid();
                x.organizationId = Guid.Parse("e35ace0f-ca12-4059-bffd-b1ff00c8b3db");
                x.folderId = null;
                x.type = 1;
                x.reprompt = 0;
                x.name = item.PasswordName;
                x.notes = item.Nota1 + " " + item.Nota2 + " " + item.Nota3;
                x.favorite = false;
                x.login.fido2Credentials = new object[] { };
                x.login.uris = new Uri[] { new Uri() { match = null, uri = item.PasswordUrl } };
                x.login.username = item.PasswordLogin;
                x.login.password = item.Password;
                x.login.totp = null;
                x.login.password = item.Password;
                x.collectionIds = new string[] { "36701ac1-298a-4dcc-a9f5-b20300aac91e" };

                listBitW.Add(x);
            }

            // Log per il numero di record letti dal CSV
            Console.WriteLine($"Numero di record letti dal CSV: {list.Count}");

            // Converte la lista di oggetti 'TestImport' in una stringa JSON formattata in modo leggibile
            string json = JsonConvert.SerializeObject(listBitW, Formatting.Indented);

            // Salva il JSON generato in un file (puoi cambiare il percorso)
            File.WriteAllText(OutPutFileJson, json);

            // Log di successo, con il percorso del file JSON e il numero di elementi
            Console.WriteLine($"File JSON {OutPutFileJson} creato con successo n. elementi {list.Count()}");
        }
    }
}
